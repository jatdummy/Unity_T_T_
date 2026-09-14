using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TempPlayer : MonoBehaviour
{
    // IntChange : 반환형이 없고, int 매개변수를 1개 받는 함수를 담아둘 수 있는 타입이다.
    // public delegate void IntChange(int value);
    // Action 활용하여 변환.
    public UnityEvent TempEvent; 
    private int _health;
    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChanged?.Invoke(_health);
        }
    }
    public event Action<int> OnHealthChanged;

    public ObservableProperty<float> Exp = new(0);

    private void OnEnable()
    {
        // TempEvent.AddListener();
        // TempEvent.RemoveListener();
        // TempEvent.RemoveAllListeners();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) TakeDamage(5);
        if (Input.GetKeyDown(KeyCode.Alpha2)) Heal(10);
        if (Input.GetKeyDown(KeyCode.Alpha3)) Exp.value += 20.5f;
        if (Input.GetKeyDown(KeyCode.Alpha4)) TempEvent?.Invoke();
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("크아아악");
        Health -= damage;
    }

    public void Heal(int heal)
    {
        Debug.Log("따뜻해..");
        Health += heal;
    }
}
