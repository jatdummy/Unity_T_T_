using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections.ObjectModel;

public class ObservableProperty<T>
{
    private Action<T> _onValueChanged;
    private T _value;
    public T value
    {
        get => _value;
        set
        {
            _value = value;
            Notify();
        }
    }

    public ObservableProperty(T initiaValue)
    {
        _value = initiaValue;
    }

    public void AddListener(Action<T> onValueChanged)
    {
        _onValueChanged += onValueChanged;
    }
    public void RemoveListener(Action<T> onValueChanged)
    {
        _onValueChanged -= onValueChanged;
    }

    public void RemoveAllListeners()
    {
        _onValueChanged = null;
    }

    public void Notify()
    {
        _onValueChanged?.Invoke(_value);
    }
}
