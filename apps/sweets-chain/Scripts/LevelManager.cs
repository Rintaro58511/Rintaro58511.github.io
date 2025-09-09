using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class LevelManager : MonoBehaviour
{
    private List<Sweets> _SelectSweets = new List<Sweets>();
    private string _SelectID = "";
    public int _Score = 0;
    public TextMeshProUGUI ScoreText;
    private float _CurrentTime = 10;
    public TextMeshProUGUI TimerText;
    public bool _IsPlaying = true;
    public float limit_time = 9;
    public static LevelManager Instance { get; private set; }
    public GameObject[] SweetsPrefab;
    int max_sweets_id = 4;
    public int SweetsDestroyCount = 3;
    public float SweetsConnectRange;
    public LineRenderer LineRenderer;
    public int up_1_Count = 4;
    public int up_2_Count = 6;
    public int up_3_Count = 9;
    public int up_4_Count = 12;
    public int up_5_Count = 15;
    public int up_6_Count = 18;
    public int limit_down_count = 0;
    //public AudioClip DestroySE;
    public AudioClip[] soundEffects;  // 再生する複数の効果音をセット
    private AudioSource audioSource;  // AudioSourceを使って効果音を再生
    public float aud_span_decrease = 0.2f;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        Instance = this;
        SweetsSpawn(32);
        //SweetsSpawn(48);
        ScoreText.text = "0";
        _CurrentTime = limit_time;
        /*audioSources = new AudioSource[3];
        for (int i = 0; i < audioSources.Length; i++)
        {
            audioSources[i] = gameObject.AddComponent<AudioSource>();
        }*/
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    IEnumerator PlaySoundEffectsWithDelay(int aud_count)
    {
    // aud_count が soundEffects の長さを超えていたら、最大の長さまでしか再生しないようにする
    int maxSounds = Mathf.Min(aud_count, soundEffects.Length);  // aud_count が soundEffects.Length を超えないように制限

    for (int i = 0; i < maxSounds; i++)
    {
        audioSource.PlayOneShot(soundEffects[i]);  // 効果音を再生
        yield return new WaitForSeconds(soundEffects[i].length - aud_span_decrease);  // 効果音の長さ - aud_span_decrease だけ待機
    }
    }
    // Update is called once per frame
    void Update()
    {
        LineRendererUpdate();
        TimerUpdate();

    }
    private void TimerUpdate()
    {
        if(_IsPlaying)
        {
            _CurrentTime -= Time.deltaTime;
            {
                if(_CurrentTime <= 0)
                {
                    SweetsSpawn(16);
                    _CurrentTime = limit_time;
                    limit_down_count++;
                    if(limit_down_count%10==0) limit_time--;
                }
                TimerText.text = ((int)_CurrentTime).ToString();
            }
        }
    }
    private void LineRendererUpdate()
{
    // 有効なスイーツ（nullではないもの）をリストから抽出
    var validSweets = _SelectSweets.Where(sweets => sweets != null && sweets.gameObject != null).ToList();

    // 有効なスイーツが2つ以上ある場合にのみLineRendererの位置を設定
    if (validSweets.Count >= 2)
    {
        LineRenderer.positionCount = validSweets.Count;
        LineRenderer.SetPositions(validSweets.Select(sweets => sweets.transform.position).ToArray());
        LineRenderer.gameObject.SetActive(true);
    }
    else
    {
        LineRenderer.gameObject.SetActive(false);
    }
}

    /*private void LineRendererUpdate()
    {
        if(_SelectSweets.Count >= 2){
            LineRenderer.positionCount = _SelectSweets.Count;
            LineRenderer.SetPositions(_SelectSweets.Select(sweets => sweets.transform.position).ToArray());
            LineRenderer.gameObject.SetActive(true);
        }
        else LineRenderer.gameObject.SetActive(false);
    }*/
    private void SweetsSpawn(int count)
    {
        var StartX = -1;
        var StartY = 5;
        var X=0;
        var Y=0;
        var MaxX = 3;

        for(int i=0; i<count; i++)
        {
            var Position = new Vector3(StartX+X,StartY+Y,0);
            Instantiate(SweetsPrefab[Random.Range(0,max_sweets_id)],Position,Quaternion.identity);
            X++;
            if(X==MaxX)
            {
                X=0;
                Y++;
            }
        }
    }
    public void SweetsDown(Sweets sweets)
    {
        if(!_IsPlaying) return;
        _SelectSweets.Add(sweets);
        sweets.SetIsSelect(true);

        _SelectID = sweets.ID;
    }
    public void SweetsEnter(Sweets sweets)
    {
        if(!_IsPlaying) return;
        if(_SelectID != sweets.ID) return;
        if(sweets.IsSelect)
        {
            if(_SelectSweets.Count >= 2 && _SelectSweets[_SelectSweets.Count -2] == sweets)
            {
                var RemoveSweets = _SelectSweets[_SelectSweets.Count -1];
                RemoveSweets.SetIsSelect(false);
                _SelectSweets.Remove(RemoveSweets);
            }
        }
        else
        {
            Renderer sweetsRenderer = sweets.GetComponent<Renderer>();

            if(sweetsRenderer != null)
            {
                Vector3 size = sweetsRenderer.bounds.size; // オブジェクトのサイズを取得
                float objectSize = size.magnitude;

                // オブジェクトのサイズに基づいてSweetsConnectRangeを動的に変更
                SweetsConnectRange = objectSize*0.82f;  // 例: サイズの0.5倍を接続範囲として設定
            }

            var Length = (_SelectSweets[_SelectSweets.Count -1].transform.position -sweets.transform.position).magnitude;
            if(Length < SweetsConnectRange)
            {
                _SelectSweets.Add(sweets);
                sweets.SetIsSelect(true);
            }
        }
    }
    public void SweetsUp(Sweets sweets)
    {
        if(!_IsPlaying) return;
        if(_SelectSweets.Count >= SweetsDestroyCount)
        {
            StartCoroutine(PlaySoundEffectsWithDelay(_SelectSweets.Count));
            List<Sweets> sweetsCopy = new List<Sweets>(_SelectSweets);  // リストのコピーを作成
            ManageSweetsCopy(sweetsCopy);
            DestroySweets(sweetsCopy);
            if(_SelectSweets.Count == SweetsDestroyCount){
                if(sweets.ID == "Cookie") AddScore(10);
                if(sweets.ID == "Chocolate") AddScore(20);
                if(sweets.ID == "Brownie") AddScore(50);
                if(sweets.ID == "Cupcake") AddScore(100);
                if(sweets.ID == "Ice-cream") AddScore(500);
                if(sweets.ID == "Donut") AddScore(2500);
                if(sweets.ID == "Piece-of-cake") AddScore(15000);
            }
            if(_SelectSweets.Count >= up_1_Count && _SelectSweets.Count < up_2_Count){
                Debug.Log("1_up");
                if(sweets.ID == "Cookie") Instantiate(SweetsPrefab[1],_SelectSweets[0].transform.position,Quaternion.identity);
                if(sweets.ID == "Chocolate") Instantiate(SweetsPrefab[2],_SelectSweets[0].transform.position,Quaternion.identity);
                if(sweets.ID == "Brownie") Instantiate(SweetsPrefab[3],_SelectSweets[0].transform.position,Quaternion.identity);
                if(sweets.ID == "Cupcake") Instantiate(SweetsPrefab[4],_SelectSweets[0].transform.position,Quaternion.identity);
                if(sweets.ID == "Ice-cream") Instantiate(SweetsPrefab[5],_SelectSweets[0].transform.position,Quaternion.identity);
                if(sweets.ID == "Donut") Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
            if(_SelectSweets.Count >= up_2_Count && _SelectSweets.Count < up_3_Count){
                Debug.Log("2_up");
                if(sweets.ID == "Cookie") Instantiate(SweetsPrefab[2],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Chocolate") Instantiate(SweetsPrefab[3],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Brownie") Instantiate(SweetsPrefab[4],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Cupcake") Instantiate(SweetsPrefab[5],_SelectSweets[0].transform.position,Quaternion.identity);
                else Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
            if(_SelectSweets.Count >= up_3_Count && _SelectSweets.Count < up_4_Count){
                Debug.Log("3_up");
                if(sweets.ID == "Cookie") Instantiate(SweetsPrefab[3],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Chocolate") Instantiate(SweetsPrefab[4],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Brownie") Instantiate(SweetsPrefab[5],_SelectSweets[0].transform.position,Quaternion.identity);
                else Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
            if(_SelectSweets.Count >= up_4_Count && _SelectSweets.Count < up_5_Count){
                Debug.Log("4_up");
                if(sweets.ID == "Cookie") Instantiate(SweetsPrefab[4],_SelectSweets[0].transform.position,Quaternion.identity);
                else if(sweets.ID == "Chocolate") Instantiate(SweetsPrefab[5],_SelectSweets[0].transform.position,Quaternion.identity);
                else Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
            if(_SelectSweets.Count >= up_5_Count && _SelectSweets.Count < up_6_Count){
                Debug.Log("5_up");
                if(sweets.ID == "Cookie") Instantiate(SweetsPrefab[5],_SelectSweets[0].transform.position,Quaternion.identity);
                else Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
            if(_SelectSweets.Count >= up_6_Count){
                Debug.Log("6_up");
                Instantiate(SweetsPrefab[6],_SelectSweets[0].transform.position,Quaternion.identity);
            }
        }
        else
        {
            foreach(var SweetsItem in _SelectSweets)
            SweetsItem.SetIsSelect(false);
        }
        _SelectID = "";
        _SelectSweets.Clear();
    }
    private void DestroySweets(List<Sweets> sweets)
    {
        StartCoroutine(DestroySweetsSequentially(sweets));  // スイーツを順番に破壊するコルーチンを開始
    }

    IEnumerator DestroySweetsSequentially(List<Sweets> sweets)
    {
        foreach (var sweet in sweets)
        {
            if (sweet != null && sweet.gameObject != null)
        {
            VibrationManager.VibrateLight();  // 振動を発生
            Renderer sweetRenderer = sweet.GetComponent<Renderer>();
            if (sweetRenderer != null)
            {
                sweetRenderer.enabled = false;  // スイーツの画像を非表示に
            }

            // 少し待ってからパーティクルを再生する
            yield return new WaitForSeconds(0.01f);  // 0.1秒待機してからパーティクルを再生

            // パーティクルエフェクトを再生
            ParticleSystem particleSystem = sweet.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();  // パーティクルを再生
            }
            yield return new WaitForSeconds(0.06f);  // 0.04秒待機
            Destroy(sweet.gameObject);  // オブジェクトを破壊
        }
        else
        {
            Debug.LogWarning("Attempted to destroy a null or already destroyed object.");
        }
        }
    }
    private void ManageSweetsCopy(List<Sweets> sweetsCopy)
    {
    foreach (var sweet in sweetsCopy)
    {
        if (sweet != null)
        {
            sweet.isTouchable = false;  // Prevent interaction with sweets in SweetsCopy
        }
    }
    }
    private void AddScore(int score)
    {
        _Score += score;
        if(score % 500 == 0 && limit_time < 7){
            limit_time++;
            Debug.Log("limit_time is" + limit_time);
        }
        ScoreText.text = _Score.ToString();
    }
}
