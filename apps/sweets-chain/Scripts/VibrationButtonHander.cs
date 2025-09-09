using UnityEngine;
using UnityEngine.UI;

public class VibrateButtonHandler : MonoBehaviour
{
    public void OnButtonClick()
    {
        Debug.Log("Light");
        // 軽い振動を発生
        VibrationManager.VibrateLight();
    }

    public void OnMediumButtonClick()
    {
        Debug.Log("Medium");
        // 中程度の振動を発生
        VibrationManager.VibrateMedium();
    }

    public void OnHeavyButtonClick()
    {
        // 強い振動を発生
        VibrationManager.VibrateHeavy();
    }
}
