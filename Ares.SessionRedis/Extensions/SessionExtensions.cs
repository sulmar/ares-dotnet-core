using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ares.SessionRedis.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson<T>(this ISession session, string key, T item)
        {
            // using System.Text.Json
            string json = JsonSerializer.Serialize(item);

            session.SetString(key, json);
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            string json = session.GetString(key);

            return json == null ? default(T) : JsonSerializer.Deserialize<T>(json);
        }
    }
}
