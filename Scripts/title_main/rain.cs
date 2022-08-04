using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    public float speed;//落下速度

    public GameObject hajiki;


    ////prefab本体にも付けることで、遷移前の出現rainのままでいれる
    private void Awake()
    {
        //シーンを超えてもそのまま引き継ぐ
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        pos = this.transform.position;
        pos.y = pos.y - speed;
        this.transform.position = pos;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    //タグPlayerに接触で処理
    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Instantiate(hajiki, transform.position, transform.rotation);
        }        
    }

}
