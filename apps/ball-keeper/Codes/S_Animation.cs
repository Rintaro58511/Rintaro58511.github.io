using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Animation : MonoBehaviour
{
    private Animator animator;
    private float time = 0f;
    private int i=1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime;
        if (time > 20.0f*i+2.0f &&i<=5)
        {
            // アニメーションのTriggerパラメータをセットする
            animator.SetTrigger("StartAnimation");
            i++;
        }
        if(time>142.0f && i==6){
            animator.SetTrigger("StartAnimation");
            i++;
        }
        if(time>202.0f && i==7){
            animator.SetTrigger("StartAnimation");
            i++;
        }
    }
}
