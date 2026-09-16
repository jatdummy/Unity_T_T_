using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PracticeSwitcher : MonoBehaviour
{
    private const string SCENE_A = "StaticPracticeA";
    private const string SCENE_B = "StaticPracticeB";



    private void Update()
    {
        ReasScanKey();   
    }

    private void ReasScanKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveToOtherScene();
        }
    }

    private void MoveToOtherScene()
    {
        string currentName = SceneManager.GetActiveScene().name;
        string nextName = currentName == SCENE_A ? SCENE_B : SCENE_A;

        SceneManager.LoadScene(nextName);
    }
}
