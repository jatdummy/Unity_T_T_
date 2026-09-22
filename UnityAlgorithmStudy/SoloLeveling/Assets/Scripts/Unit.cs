using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public void MoveTo(Vector3 position)
    {
        transform.position = position;
    }
}
