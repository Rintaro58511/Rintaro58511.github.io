using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButtonManager : MonoBehaviour
{
    public GameObject NameDialog;
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            NameDialog.SetActive(false);
        });
    }
}
