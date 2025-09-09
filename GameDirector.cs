using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    float time = 0.0f;
    GameObject generator;
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        this.generator = GameObject.Find("Block_yGenerator");
        this.ball = GameObject.Find("ball 1");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pb = this.ball.transform.position;
        this.time += Time.deltaTime;
        if(this.time < 21.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(1,4.00f);
        else if(this.time < 25.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(5,6.00f);
        else if(this.time < 41.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(5,2.00f);
        else if(this.time < 45.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(9,6.00f);
        else if(this.time < 61.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(9,2.00f);
        else if(this.time < 65.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(14,6.00f);
        else if(this.time < 81.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(14,2.00f);
        else if(this.time < 85.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(17,6.00f);
        else if(this.time < 101.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(17,2.00f);
        else if(this.time < 105.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(19,6.00f);
        else if(this.time < 141.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(19,2.00f);
        else if(this.time < 145.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(25,6.00f);
        else if(this.time < 201.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(25,2.00f);
        else if(this.time < 205.00f) this.generator.GetComponent<Block_yGenerator>().SetParameter(29,6.00f);
        else this.generator.GetComponent<Block_yGenerator>().SetParameter(29,2.00f);
        if(pb.y<-4.79f) SaveTime();
    }
    public void SaveTime()
    {
        PlayerPrefs.SetFloat("GameTime", this.time);
        PlayerPrefs.Save(); // データを保存
    }
}