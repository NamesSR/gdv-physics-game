using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class targetspawn : MonoBehaviour
{
    public GameObject spawn;
    public Transform[] spawnpoint;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < spawnpoint.Length; i++)
        {
            Instantiate(spawn, spawnpoint[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
