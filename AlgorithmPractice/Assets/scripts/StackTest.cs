using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTest : MonoBehaviour
{
    private Stack<int> _stack = new();

    private void Start()
    {
        _stack.Push(5);
        _stack.Push(20);
        _stack.Push(35);

        Debug.Log(_stack.Peek());
        Debug.Log(_stack.Peek());
        Debug.Log(_stack.Peek());
        Debug.Log(_stack.Peek());
        Debug.Log(_stack.Peek());
        Debug.Log(_stack.Peek());
    }

}
