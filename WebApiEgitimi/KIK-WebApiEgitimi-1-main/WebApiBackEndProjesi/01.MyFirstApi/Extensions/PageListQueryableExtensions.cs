using _01.MyFirstApi.Dtos;
using Microsoft.EntityFrameworkCore;

namespace _01.MyFirstApi.Extensions;

public static class PageListQueryableExtensions
{ 
    public static PaginationResult<T> ToPagedList<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize)
        where T : class
    {
        var count = source.Count();
        if(count > 0 )
        {
            var items = source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new(items,pageNumber, pageSize,count);
        }
        else
        {
            return new(null,0,0,0);
        }
    }
}
