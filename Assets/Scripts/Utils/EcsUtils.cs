using Leopotam.EcsLite;

namespace Utils
{
    public static class EcsUtils
    {
        public static ref T AddOrGet<T>(this EcsPool<T> pool, int entity) where T : struct
        {
            if (!pool.Has(entity))
                pool.Add(entity);
            return ref pool.Get(entity);
        }
    }
}