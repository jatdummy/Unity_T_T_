using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TagReporter : MonoBehaviour
{
    private void Start()
    {
        ReportCount();
    }

    private void Update()
    {
        ResetCount();
    }

    private void ReportCount()
    {
        Debug.Log($"지금까지 센 개수는 {CubeTag._getTagCount} 개 입니다.");
    }

    private void ResetCount()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            CubeTag.ResetTagCount();
        }
    }


}
