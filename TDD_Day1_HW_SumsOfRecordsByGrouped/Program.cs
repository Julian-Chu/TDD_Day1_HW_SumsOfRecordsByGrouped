using System.Collections.Generic;
using System.Linq;
using System;


namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var targetClass = new Product() { Id = 1 };
            var targetClassCollection = new List<Product>()
            {
                new Product {Id=2 },
                new Product {Id=3 }
            };
            var properties = targetClass.GetType().GetProperties().Select(p => p.Name);
            var property = targetClass.GetType().GetProperty("Id");//.GetValue(targetClass,null);
            var IDvalues = targetClassCollection.Select(p => p.GetType().GetProperty("Id").GetValue(p, null));
            foreach (var element in properties)
                Console.WriteLine(element.GetType());
            Console.ReadKey();
            
        }
    }
}