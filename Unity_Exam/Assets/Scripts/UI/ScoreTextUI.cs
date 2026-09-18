using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    // [BUG-11] 원인 : Scene 변경 시 GameManager._scoreText 참조 유실. / 수정 : ScoreText가 게임 시작 시 자신의 참조를 넘겨주도록 변경
    private void Start()
    {
        GameManager.Instance._scoreText = GetComponent<TextMeshProUGUI>();
    }
}
