using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson1
{
    public class DealExtension
    {
        public record SumByMonth(DateTime Month, int Sum);

        public IList<string> GetNumberOfDeals(IEnumerable<Deal> deals)
        {
            var query = deals.Where(deal => deal.Sum >= 100)
                             .OrderBy(deal => deal.Date)
                             .Take(5)
                             .OrderByDescending(deal => deal.Sum)
                             .ToList();
            return query.Select(deal => deal.Id).ToList();
        }

        public IList<SumByMonth> GetSumByMonths(IEnumerable<Deal> deals)
        {
            var query = deals.GroupBy(deal => new DateTime(deal.Date.Year, deal.Date.Month, 1))
                             .Select(group => new SumByMonth(group.Key, group.Sum(deal => deal.Sum)))
                             .ToList();
            return query;
        }
    }
}
