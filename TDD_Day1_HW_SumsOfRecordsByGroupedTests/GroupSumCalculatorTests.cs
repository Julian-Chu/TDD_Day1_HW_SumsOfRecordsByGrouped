using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_Day1_HW_SumsOfRecordsByGrouped;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedObjects;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped.Tests
{
    [TestClass()]
    public class GroupSumCalculatorTests
    {
        List<Product> Products;
        [TestInitialize]
        public void InitializeDataSource()
        {
            Products = new List<Product>();

            for (int i = 1; i < 12; i++)
            {
                Products.Add(new Product() { Id = i, Cost = i, Revenue = 10 + i, SellPrice = 20 + i });
            }
        }
        [TestMethod()]
        public void SumByGroupedRecordsTest_Column_Cost_Records_3_Returns_6_15_24_21()
        {
            //Arrange
            GroupSumCalculator calc = new GroupSumCalculator();
            string ColumnName = "Cost";
            int RecordsToGroup = 3;
            //Act
            var actual=calc.SumByGroupedRecords(Products, ColumnName, RecordsToGroup);

            //Assert
            var expected = new List<int>() { 6, 15, 24, 21 };
            expected.ToExpectedObject().Equals(actual);
        }
    }
}