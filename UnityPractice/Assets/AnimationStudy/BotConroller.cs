using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class BotConroller : MonoBehaviour
{

    private Animator _animator;

    public event Action<Vector2> OnMove;
    private Vector2 _prevMovement;

    private void Update()
    {
        SetMove();
    }
    
    private void SetMove()
    {
        Vector2 movement = GetMovement();

        // 이전 프레임의 Movement와 같으면 return;
        if (_prevMovement == movement) return;
        
        // 다르다면 OnMove 실행 + +prevMovement 갱신
        OnMove?.Invoke(movement);
        _prevMovement = movement;
    }

    private Vector2 GetMovement()
    {
        // 입력 받아서 Vector2 반환 GetAxisRaw
        // 단위벡터 x
        return new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

}
