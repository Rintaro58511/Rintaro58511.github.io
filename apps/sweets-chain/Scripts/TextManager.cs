using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public float speed = 2.0f;  // オブジェクトの移動速度
    public float distance = 100.0f;  // 移動する範囲

    private Vector3 startPosition;

    void Start()
    {
        // オブジェクトの初期位置を記録
        startPosition = transform.position;
    }

    void Update()
    {
        // 上下にオブジェクトを動かす
        float newY = Mathf.Sin(Time.time * speed) * distance;
        transform.position = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);
    }
}