using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolScript : MonoBehaviour
{
    public static PoolScript instance;
    public List<GameObject> pool = new List<GameObject>();
    public List<PoolObject> poolItems = new List<PoolObject>();
    private void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        return;
    }
    // Start is called before the first frame update
    void Start()
    {
        AddToPool();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddToPool()
    {
        foreach(PoolObject item in poolItems)
        {
            for(int i=0;i<item.amount;i++)
            {
               GameObject temp= Instantiate(item.gameObjectPrefab);
                temp.SetActive(false);
                pool.Add(temp);
            }
        }
    }
    public GameObject GetObjectFromPool(string tagname)
    {
        for(int i=0;i<pool.Count;i++)
        {
            if(pool[i].gameObject.tag=="astroid")
            {
                return pool[i];
            }
        }
        return null;
    }
}
[System.Serializable]
public class PoolObject
{
    public GameObject gameObjectPrefab;
    public int amount;
    
}
