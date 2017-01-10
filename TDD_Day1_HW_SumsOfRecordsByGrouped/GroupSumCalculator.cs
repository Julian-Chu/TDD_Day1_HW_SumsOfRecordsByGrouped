using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    public class GroupSumCalculator
    {
        
        public List<int> SumByGroupedRecords(List<Product> products, ColumnName columnName, int numberOfRecords)
        {
            if(!(numberOfRecords > 0))
            {
                throw new ArgumentOutOfRangeException("Please input between 1 and " + int.MaxValue.ToString());
            }
            switch (columnName)
            {
                case ColumnName.Cost:
                    return products.GroupBy(p => (p.Id - 1) / numberOfRecords)
                        .Select(x => x.Select(v => v.Cost).Sum())
                        .ToList();

                case ColumnName.Revenue:
                    return products.GroupBy(p => (p.Id - 1) / numberOfRecords)
                        .Select(x => x.Select(v => v.Revenue).Sum())
                        .ToList();

                default:
                    return null;
            }
        }
    }
}