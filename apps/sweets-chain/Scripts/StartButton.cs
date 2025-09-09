using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    bool Clicked = false;
    public void OnClick()
    {
        if(!Clicked){
            StartCoroutine(LoadGameSceneAfterDelay(0.5f));
            Clicked = true;
        }
    }
    IEnumerator LoadGameSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GameScene");
    }
}
