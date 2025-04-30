﻿using Application.Dtos.Default;

namespace Application.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> query, BaseGetRequest baseParams)
        {
            if (baseParams == null || baseParams.Page < 1 || baseParams.PageSize < 1)
            {
                return query;
            }

            return query.Skip((baseParams.Page - 1) * baseParams.PageSize).Take(baseParams.PageSize);
        }
    }
}
