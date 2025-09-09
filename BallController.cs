using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    Rigidbody2D rigid2D;
    GameObject player;
    public AudioClip blockSE;
    public AudioClip landSE;
    public AudioClip JumpSE;
    public AudioClip block_sSE;
    AudioSource aud;
    public VibrationManager vibrationManager;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate=60;
        rigid2D = GetComponent<Rigidbody2D>();
        rigid2D.velocity = new Vector3(2.0f,-2.0f,0f);
        this.player = GameObject.Find("Player");
        this.aud = GetComponent<AudioSource>();
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Block_y"){
            vibrationManager.Vibrate();
            this.aud.PlayOneShot(this.blockSE);
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Block_b"){
            vibrationManager.Vibrate();
            this.aud.PlayOneShot(this.blockSE);
        }
        if(other.gameObject.tag == "Block_bl"){
            this.aud.PlayOneShot(this.landSE);
        }
        if(other.gameObject.tag == "Block_s"){
            Handheld.Vibrate();
            this.aud.PlayOneShot(this.block_sSE);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 p1 = transform.position;
        Vector2 p2 = this.player.transform.position;
        Vector2 dir = p1-p2;
        if(dir.y<0.3f && Mathf.Abs(dir.x)<1.1f && dir.y>-0.3f){
            rigid2D.velocity = new Vector3((dir.x)*2.5f,Mathf.Sqrt(4.0f-(dir.x)*(dir.x))*2.5f,0f);
            this.aud.PlayOneShot(this.JumpSE);
        }
        if(p1.y>4.7f && rigid2D.velocity.y<0.1f && rigid2D.velocity.y>-0.1f){
            rigid2D.velocity = new Vector3(0f,-3.0f,0f);
        }
        if(p1.x>2.0f && Mathf.Abs(rigid2D.velocity.x)<0.1f && rigid2D.velocity.y>0f && p1.y>-3.0f){
            rigid2D.velocity = new Vector3(-1.0f,4.5f,0f);
        }
        if(p1.x<-2.0f && Mathf.Abs(rigid2D.velocity.x)<0.1f && rigid2D.velocity.y>0f && p1.y>-3.0f){
            rigid2D.velocity = new Vector3(1.0f,4.5f,0f);
        }
        if(p1.y<-4.8){
            Handheld.Vibrate();
            SceneManager.LoadScene("RecordScene");
        }
    }
}