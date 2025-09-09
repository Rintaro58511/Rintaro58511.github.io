using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    public GameObject[] stage;
    float time=0f;
    float end=20.0f;
    int i=0;
    GameObject currentStageInstance;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        if(i==0){
        if(this.time > 0.7f){
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==1){
        if(this.time > this.end+3.0f){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==2){
        if(this.time > this.end){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==3){
        if(this.time > this.end){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==4){
        if(this.time > this.end-0.4f){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==5){
        if(this.time > this.end+0.2f){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==6){
        if(this.time > this.end*2){
            Destroy(currentStageInstance);
            currentStageInstance = Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            this.time=0f;
            i++;
        }
        }
        if(i==7){
        if(this.time > this.end*3){
            Destroy(currentStageInstance);
            Instantiate(stage[i],new Vector3(0,0.1f,0.0f),Quaternion.identity);
            i++;
        }
        }
    }
}
