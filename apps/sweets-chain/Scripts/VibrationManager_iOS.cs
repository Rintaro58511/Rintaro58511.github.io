using System.Runtime.InteropServices;
using UnityEngine;

public class VibrationManager_iOS : MonoBehaviour
{
    // iOSのネイティブメソッドをインポート
    [DllImport("__Internal")]
    private static extern void _TriggerVibration(int strength);

    // 軽い振動
    public static void LightVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _TriggerVibration(1);  // Light振動
        }
    }

    // 中程度の振動
    public static void MediumVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _TriggerVibration(2);  // Medium振動
        }
    }

    // 強い振動
    public static void HeavyVibration()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            _TriggerVibration(3);  // Heavy振動
        }
    }
}
