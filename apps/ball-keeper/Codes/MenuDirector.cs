using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : MonoBehaviour
{
    public AudioClip StartSE;
    AudioSource aud;
    public VibrationManager vibrationManager;
    float disableTapDuration = 0.3f;
    private bool isTapDisabled = true;
    public GameObject[] targetObjects;
    private Animator[] targetAnimators;
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        StartCoroutine(EnableTapAfterDelay());
        targetAnimators = new Animator[targetObjects.Length];
        for (int i = 0; i < targetObjects.Length; i++)
        {
            if (targetObjects[i] != null)
            {
                targetAnimators[i] = targetObjects[i].GetComponent<Animator>();
            }
        }
    }

    // Update is called once per frame
    private bool isGameStarted = false;

    void Update()
    {
        if (isTapDisabled)
        {
            // タップが無効な間は、タップ入力を無視する
            return;
        }
    }
    void OnMouseDown()
        {
            for (int i = 0; i < targetAnimators.Length; i++)
            {
            if (targetAnimators[i] != null)
            {
                // トリガーを設定してアニメーションを再生
                targetAnimators[i].SetTrigger("StartAnimation");
                Debug.Log($"オブジェクト {targetObjects[i].name} のアニメーショントリガーが発火しました");
            }
            }
            if(!isGameStarted)
            StartCoroutine(StartGameAfterDelay(0.3f)); // 0.2秒後にゲームを開始するコルーチンを開始
            this.aud.PlayOneShot(this.StartSE);
            vibrationManager.Vibrate();
        }
    IEnumerator StartGameAfterDelay(float delay)
    {
        isGameStarted = true; // ゲーム開始フラグを立てる

        yield return new WaitForSeconds(delay); // 指定された秒数（0.2秒）待機

        StartGame(); // ゲームを開始するメソッドを呼び出す
    }
    private IEnumerator EnableTapAfterDelay()
    {
        // disableTapDuration秒待機
        yield return new WaitForSeconds(disableTapDuration);

        // タップを有効にする
        isTapDisabled = false;
    }
    void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
