using System.Linq.Expressions;
using System.Reflection;

namespace _01.MyFirstApi.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> RequestOrderBy<T>(this IQueryable<T> source, string propertyName, bool descending)
    {
        // Retrieve the property by reflection.
        var property = typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

        // If the property doesn't exist, throw an exception.
        if (property == null)
            throw new ArgumentException($"Property '{propertyName}' not found on type '{typeof(T)}'.");

        // Create the selector.
        var parameter = Expression.Parameter(typeof(T));
        var selector = Expression.Lambda<Func<T, object>>(Expression.Convert(Expression.Property(parameter, property), typeof(object)), parameter);

        // Construct the appropriate sort method and invoke it.
        var sortMethod = descending ? "OrderByDescending" : "OrderBy";
        var method = typeof(Queryable).GetMethods()
            .Where(x => x.Name == sortMethod && x.GetParameters().Length == 2)
            .Single()
            .MakeGenericMethod(typeof(T), typeof(object));

        return (IOrderedQueryable<T>)method.Invoke(null, new object[] { source, selector });
    }
}