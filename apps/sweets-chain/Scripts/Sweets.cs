using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweets : MonoBehaviour
{
    public string ID;
    public GameObject SelectSprite;
    public bool IsSelect { get; private set; }
    public bool isTouchable = true;
    private void OnMouseDown()
    {
        if (!isTouchable)
        {
            Debug.Log("This sweet cannot be touched.");
            return;
        }
        LevelManager.Instance.SweetsDown(this);
    }

    private void OnMouseEnter()
    {
        LevelManager.Instance.SweetsEnter(this);
    }

    private void OnMouseUp()
    {
        LevelManager.Instance.SweetsUp(this);
    }

    public void SetIsSelect(bool isSelect)
    {
        IsSelect = isSelect;
        SelectSprite.SetActive(isSelect);
    }
}
