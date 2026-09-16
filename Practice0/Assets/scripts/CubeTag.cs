using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTag : MonoBehaviour
{
    public static int _getTagCount =0;
    public static int _resetTagCount;
    private static int _tagCount;

    private int _myTag;

    private void Start()
    {

    }

    private void Awake()
    {
        TakeTag();
    }

    public static void ResetTagCount()
    {
        _tagCount = 0;

        Debug.Log("되돌렸습니다.");
    }

    private void TakeTag()
    {
        if (_tagCount != PracticeSettings.MaxTagCount)
        {
            _tagCount++;
            _myTag = _tagCount;
            Debug.Log($"CubeTag: 내 번호는 {_myTag}이고 지금까지 센 개수는 {_tagCount}입니다.");
        }
        else
        {
            Debug.Log($"상한에 닿았습니다");
        }

        _getTagCount = _tagCount;

    }
}
