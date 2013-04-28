using System;
using System.Collections.Generic;

namespace Memoize
{
    public static class Memoizer
    {
        public static Func<T, TResult> Memoize<T, TResult>(Func<T, TResult> func)
        {
            var cache = new Dictionary<T, TResult>();

            return p1 =>
                {
                    var key = p1;
                    TResult val;
                    if (!cache.TryGetValue(key, out val))
                    {
                        val = func(key);
                        cache.Add(key, val);
                    }
                    return val;
                };
        }

        public static Func<T1, T2, TResult> Memoize<T1, T2, TResult>(Func<T1, T2, TResult> func)
        {
            var memoizeViaTuple = Memoize<Tuple<T1, T2>, TResult>(tuple => func(tuple.Item1, tuple.Item2));
            return (p1, p2) => memoizeViaTuple(Tuple.Create(p1, p2));
        }

        public static Func<T1, T2, T3, TResult> Memoize<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> func)
        {
            var memoizeViaTuple = Memoize<Tuple<T1, T2, T3>, TResult>(tuple => func(tuple.Item1, tuple.Item2, tuple.Item3));
            return (p1, p2, p3) => memoizeViaTuple(Tuple.Create(p1, p2, p3));
        }

        // etc.
    }
}
