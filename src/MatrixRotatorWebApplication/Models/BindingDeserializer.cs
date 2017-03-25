using System;
using System.Collections.Generic;

namespace MatrixRotatorWebApplication.Models
{
    public static class BindingDeserializer
    {
        private static readonly Dictionary<Type, Func<string, object>> Deserizlizers
            = new Dictionary<Type, Func<string, object>>();

        static BindingDeserializer()
        {
            RegisterDeserializer(data => int.TryParse(data, out int i) ? i : (int?)null);
            RegisterDeserializer(data => data);
        }

        public static T Deserialize<T>(string data)
            => (T)Deserizlizers[typeof(T)](data);

        public static void RegisterDeserializer<T>(Func<string, T> deserializer)
            => Deserizlizers[typeof(T)] = data => deserializer(data);
    }
}