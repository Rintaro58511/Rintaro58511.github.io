using UnityEngine;
using UnityEngine.Networking;
public class ShareManager : MonoBehaviour
{
    string stage;
    float recordedTime;
    void Start()
    {
        this.recordedTime = PlayerPrefs.GetFloat("GameTime", 0.0f);
        if(recordedTime < 4.0f)
        {
            this.stage = "？";
        }
        else if(recordedTime < 24.1f)
        {
            this.stage = "Stage 1";
        }
        else if(recordedTime < 44.2f)
        {
            this.stage = "Stage 2";
        }
        else if(recordedTime < 64.3f)
        {
            this.stage = "Stage 3";
        }
        else if(recordedTime < 84.3f)
        {
            this.stage = "Stage 4";
        }
        else if(recordedTime < 104.3f)
        {
            this.stage = "Stage 5";
        }
        else if(recordedTime < 144.3f)
        {
            this.stage = "Stage 6";
        }
        else if(recordedTime < 204.3f)
        {
            this.stage = "EXStage";
        }
        else{
            this.stage = "XStage";
        }
    }
    // Xへの共有
    public void ShareOnX()
    {
        string tweetText = "記録:"+stage+"\nTime:"+recordedTime+"\n#Ball Keeper";
        string url = "https://twitter.com/intent/tweet?text=" + UnityWebRequest.EscapeURL(tweetText);
        Application.OpenURL(url);
    }

    // Facebookへの共有
    public void ShareOnFacebook()
    {
        string shareURL = "http://www.yourgamewebsite.com";
        string message = "記録:"+stage+"\nTime:"+recordedTime;
        string url = "https://www.facebook.com/sharer/sharer.php?u=" + UnityWebRequest.EscapeURL(shareURL) + "&quote=" + UnityWebRequest.EscapeURL(message);
        Application.OpenURL(url);
    }

    // LINEへの共有
    public void ShareOnLINE()
    {
        string message = "記録:"+stage+"\nTime:"+recordedTime;
        string url = "https://line.me/R/share?text=" + UnityWebRequest.EscapeURL(message);
        Application.OpenURL(url);
    }
}
