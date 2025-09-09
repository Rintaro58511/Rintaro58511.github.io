using UnityEngine;
using System.Runtime.InteropServices;

public class ShareButton : MonoBehaviour
{
    // 外部関数の宣言（Objective-C側で定義した関数）
    [DllImport("__Internal")]
    private static extern void _ShareText(string text);
    string stage;
    float recordedTime;
    void Start()
    {
        this.recordedTime = PlayerPrefs.GetFloat("GameTime", 0.0f);
        if(recordedTime < 4.0f)
        {
            this.stage = "?";
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
    public void OnMouseDown()
    {
        // 共有するテキスト
        string shareMessage = "通勤通学中や、オンラインゲームの待ち時間で出来る超簡単暇潰しゲーム\nBall Keeper(ボールキーパー)\n"+"記録 : "+stage+"\nTime : "+recordedTime.ToString();
        
        // iOSの共有機能を呼び出す
        _ShareText(shareMessage);
    }
}
