using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    private const string SCENE_GAME = "Game";
    // [BUG-04] 원인 : StartGame() 매서드를 호출하지 않았음 / 수정 : private void Update() {StatrGame();} 추가.
    private void Update()
    {
        StartGame();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SCENE_GAME);
    }
}
