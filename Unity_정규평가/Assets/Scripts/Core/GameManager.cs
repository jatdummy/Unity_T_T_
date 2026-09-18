using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    public static GameManager Instance { get; private set; }

    public int Score => _score;

    private void Awake()
    {
        SetSingleton();
    }

    public void AddScore(int amount)
    {
        _score += amount;
        _scoreText.text = $"SCORE {_score}";
    }

    public void ResetScore()
    {
        _score = 0;
    }

    private void SetSingleton()
    {
        //[BUG-06] 원인 : 중복을 판별하지 않았음. / 수정 : if () 조건문 추가, 나중에 생긴 자신 파괴.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
