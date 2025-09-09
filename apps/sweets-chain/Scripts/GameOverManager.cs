using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    private float collisionTime = 0f;
    private bool isColliding = false;
    public GameObject FinishDialog;
    public LevelManager levelmanager;
    public GameObject shufflebutton;
    public GameObject Timer;
    public GameObject Score;
    public AdmobUnitInterstitial interstitial;
    public GameObject Warning;
    private bool Ad_showed = false;
    private Collider2D currentCollider; // 現在衝突しているオブジェクトを追跡するための変数

    // 衝突が始まった時に呼ばれる
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentCollider == null) // もしまだ衝突中のオブジェクトがない場合
        {
            currentCollider = collision; // 衝突したオブジェクトを追跡
            isColliding = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
{
    if (Ad_showed || collision == null) return;

    if (isColliding && collision == currentCollider) // 同じオブジェクトとの衝突を確認
    {
        collisionTime += Time.deltaTime;

        if (collisionTime >= 2.0f) // 警告表示の開始タイミング
            Warning.transform.position = new Vector3(0f, 12f - 4f * (collisionTime - 2f), 0f);

        if (collisionTime >= 5f) // 5秒後にゲームオーバー
        {
            GameOver();
        }
    }
}


    void OnTriggerExit2D(Collider2D collision)
{
    if (Ad_showed) return;

    // 衝突しているオブジェクトが同じで、かつオブジェクトが存在している場合のみリセット
    if (collision != null && collision == currentCollider)
    {
        Warning.transform.position = new Vector3(0f, 12f, 0f);
        isColliding = false;
        collisionTime = 0f; // 衝突時間をリセット
        currentCollider = null; // 現在の衝突オブジェクトをクリア
    }
}

    // ゲームオーバー処理
    void GameOver()
    {
        if (!Ad_showed)
        {
            Debug.Log("Game Over!");
            PlayerPrefs.SetInt("PlayerScore", levelmanager._Score);
            PlayerPrefs.Save();
            Warning.SetActive(false);
            FinishDialog.SetActive(true);
            shufflebutton.SetActive(false);
            Timer.SetActive(false);
            Score.SetActive(false);
            levelmanager._IsPlaying = false;
            interstitial.ShowInterstitial();
            Ad_showed = true;
        }
    }
}
