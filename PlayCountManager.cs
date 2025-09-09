using UnityEngine;

public class PlayCountManager : MonoBehaviour
{
    int playCount;

    private void Start()
    {
        // 保存されたプレイ回数を取得。デフォルトは0
        playCount = PlayerPrefs.GetInt("PlayCount", 0);
        Debug.Log("現在のPlayCount: " + playCount);
    }
    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            IncrementPlayCount();
        }
    }
    public void IncrementPlayCount()
    {
        playCount++;
        PlayerPrefs.SetInt("PlayCount", playCount);
        Debug.Log("プレイ回数が増加しました。現在のPlayCount: " + playCount);

        if (playCount >= 3)
        {
            ShowAdIfNeeded();
            playCount = 0; // カウントをリセット
            PlayerPrefs.SetInt("PlayCount", playCount);
        }
    }
    void ShowAdIfNeeded()
    {
    InterstitialAdManager interstitialAdManager = FindAnyObjectByType<InterstitialAdManager>();
    if (interstitialAdManager != null)
    {
        interstitialAdManager.ShowInterstitialAd();
    }
}

}
