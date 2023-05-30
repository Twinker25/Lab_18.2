using System;

namespace Lab_18._2
{
    internal class Program
    {
        static void SortDescending(string[] strings)
        {
            var sortDescending = strings.OrderByDescending(s => s.Length);

            Console.WriteLine("Sorted array in descending order of string length:");
            foreach (var item in sortDescending)
            {
                Console.WriteLine(item);
            }
        }

        static void SortIncreasing(string[] strings)
        {
            var sortIncreasing = strings.OrderBy(s => s.Length);

            Console.WriteLine("Sorted array in increasing order of string length:");
            foreach (var item in sortIncreasing)
            {
                Console.WriteLine(item);
            }
        }



        static void Except(int[] arr1, int[] arr2)
        {
            var except = arr1.Except(arr2);
            Console.Write("Difference between arrays: ");
            foreach (var item in except)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        static void Intersect(int[] arr1, int[] arr2)
        {
            var except = arr1.Intersect(arr2);
            Console.Write("Intersection of arrays: ");
            foreach (var item in except)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        static void Union(int[] arr1, int[] arr2)
        {
            var except = arr1.Union(arr2);
            Console.Write("Union of arrays: ");
            foreach (var item in except)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }

        static void Distinct(int[] arr1)
        {
            var except = arr1.Distinct();
            Console.Write("Distinct elements of the array: ");
            foreach (var item in except)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }



        public class Car
        {
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public int Year { get; set; }
        }



        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Enter task (1 - 3): ");
                int choice = int.Parse(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.Write("Enter count of words: ");
                        int countWords = int.Parse(Console.ReadLine());
                        string[] words = new string[countWords];
                        for (int i = 0; i < countWords; i++)
                        {
                            Console.Write($"Enter word {i + 1}: ");
                            words[i] = Console.ReadLine();
                        }

                        Console.WriteLine("All words:");
                        foreach (var word in words)
                        {
                            Console.WriteLine(word);
                        }

                        Console.Write("Which sort with words you want use:\n1: Sorting by descending length\n2: Sorting by increasing length\n");
                        int ch = int.Parse(Console.ReadLine());
                        switch (ch)
                        {
                            case 1:
                                SortDescending(words);
                                break;
                            case 2:
                                SortIncreasing(words);
                                break;
                            default:
                                Console.WriteLine("Error!");
                                break;
                        }
                        break;
                    case 2:
                        Random r = new Random();
                        Console.Write("Enter size for both array: ");
                        int size = int.Parse(Console.ReadLine());
                        int[] arr1 = new int[size];
                        int[] arr2 = new int[size];
                        Console.Write("Array 1: ");
                        for (int i = 0; i < size; i++)
                        {
                            arr1[i] = r.Next(1, 10);
                            Console.Write(arr1[i] + ", ");
                        }
                        Console.Write("\nArray 2: ");
                        for (int i = 0; i < size; i++)
                        {
                            arr2[i] = r.Next(1, 10);
                            Console.Write(arr2[i] + ", ");
                        }
                        Console.WriteLine();

                        Except(arr1, arr2);
                        Intersect(arr1, arr2);
                        Union(arr1, arr2);
                        Distinct(arr1);
                        break;
                    case 3:
                        var array1 = new Car[]
                        {
                            new Car { Name = "Car1", Manufacturer = "Manufacturer1", Year = 2010 },
                            new Car { Name = "Car2", Manufacturer = "Manufacturer2", Year = 2012 },
                            new Car { Name = "Car3", Manufacturer = "Manufacturer3", Year = 2014 }
                        };

                        var array2 = new Car[]
                        {
                            new Car { Name = "Car4", Manufacturer = "Manufacturer2", Year = 2011 },
                            new Car { Name = "Car5", Manufacturer = "Manufacturer3", Year = 2013 },
                            new Car { Name = "Car6", Manufacturer = "Manufacturer4", Year = 2015 }
                        };

                        var difference = array1.Where(car1 => !array2.Any(car2 => car2.Manufacturer == car1.Manufacturer));
                        Console.WriteLine("Difference:");
                        PrintArray(difference);

                        var intersection = array1.Where(car1 => array2.Any(car2 => car2.Manufacturer == car1.Manufacturer));
                        Console.WriteLine("Intersection:");
                        PrintArray(intersection);

                        var union = array1.Concat(array2);
                        Console.WriteLine("Union:");
                        PrintArray(union);
                        break;
                    default:
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
        public static void PrintArray(IEnumerable<Car> cars)
        {
            foreach (var car in cars)
            {
                Console.WriteLine($"Name: {car.Name}, Manufacturer: {car.Manufacturer}, Year: {car.Year}");
            }

            Console.WriteLine();
        }
    }
}