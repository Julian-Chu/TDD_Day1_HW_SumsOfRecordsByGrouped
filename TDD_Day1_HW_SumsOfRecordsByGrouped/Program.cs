using System.Collections.Generic;
using System.Linq;
using System;


namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var obj = new Product();
            var properties = obj.GetType().GetProperties();
            foreach(var element in properties)
                Console.WriteLine(element.Name.ToString());
            Console.ReadKey();
            
        }
    }
}