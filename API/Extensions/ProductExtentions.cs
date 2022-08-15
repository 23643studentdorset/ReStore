using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Extensions
{
    public static class ProductExtentions
    {
        public static IQueryable<Product> Sort(this IQueryable<Product> query, string orderBy) 
        {
            if (string.IsNullOrWhiteSpace(orderBy)) return query.OrderBy(p => p.name);
            query = orderBy switch 
            {
                "price" => query.OrderBy(p => p.price),
                "priceDesc" => query.OrderByDescending(p => p.price),
                _ => query.OrderBy(p => p.name)
            };
            return query;
        }

        public static IQueryable<Product> Search(this IQueryable<Product> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm)) return query;

            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();

            return query.Where(p => p.name.ToLower().Contains(lowerCaseSearchTerm));
        }

         public static IQueryable<Product> Filter(this IQueryable<Product> query, string brands, string types)
         {
             var brandList = new List<string>();
             var typeList = new List<string>();

             if (!string.IsNullOrEmpty(brands))
                brandList.AddRange(brands.ToLower().Split(",").ToList());

            if (!string.IsNullOrEmpty(types))
                typeList.AddRange(types.ToLower().Split(",").ToList());
            
            query = query.Where(p => brandList.Count == 0 || brandList.Contains(p.brand.ToLower()));
            query = query.Where(p => typeList.Count == 0 || typeList.Contains(p.type.ToLower()));

            return query;
         }
    }
}