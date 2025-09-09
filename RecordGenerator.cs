using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordGenerator : MonoBehaviour
{
    public GameObject enpty_0;
    public GameObject enpty_1;
    public GameObject enpty_2;
    public GameObject enpty_3;
    public GameObject enpty_4;
    public GameObject enpty_5;
    public GameObject enpty_6;
    public GameObject enpty_7;
    public GameObject enpty_8;
    // Start is called before the first frame update
    void Start()
    {
        float recordedTime = PlayerPrefs.GetFloat("GameTime", 0.0f);
        if(recordedTime < 4.0f)
        {
            Instantiate(enpty_0,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 24.1f)
        {
            Instantiate(enpty_1,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 44.2f)
        {
            Instantiate(enpty_2,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 64.3f)
        {
            Instantiate(enpty_3,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 84.3f)
        {
            Instantiate(enpty_4,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 104.3f)
        {
            Instantiate(enpty_5,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 144.3f)
        {
            Instantiate(enpty_6,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else if(recordedTime < 204.3f)
        {
            Instantiate(enpty_7,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
        else{
            Instantiate(enpty_8,new Vector3(0,1.1f,0.0f),Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
