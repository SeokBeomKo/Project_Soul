using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
    private Queue<T> _poolQueue;
    private T _objectPrefab;

    public ObjectPool(T objectPrefab, int initialSize = 0)
    {
        _poolQueue = new Queue<T>();

        _objectPrefab = objectPrefab;

        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(objectPrefab);
            obj.gameObject.SetActive(false);
            _poolQueue.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (_poolQueue.Count > 0)
        {
            T obj = _poolQueue.Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            T obj = Object.Instantiate(_objectPrefab);
            return obj;
        }
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        _poolQueue.Enqueue(obj);
    }
}

