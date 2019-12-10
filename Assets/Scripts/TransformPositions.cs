using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransformPositions : MonoBehaviour
{
    public GameObject prefab;
    public int positionNumber;
    public Transform[] pointList;

    void Start()
    {
        GameObject container = GameObject.Find("MovePoints");
        for(int i = 0; i < positionNumber; i++)
        {
            Instantiate(prefab, new Vector3(UnityEngine.Random.Range(0f, 5f), 0, UnityEngine.Random.Range(0f, 5f)), Quaternion.identity, container.transform);
        }


       

        
        

    }
    
}
