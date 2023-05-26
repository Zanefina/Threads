using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a list of cars
            var cars = new List<Car>
        {
            new Car("Car A"),
            new Car("Car B"),
            new Car("Car C"),
            new Car("Car D")
        };

            // Create threads for cars
            var carThreads = cars.Select(car => new Thread(car.Drive)).ToList();

            // Start race
            Console.WriteLine("Starting race!");

            foreach (var thread in carThreads)
            {
                thread.Start();
            }

            // Wait for cars to finish
            while (cars.Any(car => car.Distance < 1000 && !car.Finished))
            {
                if (Console.KeyAvailable)
                {
                    if (Console.ReadLine() == "status")
                    {
                        foreach (var car in cars)
                        {
                            Console.WriteLine($"{car.Name} - Distance: {car.Distance}m\tSpeed: {car.Speed} km/h");
                        }
                    }
                }
                Thread.Sleep(100);
            }

            // Determine positions
            var positions = new List<string> { "1st", "2nd", "3rd", "4th" };
            var sortedPositions = positions.Take(cars.Count).ToList();
            var sortedCars = cars.OrderByDescending(car => car.Distance).ToList();

            for (int i = 0; i < sortedCars.Count; i++)
            {
                var car = sortedCars[i];
                var position = sortedPositions[i];
                Console.WriteLine($"{position} place: {car.Name} - Distance: {car.Distance}m");

                if (position == "1st")
                {
                    Console.WriteLine($"{car.Name} wins the race!");
                }
                else if (position == "2nd")
                {
                    Console.WriteLine($"{car.Name} takes the 2nd place.");
                }
                else if (position == "3rd")
                {
                    Console.WriteLine($"{car.Name} finishes in 3rd place.");
                }
                else if (position == "4th")
                {
                    Console.WriteLine($"{car.Name} finishes in 4th place.");
                }
            }

            // Wait for user to exit
            Console.ReadLine();




            //    // Create cars
            //    var cars = new List<Car>
            //    {
            //    new Car("Car A"),
            //    new Car("Car B"),
            //    new Car("Car C"),
            //    new Car("Car D")
            //    };

            //    // Create threads for cars
            //    var carThreads = cars.Select(car => new Thread(car.Drive)).ToList();

            //    // Start race
            //    Console.WriteLine("Starting race!");

            //    foreach (var thread in carThreads)
            //    {
            //        thread.Start();
            //    }

            //    // Wait for cars to finish
            //    while (cars.Any(car => car.Distance < 1000))
            //    {
            //        if (Console.KeyAvailable)
            //        {
            //            if (Console.ReadLine() == "status")
            //            {
            //                foreach (var car in cars)
            //                {
            //                    Console.WriteLine($"{car.Name} - Distance: {car.Distance}m\tSpeed: {car.Speed} km/h");
            //                }
            //            }
            //        }
            //        Thread.Sleep(100);
            //    }

            //    // Determine winner
            //    var winner = cars.OrderByDescending(car => car.Distance).First();
            //    Console.WriteLine($"{winner.Name} wins the race!");

            //    // Wait for user to exit
            //    Console.ReadLine();

        }
    }

}







