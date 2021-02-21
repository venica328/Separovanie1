using UnityEngine;
using System.Collections.Generic;

public class PoolOptimalize : MonoBehaviour
{
    public static PoolOptimalize instance;

    public ItemsInPool[] itemsIntoPool;

    private List<GameObject> itemsFromPool;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null) instance = this;

        itemsFromPool = new List<GameObject>();

        foreach (ItemsInPool item in itemsIntoPool)
        {
            for (int i = 0; i < item.poolCount; i++)
            {
                GameObject obj = Instantiate(item.poolObject);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                itemsFromPool.Add(obj);

            }
        }
        
    }

    public GameObject GetObjectFromPool(string name)
    {
        for (int i = 0; i < itemsFromPool.Count; i++)
        {
            if(itemsFromPool[i].activeInHierarchy == false && itemsFromPool[i].name == name)
               return itemsFromPool[i];
        }

        foreach (ItemsInPool item in itemsIntoPool)
        {
            if(item.poolObject.name == name)
            {
                GameObject obj = Instantiate(item.poolObject);
                obj.name = item.name;
                obj.transform.parent = this.transform;
                obj.SetActive(false);
                itemsFromPool.Add(obj);
                return obj;
            }

        }

        return null;
    }
}

[System.Serializable]
public class ItemsInPool
{
    public int poolCount;
    public string name;
    public GameObject poolObject;
    public bool shouldExpland;
}
