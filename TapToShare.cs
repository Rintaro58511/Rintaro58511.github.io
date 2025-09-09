using UnityEngine;

public class TapToShare : MonoBehaviour
{
    public GameObject snsOptionsPanel;  // SNS共有オプションパネル

    void OnMouseDown()
    {
        // タップされたときにSNS共有パネルを表示する
        if (snsOptionsPanel != null)
        {
            snsOptionsPanel.SetActive(true);  // 共有ボタンを含むパネルを表示
        }
    }
}
