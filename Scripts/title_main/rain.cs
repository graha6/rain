using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    public float speed;//�������x

    public GameObject hajiki;


    ////prefab�{�̂ɂ��t���邱�ƂŁA�J�ڑO�̏o��rain�̂܂܂ł����
    private void Awake()
    {
        //�V�[���𒴂��Ă����̂܂܈����p��
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

    //�^�OPlayer�ɐڐG�ŏ���
    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            this.gameObject.SetActive(false);
            Instantiate(hajiki, transform.position, transform.rotation);
        }        
    }

}
