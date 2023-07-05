using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace d04.Model
{
    public interface ISearchable
    {
        string Title { get; }
    }

    public static class EnumerableExtensions
    {
        public static T[] Search<T>(this IEnumerable<T> list, string search) where T : ISearchable
        {
            if (string.IsNullOrEmpty(search))
            {
                return list.ToArray();
            }

            string searchLower = search.ToLower();

            return list.Where(item => item.Title.ToLower().Contains(searchLower))
                .OrderBy(item => item.Title)
                .ToArray();
        }
    }

}
