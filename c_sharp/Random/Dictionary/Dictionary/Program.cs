using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start...");
            Dictionary_Examples1();
        }

        static void Dictionary_Examples1()
        {
            IDictionary<int, string> numberNames = new Dictionary<int, string>();
            numberNames.Add(1, "One");
            numberNames.Add(2,"Two");
            numberNames.Add(3, "Three");

            //Trying to add an already existing entry -> results in exception
            //numberNames.Add(3, "Three");

            // You can use a more declarative way
            //foreach (KeyValuePair<int,string> kvp in numberNames) 
            //{
            //    Console.WriteLine($"Key: {kvp.Key} - Value: {kvp.Value}");
            //}

            // but given how c# works, this will work just fine
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Simply listing the elements of the dictionary");
            foreach (var kvp in numberNames)
            {
                Console.WriteLine($"Key: {kvp.Key} - Value: {kvp.Value}");
            }



            //creating a dictionary using collection-initializer syntax
            var cities = new Dictionary<string, string>()
            {
                {"Canada","Toronto, Ottawa, Vancouver"},
                {"United States","New York, Los Angeles, Dallas"},
                {"Germany","Berlin, Munich, Hamburg"},
            };
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Dictionary 'collection-initializer syntax' and then listing the elements of the dictionary");
            foreach (var i in cities) 
            {
                Console.WriteLine($"Country: {i.Key} - Cities: {i.Value}");
            }

            //accessing dictionary values - this is also a good example where you can use
            //  a string containing spaces as a key to your dictionary
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("accessing dictionary values by its keys");
            Console.WriteLine($"Cities in United States: {cities["United States"]}");
            Console.WriteLine($"Cities in Canada: {cities["Canada"]}");


            Console.WriteLine("---------------------------------------");
            Console.WriteLine("What happens when we try to access something that doesn't exist in the dictionary?");
            //what happens when we try to access something that doesn't exist in the dictionary?
            //  answer: it will crash
            //Console.WriteLine($"Cities in Japan: { cities["Japan"] }");

            //so we need to check whether the key exists:
            if (cities.ContainsKey("Japan")) { Console.WriteLine("Japan key found"); }
            else { Console.WriteLine("Japan key was not found");  }

            //now a different way to iterate through the dictionary
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Accessing elements at the dictionary through a index");
            for (int i = 0; i < cities.Count; i++  )
            {
                //this one needs to use LINQ
                Console.WriteLine($"Cities Dictionary: Key:{cities.ElementAt(i).Key} - Value:{cities.ElementAt(i).Value}");
            }

            //updating dictionary
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("updating dictionary");
            cities["United States"] = "New York, Los Angeles, Dallas, Chicago, Miami";

            // I was expecting a runtime exception, but apparetnly now it's ok to do this
            cities["Japan"] = "Tokyo";

            foreach (var i in cities)
            {
                Console.WriteLine($"Country: {i.Key} - Cities: {i.Value}");
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("removing from dictionary");
            cities.Remove("Germany");

            //no problem - was expecting runtime exception
            cities.Remove("UK");

            foreach (var i in cities)
            {
                Console.WriteLine($"Country: {i.Key} - Cities: {i.Value}");
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("order by key asc");
            foreach (var i in cities.OrderBy(x=> x.Key))
            {
                Console.WriteLine($"Country: {i.Key} - Cities: {i.Value}");
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("order by key desc");
            foreach (var i in cities.OrderByDescending(x=> x.Key) )
            {
                Console.WriteLine($"Country: {i.Key} - Cities: {i.Value}");
            }

        }
    }
}
