using UnityEngine;
using System.Collections.Generic;

public class ObjectPool<T> where T : Component
{
    private Queue<T> pool = new Queue<T>();
    private T prefab;
    private Transform parent;
    
    public ObjectPool(T prefab, Transform parent = null, int initialSize = 10)
    {
        this.prefab = prefab;
        this.parent = parent;
        
        for (int i = 0; i < initialSize; i++)
        {
            CreateNewInstance();
        }
    }
    
    private void CreateNewInstance()
    {
        T instance = Object.Instantiate(prefab, parent);
        instance.gameObject.SetActive(false);
        pool.Enqueue(instance);
    }
    
    public T Get()
    {
        if (pool.Count == 0)
        {
            CreateNewInstance();
        }
        
        T instance = pool.Dequeue();
        instance.gameObject.SetActive(true);
        return instance;
    }
    
    public void Return(T instance)
    {
        if (instance != null)
        {
            instance.gameObject.SetActive(false);
            pool.Enqueue(instance);
        }
    }
    
    public void Clear()
    {
        while (pool.Count > 0)
        {
            T instance = pool.Dequeue();
            if (instance != null)
            {
                Object.Destroy(instance.gameObject);
            }
        }
    }
} 