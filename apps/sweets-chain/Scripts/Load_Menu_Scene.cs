using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Load_Menu_Scene : MonoBehaviour
{
    public void OnClick()
    {
        StartCoroutine(LoadGameSceneAfterDelay(0.10f));
    }
    IEnumerator LoadGameSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("MenuScene");
    }
}
