using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Threads
{
    public class Car
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public int Speed { get; set; }
        public bool Finished { get; set; }

        public Car(string name)
        {
            Name = name;
            Distance = 0;
            Speed = 120;
            Finished = false;
        }

        public void Drive()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var eventHappened = false;

            while (!Finished && Distance < 1000)
            {
                if (!eventHappened && stopwatch.ElapsedMilliseconds >= 10000)
                {
                    var random = new Random();
                    int prob = random.Next(1, 51);
                    eventHappened = true;

                    switch (prob)
                    {
                        case 1: // 1/50 chance of running out of gas
                            Console.WriteLine($"{Name} ran out of gas and needs to refuel!");
                            Thread.Sleep(30000);
                            break;
                        case 2: // 2/50 chance of getting a flat tire
                            Console.WriteLine($"{Name} got a flat tire and needs to change it!");
                            Thread.Sleep(20000);
                            break;
                        case 3: // 5/50 chance of bird hitting the windshield
                        case 4:
                        case 5:
                            Console.WriteLine($"{Name} got a bird on its windshield and needs to clean it!");
                            Thread.Sleep(10000);
                            break;
                        case 6: // 10/50 chance of engine trouble
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                            Console.WriteLine($"{Name} has engine trouble and slows down!");
                            Speed -= 1;
                            break;
                    }

                    Distance += Speed;
                    stopwatch.Restart();
                    eventHappened = false;
                }
                Thread.Sleep(10);
            }
            Finished = true;
        }
    }
}
