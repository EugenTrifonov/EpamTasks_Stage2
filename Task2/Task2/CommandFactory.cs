using System;
using System.Collections.Generic;
using System.Linq;
using Task2.Comands;

namespace Task2
{
    public static class CommandFactory
    {
        public static List<string> CommandWords = new List<string> { "add", "count", "types", "all", "average", "price", "type", "exit" };

        public static ICommand GetCommand(string[] args)
        {
            string command = string.Empty;
            List<string> parameters = new List<string>();

            for (int i = 0; i < args.Length; i++)
            {
                if (CommandWords.Contains(args[i]))
                {
                    command += args[i];
                }
                else
                {
                    parameters.Add(args[i]);
                }
            }

            switch (command)
            {
                case "add":
                    if (CheckInputForAdd(parameters))
                    {
                        return new AddComand(new Car(parameters[0], parameters[1], Convert.ToInt32(parameters[2]), Convert.ToInt32(parameters[3])));
                    }
                    throw new Exception("Incorrect arguments(brand,model,amount,price)");

                case "counttypes":
                    return new CountTypesCommand();

                case "countall":
                    return new CountAllCommand();

                case "averageprice":
                    if (parameters.Count != 0)
                    {
                        throw new Exception("Incorrect command");
                    }

                    return new GetAveragePrice();

                case "averagepricetype":
                    if (parameters.Count() == 1)
                    {
                        return new GetAveragePriceOfBrand(parameters[0]);
                    }

                    throw new Exception("Incorrect arguments(brand)");

                case "exit":
                    return new ExitCommand();

                default:
                    throw new Exception("Incorrect command");
            }
        }

        private static bool CheckInputForAdd(List<string> parameters)
        {
            if (parameters.Count > 4)
            {
                return false;
            }

            try
            {
                Convert.ToInt32(parameters[2]);
                Convert.ToInt32(parameters[3]);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
