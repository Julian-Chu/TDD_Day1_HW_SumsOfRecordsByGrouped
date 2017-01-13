using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TDD_Day1_HW_SumsOfRecordsByGrouped;

namespace SumByPageSize_WithReflection_Tests
{
    [TestClass]
    public class SumByPageSize
    {
        [TestMethod]
        public void GetSumTest_Source_5_3_1_PageSize_2_Returns_8_1()
        {
            //Assign
            var source = new int[3] { 5, 3, 1 };
            int pageSize = 2;
            //Act
            var actual = source.GetSumByPagesize(pageSize, x => x).ToArray();
            //Assert
            var expected = new int[2] { 8, 1 };
            CollectionAssert.AreEqual(expected, actual);
        }

        //[TestMethod]
        //public void GetSumTest_Source_5_3_1_PageSize_1_Returns_5_3_1()
        //{
        //    //Assign
        //    var source = new int[3] { 5, 3, 1 };
        //    int pageSize = 1;
        //    //Act
        //    var actual = source.GetSumByPagesize(pageSize, x => x).ToArray();
        //    //Assert
        //    var expected = new int[3] { 5, 3, 1 };
        //    CollectionAssert.AreEqual(expected, actual);
        //}

        [TestMethod]
        public void GetSumTest_ColumnName_Cost_PageSize_3_Returns_6_15_24_21()
        {
            //Assign
            var products = this.GetProducts();
            int pageSize = 3;
            string ColumnName = "Cost";
            //Act
            //var actual = products.GetSum(pageSize, x => x.GetType().GetProperty("Cost").GetValue(x, null));
            var actual = products.Select(p => (int)p.GetType().GetProperty(ColumnName).GetValue(p, null)).GetSumByPagesize(pageSize, x => x).ToList();

            //Assert
            List<int> expected = new List<int> { 6, 15, 24, 21 };
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetSumTest_ColumnName_Revenue_PageSize_4_Returns_50_66_60()
        {
            //Assign
            var products = this.GetProducts();
            int pageSize = 4;
            string columnName = ColumnName.Revenue.ToString();
            //Act
            List<int> actual = products.Select(p => (int)p.GetType().GetProperty(columnName).GetValue(p, null)).GetSumByPagesize(pageSize, x => x).ToList();
            //Arrange
            List<int> expected = new List<int> { 50, 66, 60};
            CollectionAssert.AreEqual(expected, actual);
        }

        public IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                new Product {Id=1, Cost=1, Revenue=11, SellPrice=21 },
                new Product {Id=2, Cost=2, Revenue=12, SellPrice=22 },
                new Product {Id=3, Cost=3, Revenue=13, SellPrice=23 },
                new Product {Id=4, Cost=4, Revenue=14, SellPrice=24 },
                new Product {Id=5, Cost=5, Revenue=15, SellPrice=25 },
                new Product {Id=6, Cost=6, Revenue=16, SellPrice=26 },
                new Product {Id=7, Cost=7, Revenue=17, SellPrice=27 },
                new Product {Id=8, Cost=8, Revenue=18, SellPrice=28 },
                new Product {Id=9, Cost=9, Revenue=19, SellPrice=29 },
                new Product {Id=10, Cost=10, Revenue=20, SellPrice=30 },
                new Product {Id=11, Cost=11, Revenue=21, SellPrice=31 }
            };

            return products;
        }
    }

    public static class EnumerableExtension
    {
        public static IEnumerable<int> GetSumByPagesize<TSource>(this IEnumerable<TSource> source, int pagesize, Func<TSource, int> selector)
        {
            int index = 0;
            while (index <= source.Count())
            {
                yield return source.Skip(index).Take(pagesize).Sum(selector);
                index += pagesize;
            }
        }
    }
}