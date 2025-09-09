using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RecordView : MonoBehaviour
{
    public TextMeshProUGUI RecordText;
    public int record = 0;
    public int score;
    public GameObject Cut_Animation_Button;
    public Cut_Animation cut_animation;
    // Start is called before the first frame update
    void Start()
    {
        RecordText.text="0";
        score = PlayerPrefs.GetInt("PlayerScore",0);
    }

    // Update is called once per frame
    void Update()
    {
        if(!cut_animation.Is_Counting){
            record = score;
            RecordText.text = record.ToString();
        }
        if(record < score){
            record += 5;
            RecordText.text = record.ToString();
        }
        if(record == score) Cut_Animation_Button.SetActive(false);
    }
}
