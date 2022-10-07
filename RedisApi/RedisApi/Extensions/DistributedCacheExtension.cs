﻿using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace RedisApi.Extensions
{
    public static class DistributedCacheExtension
    {
        public static async Task SetReportAsync<T>
            (             
            this IDistributedCache cache,
            string recordKey,
            T data,
            TimeSpan? absoluteExpirationTime=null,
            TimeSpan? unusedExpirationTime=null)
        {
            var options=new DistributedCacheEntryOptions();
            options.AbsoluteExpirationRelativeToNow = absoluteExpirationTime ?? TimeSpan.FromSeconds(60);
            options.SlidingExpiration = unusedExpirationTime ;
            var jsonData=JsonSerializer.Serialize(data);
            await cache.SetStringAsync(recordKey,jsonData,options);
        }
        public static async Task<T> GetRecordAsync<T>(this IDistributedCache cache,string recordKey)
        {
            var jsonData = await cache.GetStringAsync(recordKey);
            if (jsonData is null)return default(T);
            return JsonSerializer.Deserialize<T>(jsonData);

        }
    }
}
