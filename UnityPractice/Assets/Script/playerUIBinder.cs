using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class playerUIBinder : MonoBehaviour
{
    private TempPlayer _player;
    [SerializeField]private HealthGauge _healthgauge;
    [SerializeField]private TempPlayerUI _playerUI;
    [SerializeField] private ExpGauge _expGauge;
    private void Awake() => CacheCompotnents();
    private void OnEnable() => BindPlayerStatChangeEvents();
    private void OnDisable() => UnBindPlayerStatChangeEvents();


    private void BindPlayerStatChangeEvents()
    {
        _player.OnHealthChanged += _playerUI.RefreshHealthUI;
        _player.OnHealthChanged += _healthgauge.RefreshGauge;

        _player.Exp.AddListener(_expGauge.RefreshGauge);
    }

    private void UnBindPlayerStatChangeEvents()
    {
        _player.OnHealthChanged -= _playerUI.RefreshHealthUI;
        _player.OnHealthChanged -= _healthgauge.RefreshGauge;

        _player.Exp.RemoveListener(_expGauge.RefreshGauge);
    }
    private void CacheCompotnents()
    {
        _player = GetComponent<TempPlayer>();
    }
}
