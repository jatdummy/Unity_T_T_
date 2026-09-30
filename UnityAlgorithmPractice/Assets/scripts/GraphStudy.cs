using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphStudy : MonoBehaviour
{

    private const int _vertexCount = 6;

    private string[] _names = { "입구", "복도", "창고", "광장", "우물", "탑" };
    
    // 인접리스트
    private List<int>[] _neighbors = new List<int>[_vertexCount];



    // [List<int>] [List<int>] [List<int>] [List<int>] [List<int>] 형식.

    // 인접행렬
    // private bool[,] _matrix = new bool[_vertexCount, _vertexCount];

    //      입 복 창 광 우 팀
    // 입구 0  1  0  0  0  0
    // 복도 1  0  1  0  0  0
    // 창고 0  0  0  1  0  0
    // 광장 0  1  1  0  0  0
    // 우물 0  0  0  1  0  1
    // 탑   0  0  0  1  1  0

    private void Start()
    {

        for( int i = 0;  i < _vertexCount; i++)
        {
            _neighbors[i] = new List<int>();
        }

        AddEdge(0, 1);
        AddEdge(1, 2);
        AddEdge(1, 3);
        AddEdge(2, 3);
        AddEdge(3, 4);
        AddEdge(3, 5);
        AddEdge(4, 5);


        for (int i = 0;  i < _vertexCount; i++)
        {
            PrintNeighbors(i);
        }
    }


    private void AddEdge(int a, int b)
    {
        _neighbors[a].Add(b);
        _neighbors[b].Add(a);





        // 인접행렬
        // _matrix[a, b] = true;
        // _matrix[b, a] = true;

    }

    private void PrintNeighbors(int vertax)
    {
        string print = "";

        // 인접리스트 
        foreach (int neighbor in _neighbors[vertax])
        {
            print += $"{_names[neighbor]}";
        }


        Debug.Log($"{_names[vertax]} 이웃 : {print} ");




        /* 인접행렬
        for (int i = 0; i < _vertexCount; i++)
        {
            if (_matrix[vertax, i])
            {
                print += $" {_names[i]}";
            }
        }
        */


    }




}
