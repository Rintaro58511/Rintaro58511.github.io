using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block_bController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    int cnt=0;
    public Sprite block_b_b;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Ball")
            this.cnt++;
            if(cnt==1){
                sr.sprite = block_b_b;
            }
            if(cnt==2){
                Destroy(gameObject);
                cnt=0;
            }
    }
    // Update is called once per frame
    void Update()
    {
        rigid2D.velocity= new Vector3(0f,-2.55f,0f);
        if(transform.position.y < -3.0f)
        {
            Destroy(gameObject);
        }
    }
}
