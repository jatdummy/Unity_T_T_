using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    private const string SCENE_GAME = "Game";

    [SerializeField] private GameObject _gameOverPanel;

    private void Start()
    {
        InitRound();
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        // [BUG-09] 원인 : ShowGameOver 에서 멈춘 시간이 안흘러감.
        // / 수정 : SceneManager.LoadScene(SCENE_GAME);
        SceneManager.LoadScene(SCENE_GAME);
        Time.timeScale = 1f;
    }

    private void InitRound()
    {
        GameManager.Instance.ResetScore();
        _gameOverPanel.SetActive(false);
    }
}
