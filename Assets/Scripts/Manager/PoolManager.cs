using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<GameManager>
{
    private Dictionary<string, object> _pools;

    public ObjectPool<T> GetObjectPool<T>(T objectPrefab, int initialSize = 0) where T : Component
    {
        string objectPrefabsKey = objectPrefab.GetInstanceID().ToString(); // 생성한 prefab를 기반으로한 고유의 키를 사용

        object pool;
        if (_pools.TryGetValue(objectPrefabsKey, out pool))
        {
            return pool as ObjectPool<T>;
        }
        else
        {
            ObjectPool<T> newPool = new ObjectPool<T>(objectPrefab, initialSize);
            _pools[objectPrefabsKey] = newPool;
            return newPool;
        }
    }

    public T GetObject<T>(T objectPrefab, Vector3 position, Quaternion rotation) where T : Component
    {
        ObjectPool<T> pool = GetObjectPool(objectPrefab);
        T obj = pool.GetObject();
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject<T>(T obj) where T : Component
    {
        ObjectPool<T> pool = GetObjectPool(obj);
        pool.ReturnObject(obj);
    }
}

