using UnityEngine;
using UnityEngine.Purchasing;

public class NoAdsPurchase : MonoBehaviour
{
    public PurchaseManager purchaseManager;  // PurchaseManagerを参照
    void Start()
    {
        if (PlayerPrefs.GetInt("No_ads1453", 0) == 1)
        {
            Destroy(gameObject);
        }
    }
    void OnMouseDown()
    {
        // タップされたときに購入処理を呼び出す
        if (purchaseManager != null)
        {
            Debug.Log("NoAdsオブジェクトがタップされました。購入処理を開始します。");
            purchaseManager.BuyProduct("No_ads1453");  // "no_ads"はIAP Catalogで設定した商品ID
        }
        else
        {
            Debug.LogError("PurchaseManagerが見つかりません。");
        }
    }
    public void HideNoAdsButton()
    {
        Destroy(gameObject);
    }
}
