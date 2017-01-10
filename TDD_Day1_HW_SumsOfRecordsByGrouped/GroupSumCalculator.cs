using System.Collections.Generic;
using System.Linq;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    public class GroupSumCalculator
    {
        public List<int> SumByGroupedRecords(List<Product> products, string columnName, int numberOfRecords)
        {
            switch (columnName)
            {
                case "Cost":
                    return products.GroupBy(p => (p.Id - 1) / numberOfRecords)
                        .Select(x => x.Select(v => v.Cost).Sum())
                        .ToList();

                case "Revenue":
                    return products.GroupBy(p => (p.Id - 1) / numberOfRecords)
                        .Select(x => x.Select(v => v.Revenue).Sum())
                        .ToList();

                default:
                    return null;
            }
        }
    }
}