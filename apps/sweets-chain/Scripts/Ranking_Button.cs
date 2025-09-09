using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranking_Button : MonoBehaviour
{
    public GameObject RankingDialog;
    public void OnClick()
    {
        RankingDialog.SetActive(true);
    }
}
