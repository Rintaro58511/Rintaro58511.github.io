using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockContoroller : MonoBehaviour
{
    Rigidbody2D rigid2D;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rigid2D.velocity = new Vector3(0f,-2.55f,0f);
        if(transform.position.y < -3.0f)
        {
            Destroy(gameObject);
        }
    }
}
