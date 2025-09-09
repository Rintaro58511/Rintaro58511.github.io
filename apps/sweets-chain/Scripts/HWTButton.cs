using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HWTButton : MonoBehaviour
{
    public GameObject How_to_playDialog;
    public void OnClick()
    {
        How_to_playDialog.SetActive(true);
    }
}
