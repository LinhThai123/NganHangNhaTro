using NganHangNhaTro.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HakunaMatata.Helpers
{
    public class CustomPagination
    {
        public int CurrentItems { get; set; } = 0;
        public int TotalItems { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }

        //phan filter
        public string SearchString { get; set; }
        public int PriceRange { get; set; } = 0;
        public int AcreageRange { get; set; } = 0;
        public List<Result> Results { get; private set; }

        public CustomPagination(List<Result> items,
                                int count,
                                int pageIndex,
                                int pageSize,
                                string searchString,
                                int priceRange,
                                int dt)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalItems = count;
            CurrentItems = (pageIndex - 1) * pageSize + items.Count;
            Results = items;
            SearchString = searchString;
            PriceRange = priceRange;
            AcreageRange = dt;
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }


        public static async Task<CustomPagination> CreateAsync(IQueryable<Result> source, Condition con, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new CustomPagination(items,
                                        count,
                                        pageIndex,
                                        pageSize,
                                        con.SearchString,
                                        con.PriceRange,
                                        con.AcreageRange);
        }
    }
}
