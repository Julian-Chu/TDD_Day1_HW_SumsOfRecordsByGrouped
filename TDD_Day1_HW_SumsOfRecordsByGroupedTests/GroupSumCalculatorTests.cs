using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ExpectedObjects;
using TDD_Day1_HW_SumsOfRecordsByGrouped;

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
            int RecordsToGroup = 3;
            //Act
            var actual=calc.SumByGroupedRecords(Products, ColumnName.Cost, RecordsToGroup);

            //Assert
            var expected = new List<int>() { 6, 15, 24, 21 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
        [TestMethod()]
        public void SumByGroupedRecordsTest_Column_Revenue_Records_4_Return_50_66_60()
        {
            //Arrange
            GroupSumCalculator calc = new GroupSumCalculator();
            int RecordsToGroup = 4;

            //Act
            var actual = calc.SumByGroupedRecords(Products,ColumnName.Revenue , RecordsToGroup);

            //Assert
            var expected = new List<int>() { 50, 66, 60 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}