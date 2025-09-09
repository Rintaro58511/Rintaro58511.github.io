using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    //public InterstitialAdManager interstitialAdManager;
    public void OnClick()
    {
        SceneManager.LoadScene("RecordScene");
    }
}
