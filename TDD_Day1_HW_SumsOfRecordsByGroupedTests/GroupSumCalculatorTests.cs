﻿using ExpectedObjects;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped.Tests
{
    [TestClass()]
    public class GroupSumCalculatorTests
    {
        private List<Product> products;

        [TestInitialize]
        public void InitializeDataSource()
        {
            products = new List<Product>()
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

        }

        [TestMethod()]
        public void SumByGroupedRecordsTest_Column_Cost_Records_3_Returns_6_15_24_21()
        {
            //Arrange
            GroupSumCalculator calculator = new GroupSumCalculator();
            int groupSize = 3;
            //Act
            var actual = calculator.SumByGroupedRecords(products, ColumnName.Cost, groupSize);

            //Assert
            var expected = new List<int>() { 6, 15, 24, 21 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod()]
        public void SumByGroupedRecordsTest_Column_Revenue_Records_4_Return_50_66_60()
        {
            //Arrange
            GroupSumCalculator calculator = new GroupSumCalculator();
            int groupSize = 4;

            //Act
            var actual = calculator.SumByGroupedRecords(products, ColumnName.Revenue, groupSize);

            //Assert
            var expected = new List<int>() { 50, 66, 60 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        public void SumByGroupedRecordsTest_Column_Revenue_Records_MaxInt_Return_176()
        {
            //Arrange
            GroupSumCalculator calculator = new GroupSumCalculator();
            int groupSize = int.MaxValue;

            //Act
            var actual = calculator.SumByGroupedRecords(products, ColumnName.Revenue, groupSize);

            //Assert
            var expected = new List<int>() { 176 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SumbyGroupedRecordsTest_Column_Any_Records_0_Return_InvalidException()
        {
            //Arrange
            GroupSumCalculator calculator = new GroupSumCalculator();
            int groupSize = 0;

            //Act
            var actual = calculator.SumByGroupedRecords(products, ColumnName.Revenue, groupSize);

            //Assert
            var expected = new List<int>() { 176 };
            expected.ToExpectedObject().ShouldEqual(actual);
        }


        [TestMethod]
        public void SumByGroupedRecordsTest_Column_Revenue_Records_MinInt_Return_InvalidException()
        {
            //Arrange
            GroupSumCalculator calculator = new GroupSumCalculator();
            int groupSize = int.MinValue;

            //Act
            Action actual = () => calculator.SumByGroupedRecords(products, ColumnName.Revenue, groupSize);

            //Assert
            var tt = actual.ShouldThrow<ArgumentOutOfRangeException>().WithMessage("*Please input between*");
        }
    }
}