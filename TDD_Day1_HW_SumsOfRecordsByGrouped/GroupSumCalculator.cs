using System.Collections.Generic;
using System.Linq;
using System;

namespace TDD_Day1_HW_SumsOfRecordsByGrouped
{
    /// <summary>
    /// 
    /// </summary>
    public class GroupSumCalculator
    {
        /// <summary>
        /// Input legal data source to get sum of each group
        /// </summary>
        /// <param name="products">Product</param>
        /// <param name="columnName">Column Name</param>
        /// <param name="numberOfRecords">how many records for each group</param>
        /// <returns> IEnumerable<int> </returns>
        public IEnumerable<int> SumByGroupedRecords(IEnumerable<Product> products, ColumnName columnName, int numberOfRecords)
        {
            if (!(numberOfRecords > 0))
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

        public IEnumerable<int> SumByPageSizeWithReflection(IEnumerable<Product> products, string columnName, int pageSize)
        {
            var targetClass = new Product();
            IEnumerable<string> properties = targetClass.GetType().GetProperties().Select(p=>p.Name);

            return null;
        }
    }
}