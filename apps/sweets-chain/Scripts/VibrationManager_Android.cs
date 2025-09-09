using UnityEngine;

public class VibrationManager_Android : MonoBehaviour
{
    // Androidの軽い振動
    public static void LightVibration()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Vibrate(50, 50);  // 50msの軽い振動
        }
    }

    // Androidの中程度の振動
    public static void MediumVibration()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Vibrate(100, 100);  // 100msの中程度の振動
        }
    }

    // Androidの強い振動
    public static void HeavyVibration()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Vibrate(150, 255);  // 150msの強い振動
        }
    }

    // Androidの振動機能を呼び出すメソッド
    private static void Vibrate(long milliseconds, int amplitude)
    {
        using (AndroidJavaObject vibrationEffectClass = new AndroidJavaClass("android.os.VibrationEffect"))
        using (AndroidJavaObject context = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        using (AndroidJavaObject vibrator = context.Call<AndroidJavaObject>("getSystemService", "vibrator"))
        {
            if (SystemInfo.operatingSystem.StartsWith("Android 8"))
            {
                AndroidJavaObject vibrationEffect = vibrationEffectClass.CallStatic<AndroidJavaObject>("createOneShot", milliseconds, amplitude);
                vibrator.Call("vibrate", vibrationEffect);
            }
            else
            {
                vibrator.Call("vibrate", milliseconds);
            }
        }
    }
}
