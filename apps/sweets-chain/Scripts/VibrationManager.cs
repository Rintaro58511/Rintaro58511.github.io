using UnityEngine;

public class VibrationManager : MonoBehaviour
{
    public static void VibrateLight()
    {
#if UNITY_IOS
        VibrationManager_iOS.LightVibration();  // iOSの軽い振動
#elif UNITY_ANDROID
        VibrationManager_Android.LightVibration();  // Androidの軽い振動
#endif
    }

    public static void VibrateMedium()
    {
#if UNITY_IOS
        VibrationManager_iOS.MediumVibration();  // iOSの中程度の振動
#elif UNITY_ANDROID
        VibrationManager_Android.MediumVibration();  // Androidの中程度の振動
#endif
    }

    public static void VibrateHeavy()
    {
#if UNITY_IOS
        VibrationManager_iOS.HeavyVibration();  // iOSの強い振動
#elif UNITY_ANDROID
        VibrationManager_Android.HeavyVibration();  // Androidの強い振動
#endif
    }
}
