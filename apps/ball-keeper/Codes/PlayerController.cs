using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    public float speed = 0.1f;  // 移動速度の調整
    private Vector2 startTouchPosition;  // タッチの開始位置
    private Vector2 currentTouchPosition;  // 現在のタッチ位置
    private bool isTouching = false;  // タッチ中かどうか
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate=60;
        Input.ResetInputAxes();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);  // 最初のタッチ情報を取得

            // タッチ開始時
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;  // タッチの開始位置を記録
                isTouching = true;
            }

            // タッチ中（指が動いている、または同じ位置にとどまっている）
            if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                currentTouchPosition = touch.position;  // 現在のタッチ位置を記録

                // 水平方向の移動量を計算
                float deltaX = currentTouchPosition.x - startTouchPosition.x;

                // オブジェクトのX位置を更新
                transform.position += new Vector3(deltaX * speed * Time.deltaTime, 0f, 0f);

                // 現在の位置を次のフレームの開始位置として更新
                startTouchPosition = currentTouchPosition;
            }

            // タッチ終了時
            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isTouching = false;
            }
        }
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -3.8f, 3.8f);

        // 制限後の位置を設定
        transform.position = clampedPosition;
    }
}