using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Random.Range(0,100)<1f)
        {
           // float x = Random.Range(-3.0f, 3.0f);
           GameObject temp= PoolScript.instance.GetObjectFromPool("astriod");
            temp.SetActive(true);
        }
        
    }
}
