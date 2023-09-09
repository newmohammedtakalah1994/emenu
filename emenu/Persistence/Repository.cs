using emenu.Core.Models.Helper;
using emenu.Core.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace emenu.Persistence
{
    public class Repository
    {
        public IQueryable<T> GetFilteredQuery<T>(IQueryable<T> query, object filters)
        {
            var properties = filters.GetType().GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(filters) != null)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        query = query.Where(t => EF.Functions.Like(typeof(T).GetProperty(property.Name).GetValue(t).ToString(), $"%{property.GetValue(filters)}%"));
                    }

                    if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                    {
                        query = query.Where(t => typeof(T).GetProperty(property.Name).GetValue(t) == property.GetValue(filters));
                    }

                    if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        if (property.Name == "CreatedAfter" || property.Name == "UpdatedAfter")
                            query = query.Where(t => (DateTime)property.GetValue(t) >= (DateTime)property.GetValue(filters));

                        if (property.Name == "CreatedBefore" || property.Name == "UpdatedBefore")
                            query = query.Where(t => (DateTime)property.GetValue(t) <= (DateTime)property.GetValue(filters));
                    }
                }
            }
            return query;
        }

        public IQueryable<T> GetOrderdQuery<T>(IQueryable<T> source, string orderBy, bool isDesc)
        {
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = orderBy.First().ToString().ToUpper() + orderBy.Substring(1); // convert it to Camal case
                var expression = source.Expression;
                int count = 0;
                var parameter = Expression.Parameter(typeof(T), "x");
                var selector = Expression.PropertyOrField(parameter, orderBy);
                var method = isDesc ?
                    (count == 0 ? "OrderByDescending" : "ThenByDescending") :
                    (count == 0 ? "OrderBy" : "ThenBy");
                expression = Expression.Call(typeof(Queryable), method,
                    new Type[] { source.ElementType, selector.Type },
                    expression, Expression.Quote(Expression.Lambda(selector, parameter)));
                count++;
                return count > 0 ? source.Provider.CreateQuery<T>(expression) : source;

               /* PropertyInfo property = type.GetProperty(orderBy);

                if (property != null) // if the property  is exist order by it
                    if (isDesc)
                        source = source.OrderByDescending((t) => property.GetValue(t));
                    else
                        source = source.OrderBy((t) => property.GetValue(t));
                return source;*/
            }
            else
            {               
                return source;
            }
        }

        public async static Task<PagedList<T>> GetPagedListAsync<T>(IQueryable<T> source, int pageNumber, int pageSize)
        {
            PagedList<T> pagedList = new PagedList<T>(source, pageNumber, pageSize);
            pagedList.List = await source
                       .Skip(pageSize * (pageNumber - 1))
                       .Take(pageSize)
                       .ToListAsync();
            return pagedList;
        }

    }
}
