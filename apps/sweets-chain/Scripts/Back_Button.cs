using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back_Button : MonoBehaviour
{
    public GameObject RankingDialog;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            RankingDialog.SetActive(false);
        });
    }
}