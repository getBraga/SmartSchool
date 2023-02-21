﻿using Microsoft.EntityFrameworkCore;

namespace SmartSchool.WebAPI.Helpers
{
    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList(List<T>items, int currentPage, int pageSize, int totalCount)
        {
            CurrentPage = currentPage;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            PageSize = pageSize;
            TotalCount = totalCount;
            this.AddRange(items);
        }
        public static async Task<PageList<T>> CreateAsync(
            IQueryable<T> source, int currentPage, int pageSize
            )
        {
            var totalCount = await source.CountAsync();
            var items = await source.Skip((currentPage - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToListAsync();
            return new PageList<T>(items, currentPage, pageSize, totalCount);
        }
    }
}
