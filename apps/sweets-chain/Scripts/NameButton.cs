using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameButton : MonoBehaviour
{
    public GameObject NameDialog;
    public void OnClick()
    {
        NameDialog.SetActive(true);
    }
}
