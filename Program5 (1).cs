using System;
using System.Collections.Generic;

namespace SydneyCoffee
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter number of customers: ");
            int n = Convert.ToInt32(Console.ReadLine());

            List<string> name = new List<string>();
            List<int> quantity = new List<int>();
            List<string> reseller = new List<string>();
            List<double> charge = new List<double>();

            double price;
            double min = 99999999;
            string minName = "";
            double max = -1;
            string maxName = "";

            Console.WriteLine("\n\t\t*** Welcome to Sydney Coffee Program ***\n");

            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter customer name: ");
                name.Add(Console.ReadLine());

                int q = 0;
                do
                {
                    Console.Write("Enter number of coffee bean bags (1–200): ");
                    q = Convert.ToInt32(Console.ReadLine());

                    if (q < 1 || q > 200)
                    {
                        Console.WriteLine("Invalid input! Please enter between 1 and 200.");
                    }

                } while (q < 1 || q > 200);

                quantity.Add(q);

                if (q <= 5)
                    price = 36 * q;
                else if (q <= 15)
                    price = 34.5 * q;
                else
                    price = 32.7 * q;

                string tempReseller;
                do
                {
                    Console.Write("Are you a reseller? (y/n): ");
                    tempReseller = Console.ReadLine().ToLower();

                    if (tempReseller == "y") tempReseller = "yes";
                    if (tempReseller == "n") tempReseller = "no";

                    if (tempReseller != "yes" && tempReseller != "no")
                    {
                        Console.WriteLine("Invalid input! Please enter y or n.");
                    }

                } while (tempReseller != "yes" && tempReseller != "no");

                reseller.Add(tempReseller);

                double finalCharge;

                // CHANGE 1: reseller discount 20% → 25%
                if (tempReseller == "yes")
                    finalCharge = Math.Round(price * 0.75, 2);
                else
                    finalCharge = Math.Round(price, 2);

                charge.Add(finalCharge);

                Console.WriteLine($"Total charge for {name[i]} is ${finalCharge}");
                Console.WriteLine("-----------------------------------------------------");

                if (finalCharge < min)
                {
                    min = finalCharge;

                    // CHANGE 2: include number of bags
                    minName = name[i] + " (" + quantity[i] + " bags)";
                }

                if (finalCharge > max)
                {
                    max = finalCharge;

                    // CHANGE 2: include number of bags
                    maxName = name[i] + " (" + quantity[i] + " bags)";
                }
            }

            Console.WriteLine("\n============= SUMMARY REPORT =============");

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += charge[i];
            }

            double average = sum / n;
            Console.WriteLine($"Average order charge: ${average:F2}");

            Console.WriteLine($"Lowest charge: ${min} by {minName}");
            Console.WriteLine($"Highest charge: ${max} by {maxName}");

            Console.WriteLine("\nThank you for using Sydney Coffee Program!");
        }
    }
}
