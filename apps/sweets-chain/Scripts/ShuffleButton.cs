using UnityEngine;

public class ShuffleButton : MonoBehaviour
{
    //public bool IsActive = true;
    
    public void OnClick()
    {
        // "sweets"タグが付いたすべてのオブジェクトを検索
        GameObject[] sweetsObjects = GameObject.FindGameObjectsWithTag("Sweets");
        // 各オブジェクトからRigidbody2Dを取得
        foreach (GameObject sweet in sweetsObjects)
        {
            Rigidbody2D rb2D = sweet.GetComponent<Rigidbody2D>();

            if (rb2D != null && sweet.transform.position.y < 2.0)
            {
                Debug.Log(sweet.name + " has a Rigidbody2D.");
                // Rigidbody2Dに対する操作をここで行う
                Vector2 randomDirection = new Vector2(Random.Range(-0.6f, 0.6f), 0f);
                rb2D.AddForce(randomDirection * 10f, ForceMode2D.Impulse);
            }
            else
            {
                Debug.Log(sweet.name + " does not have a Rigidbody2D.");
            }
        }
    }
    /*void Update()
    {
        if(!IsActive) gameObject.SetActive(false);
    }*/
}