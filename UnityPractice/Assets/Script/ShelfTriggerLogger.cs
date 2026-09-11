using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfTriggerLogger : MonoBehaviour
{
    private void OnTriggerEnter(Collider ohter)
    {
        Debug.Log($"ShelfTriggerLogger: {ohter.name}이 들어왔습니다.");
    }
}
