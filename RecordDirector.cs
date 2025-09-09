using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecordDirector : MonoBehaviour
{
    public AudioClip BackSE;
    public AudioClip MenuSE;
    AudioSource aud;
    float playbackTime = 0.30f; // 再生時間（秒）
    float playTime = 0.02f; // 再生時間（秒）
    public VibrationManager vibrationManager;
    float disableTapDuration = 0.3f;  // タップを無効にする時間（秒）
    private bool isTapDisabled = true;       // タップが無効かどうかを示すフラグ

    public void PlayMenuSE()
    {
        aud.clip = MenuSE;
        StartCoroutine(StartMenuSEAfterTime(playTime));
        // 指定した時間後に停止
        StartCoroutine(StopMenuSEAfterTime(playbackTime));
    }
    IEnumerator StartMenuSEAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        aud.Play();
    }
    IEnumerator StopMenuSEAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        aud.Stop();
    }
    // Start is called before the first frame update
    void Start()
    {
        aud = GetComponent<AudioSource>();
        StartCoroutine(EnableTapAfterDelay());
        PlayMenuSE();
    }
    private bool isGameStarted = false;
    // Update is called once per frame
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
            if(!isGameStarted)
            StartCoroutine(StartGameAfterDelay(0.3f)); // 0.2秒後にゲームを開始するコルーチンを開始
            this.aud.PlayOneShot(this.BackSE);
            vibrationManager.Vibrate();
        }
    private IEnumerator EnableTapAfterDelay()
    {
        // disableTapDuration秒待機
        yield return new WaitForSeconds(disableTapDuration);

        // タップを有効にする
        isTapDisabled = false;
    }
    IEnumerator StartGameAfterDelay(float delay)
    {
        isGameStarted = true; // ゲーム開始フラグを立てる
        yield return new WaitForSeconds(delay); // 指定された秒数（0.2秒）待機

        StartGame(); // ゲームを開始するメソッドを呼び出す
    }
    void StartGame()
    {
        //PlayerPrefs.Save(); 
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
