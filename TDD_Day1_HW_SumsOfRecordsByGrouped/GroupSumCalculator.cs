using System.Collections.Generic;
using System.Linq;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    public class GroupSumCalculator
    {
        public List<int> SumByGroupedRecords(List<Product> products, ColumnName columnName, int numberOfRecords)
        {
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