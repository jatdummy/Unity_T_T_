using UnityEngine;
using TMPro;

public class CoinCounterView : MonoBehaviour
{
    [SerializeField] private PlayerWallet _wallet;
    [SerializeField] private TextMeshProUGUI _coinText;

    private int _collectedCount;

    private void OnEnable()
    {
        BindWalletEvents();
    }
    // [BUG-07] 원인 : 걸어둔 event를 떼지 않아 중복 실행.  / 수정 : OnDisable()추가
    private void OnDisable()
    {
        UnBindWalletEvents();
    }

    private void Start()
    {
        UpdateText();
    }

    private void BindWalletEvents()
    {
        _wallet.OnCoinCollected += OnCoinCollected;
    }
    // [BUG-07] 원인 : 걸어둔 event를 떼지 않아 중복 실행.  / 수정 : UnBindWalletEvents 추가
    private void UnBindWalletEvents()
    {
        _wallet.OnCoinCollected -= OnCoinCollected;
    }


    private void OnCoinCollected()
    {
        _collectedCount++;
        UpdateText();
    }

    private void UpdateText()
    {
        _coinText.text = $"COIN {_collectedCount}";
    }
}
