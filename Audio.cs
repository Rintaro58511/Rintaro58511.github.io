using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip upSE;
    AudioSource aud;
    float time=0.0f;
    int i=0;
    // Start is called before the first frame update
    void Start()
    {
        this.aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if(i<6){
        if(this.time > 20.1f*i+4.0){
            this.aud.PlayOneShot(this.upSE);
            i++;
        }
        }
        if(time>144.0f && i==6){
            this.aud.PlayOneShot(this.upSE);
            i++;
        }
        if(time>204.0f && i==7){
            this.aud.PlayOneShot(this.upSE);
            i++;
        }
    }
}
