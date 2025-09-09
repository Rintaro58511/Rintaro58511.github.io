using UnityEngine;
using System.Collections;

public class ImageManager : MonoBehaviour
{
    public float tiltAngle = 15.0f;  // 傾きの角度
    public float tiltSpeed = 2.0f;  // 傾きのスピード
    public float tiltDuration = 2.0f;  // 傾きが行われる時間
    public float waitTime = 3.0f;  // 元に戻ってから次に傾くまでの待機時間

    private Quaternion originalRotation;  // オブジェクトの元の回転角度

    void Start()
    {
        // オブジェクトの初期回転角度を記録
        originalRotation = transform.rotation;

        // コルーチンをスタート
        StartCoroutine(TiltRoutine());
    }

    IEnumerator TiltRoutine()
    {
        while (true)
        {
            // 一定時間待機
            yield return new WaitForSeconds(waitTime);

            // 傾き始める
            float elapsedTime = 0f;
            while (elapsedTime < tiltDuration)
            {
                float tilt = Mathf.Sin(elapsedTime * tiltSpeed) * tiltAngle;
                transform.rotation = Quaternion.Euler(0, 0, tilt);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // 元の回転に戻す
            transform.rotation = originalRotation;
        }
    }
}
