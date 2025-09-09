using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut_Animation : MonoBehaviour
{
    public bool Is_Counting = true;
    public GameObject Cut_Animation_Button;
    public void OnClick()
    {
        Is_Counting = false;
        Cut_Animation_Button.SetActive(false);
    }
}
