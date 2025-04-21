//Useful for generic pooling, autoincrement, creating pools. Everything Useful to pool
//I've made that for gameObjects but change it as you wish.
//Fell free to use it, you are awesome
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public struct PoolHub
{
    public List<GameObject> hub;
    Func<GameObject, bool> defaultQuery;
        

    public PoolHub(GameObject prefabToUse, int listInitialSize = 10)
    {
        hub = new List<GameObject>();

        defaultQuery = (gameObject) => !gameObject.activeSelf;

        for (int i = 0; i <= listInitialSize; i++)
        {
            GameObject @object = UnityEngine.Object.Instantiate(prefabToUse);
            @object.SetActive(false);
            hub.Add(@object);
        }
    }

    public GameObject GetFromPool(Func<GameObject, bool> querySelector = null)
    {
        if(querySelector == null)
            querySelector = defaultQuery;

        GameObject returnO = (hub.Where(querySelector).Any()) ? hub.Where(querySelector).First() : null;

        //This is the Auto Increment.
        if (returnO == null)
        {
            returnO = UnityEngine.Object.Instantiate(hub.First());
            returnO.SetActive(false);
            hub.Add(returnO);
        }

        return returnO;
    }

    public T GetFromPool<T>(Func<GameObject, bool> querySelector = null) where T: Component
    {
        GameObject oj = GetFromPool(querySelector);
        T cachedComponent;
        if (oj.TryGetComponent<T>(out cachedComponent))
            return cachedComponent;
        
        return null;
    }
}