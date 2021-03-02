using Serilog;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleATM
{
    public class Program
    {
        private static ATM _atm;

        public static void Main(string[] programArgs)
        {
            Log.Logger = CreateSerilogLogger();
            _atm = GetATM(programArgs);

            try
            {
                Work();
            }
            catch (AtmException e)
            {
                Console.Error.WriteLine($"{e.Message}");
                Work(); //Recovery
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"{e.Message} | see logs");
                Log.Logger.Error(e.Message);
                Log.Logger.Error(e.StackTrace);
                Work(); //Recovery
            }
        }

        private static void Work()
        {
            while (true)
            {
                Console.Write(">");

                var input = Console.ReadLine();
                var parts = input.Split(' ');
                var name = parts.First();
                var commandArgs = parts.Skip(1).ToArray();

                switch (name.ToLowerInvariant())
                {
                    case "q":
                    case "quit":
                    case "exit":
                        Console.WriteLine("Terminating...");
                        return;
                    case "balance":
                        Console.WriteLine(_atm.BalanceString);
                        break;
                    case "dispense":
                        var toDispense = commandArgs.FirstOrDefault()
                            ?? throw new AtmException("Specify how many cash you're going to withdraw");

                        if (UInt32.TryParse(toDispense, out uint parsed))
                            _atm.DispenseMoney(parsed);
                        else
                            throw new AtmException("Invalid value");

                        break;
                    case "put":
                        var toPut = commandArgs.First().Split(':');

                        if (UInt32.TryParse(toPut[0], out uint nominal) && UInt32.TryParse(toPut[1], out uint count))
                            _atm.PutMoney(nominal, count);
                        else
                            throw new AtmException("Invalid value");

                        Console.WriteLine(_atm.BalanceString);

                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
        }

        private static ATM GetATM(string[] programArgs)
        {
            var initialBalance = new Dictionary<uint, uint>(programArgs.Length);

            foreach (string arg in programArgs)
            {
                var pair = arg.Split(':').Select(s => UInt32.Parse(arg));
                initialBalance[pair.ElementAt(0)] = pair.ElementAt(1);
            }

            return new ATM(() => initialBalance);
        }

        private static ILogger CreateSerilogLogger()
        {
            const string path = @"..\..\..\..\..\log.txt";
            const string logTemplate = "[{Timestamp:yyyy:MM:dd:HH:mm:ss.fff} {Level:u3}] {Message:lj}{NewLine}{Exception}";

            return new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.File(
                    path,
                    outputTemplate: logTemplate,
                    rollingInterval: RollingInterval.Day
                )
                .CreateLogger();
        }
    }
}
