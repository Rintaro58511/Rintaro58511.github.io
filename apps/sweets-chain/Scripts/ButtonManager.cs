using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] Buttons;
    public AudioClip[] soundEffects;  // 再生する複数の効果音をセット
    private AudioSource audioSource;  // AudioSourceを使って効果音を再生

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnClick()
    {
        StartCoroutine(RemoveButton(Buttons));
    }
    IEnumerator RemoveButton(GameObject[] Buttons){
        for(int i=0;i<Buttons.Length;i++){
            audioSource.PlayOneShot(soundEffects[i]);
            if(i<6)
            Buttons[i].SetActive(false);
            else
            Buttons[i].SetActive(true);
            yield return new WaitForSeconds(0.042f);
        }
    }
}
