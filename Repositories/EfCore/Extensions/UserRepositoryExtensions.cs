using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EfCore.Extensions
{ //implementasyon detayı içeren bir konu old. EFCore altında oluşturduk
    public static class UserRepositoryExtensions
    {
        public static IQueryable<User> Search(this IQueryable<User> books,
             string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return books;

            var lowerCaseTerm = searchTerm.Trim().ToLower();
            return books
                .Where(b => b.Name
                .ToLower()
                .Contains(searchTerm));
        }

       /* public static IQueryable<User> Sort(this IQueryable<User> users, string orderByQueryString)
        {
            if(string.IsNullOrWhiteSpace(orderByQueryString))
                return users.OrderBy(b => b.Name);

            var orderParams = orderByQueryString.Trim().Split(',');

            var propertyInfos = typeof(User).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];

                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty is null)
                    continue;

                var direction = param.EndsWith("desc") ? "descending" : "ascending";

                orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
            }
        }*/
    }
}
