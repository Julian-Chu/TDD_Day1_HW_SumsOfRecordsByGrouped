using System.Collections.Generic;
using System.Linq;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Product> Products = new List<Product>();

            for (int i = 1; i < 12; i++)
            {
                Products.Add(new Product() { Id = i, Cost = i, Revenue = 10 + i, SellPrice = 20 + i });
            }

            foreach (var product in Products)
            {
                System.Console.WriteLine("Id: {0}, Cost: {1}, Revenue: {2}, SellPrice: {3}", product.Id, product.Cost, product.Revenue, product.SellPrice);
            }
            
            GroupSumCalculator calculator = new GroupSumCalculator();
            var results=calculator.SumByGroupedRecords(Products, ColumnName.Revenue, 3);
            foreach(var element in results)
            {
                System.Console.WriteLine(element);
            }
            System.Console.WriteLine();
            var test = Products.GroupBy(p => (p.Id-1) / 4)
                //.Select(x => x.Select(v => v.Revenue).Sum())
                
                .ToList();
            foreach (var element in test)
            {
                System.Console.WriteLine(element);
            }

            System.Console.ReadKey();
        }
    }
}