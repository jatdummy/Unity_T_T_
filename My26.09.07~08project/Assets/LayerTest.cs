using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerTest : MonoBehaviour
{
    public LayerMask TargetLayer;
    public float Range;
    
    private void Start()
    {
        TargetLayer = TargetLayer.Add(9);
    }

    private GameObject go;


    private void OnTriggerEnter(Collider other)
    {
        if (TargetLayer.Contains(other))
        {
            Debug.Log("싸움을 걸어본다");
        }
    }
}
