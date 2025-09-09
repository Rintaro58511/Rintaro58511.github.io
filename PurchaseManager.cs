using UnityEngine;
using UnityEngine.Purchasing;

public class PurchaseManager : MonoBehaviour, IStoreListener
{
    private IStoreController storeController;

    void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("No_ads1453", ProductType.NonConsumable); // 商品IDとタイプ

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null;
    }

    public void BuyProduct(string productId)
    {
        if (IsInitialized())
        {
            Product product = storeController.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.LogError("商品が購入できません: " + productId);
            }
        }
        else
        {
            Debug.LogError("IAPが初期化されていません。");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAPの初期化に失敗しました: " + error);
    }
    public void OnInitializeFailed(InitializationFailureReason error,string message)
    {
        Debug.LogError("IAPの初期化に失敗しました: " + error);
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (args.purchasedProduct.definition.id == "No_ads1453")
        {
            Debug.Log("No Adsの購入が成功しました！");
            PlayerPrefs.SetInt("No_ads1453", 1);  // 広告を非表示にするフラグを保存
            PlayerPrefs.Save();
        }
        BannerAdManager bannerAdManager = FindAnyObjectByType<BannerAdManager>();
        if (bannerAdManager != null)
        {
            bannerAdManager.HideBannerAd();
        }
        NoAdsPurchase noadsPurchase = FindAnyObjectByType<NoAdsPurchase>();
        if (noadsPurchase != null)
        {
            noadsPurchase.HideNoAdsButton();
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.LogError($"購入に失敗しました: {reason}");
    }
}
