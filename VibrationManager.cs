using UnityEngine;
using System.Runtime.InteropServices;

public class VibrationManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void TriggerHapticFeedback();

    public void Vibrate()
    {
        #if UNITY_IOS && !UNITY_EDITOR
        TriggerHapticFeedback();
        #endif
    }
}