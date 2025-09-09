using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HTP_Back : MonoBehaviour
{
    public GameObject How_to_playDialog;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            How_to_playDialog.SetActive(false);
        });
    }
}
