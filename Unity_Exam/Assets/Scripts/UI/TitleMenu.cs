using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private const string SCENE_GAME = "Game";
    // [BUG-04] 원인 : EventSystem 누락 / 수정 : Eventsystem 추가.

    public void StartGame()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}
