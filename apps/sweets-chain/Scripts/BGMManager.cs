using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMManager : MonoBehaviour
{
    private static BGMManager instance = null;

    // BGMを保持するシーンのリストを設定 (GameSceneとRecordSceneのみ)
    public string[] scenesToKeepBGM = { "GameScene", "RecordScene" };

    public static BGMManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        // すでにインスタンスが存在している場合は、このオブジェクトを破壊
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        // インスタンスを設定し、シーンを跨いでも破壊しない
        instance = this;
        DontDestroyOnLoad(this.gameObject);

        // シーン変更時のイベントリスナーを追加
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // シーン変更時のイベントリスナーを解除
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // シーンがロードされたときに呼び出されるコールバック
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 現在のシーンが、BGMを継続したいシーンに含まれているかを確認
        if (ShouldKeepBGM(scene.name))
        {
            Debug.Log("Keep BGM playing in scene: " + scene.name);
        }
        else
        {
            // 対象外のシーンならBGMを停止し、オブジェクトを破壊
            Debug.Log("Stop BGM in scene: " + scene.name);
            Destroy(this.gameObject);
        }
    }

    // BGMを継続するシーンかどうかを判定
    private bool ShouldKeepBGM(string sceneName)
    {
        foreach (string scene in scenesToKeepBGM)
        {
            if (scene == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
