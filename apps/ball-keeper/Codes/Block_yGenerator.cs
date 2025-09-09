using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_yGenerator : MonoBehaviour
{
    public GameObject block_yPrefab;
    public GameObject block_bPrefab;
    public GameObject block_blPrefab;
    public GameObject block_sPrefab;
    float span = 4.0f;
    float delta = 0f;
    float[] px = {-1.8f,-0.9f,0.0f,0.9f,1.80f};
    int ratio=2;
    void Start(){
        Application.targetFrameRate=60;
    }
    public void SetParameter(int ratio,float span){
        this.ratio = ratio;
        this.span = span;
    }
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            Generate();
            this.delta = 0f;
        }
    }
    void Generate(){
        int px_idx = Random.Range(0,5);
        for(int i=0;i<5;i++){
            int dice = Random.Range(1,this.ratio);
            GameObject go;
            if(i!=px_idx){
                if(dice<3) go = Instantiate(block_yPrefab,new Vector3(px[i],5.0f,0.0f),Quaternion.identity);
                if(dice>=3 && dice<=12) go = Instantiate(block_bPrefab,new Vector3(px[i],5.0f,0.0f),Quaternion.identity);
                if(dice>12 && dice!=18 && dice!=17) go = Instantiate(block_blPrefab,new Vector3(px[i],5.0f,0.0f),Quaternion.identity);
                if(dice==18 || dice==17) go = Instantiate(block_sPrefab,new Vector3(px[i],5.0f,0.0f),Quaternion.identity);
            }
        }
    }
}
