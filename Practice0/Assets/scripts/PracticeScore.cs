using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeScore : MonoBehaviour
{
    private int _point;
    
    public static PracticeScore Instance { get; private set; }

    public int Point => _point;

    private void Awake()
    {
        SetSingleton();
    }

    public void AddPoint(int amount)
    {
        _point += amount;

        Debug.Log($"PracticeScore: 점수가 {_point}이 되었습니다.");
    }


    private void SetSingleton()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

}

