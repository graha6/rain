using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class title_mainCtrl : MonoBehaviour
{
    public GameObject chara;    //butler
    GameObject charaObj;
    public float speed;
    Animator anim;

    bool isMove;                //����ȊO�̈ړ����ł��邩
    private float wTime;

    public GameObject messe, messe1, messe2, messe3;
    public GameObject rainCtrl;

    private void Awake()
    {
        //�V�[���𒴂��Ă����̂܂܈����p��
        DontDestroyOnLoad(rainCtrl.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        charaObj = Instantiate(chara, new Vector2(801.0f, -112.1f), transform.rotation);
        anim = charaObj.GetComponent<Animator>();

        wTime = 0.0f;

        this.GetComponent<Load_Scene_Name>().enabled = false;        //��^�b�v�h�~
        charaObj.GetComponent<playerCtrl>().enabled = false;
        messe1.SetActive(false);

        isMove = true;
    }

    void Update()
    {
        //butler�̓o��
        Vector2 pos;
        anim.SetBool("left", true);
        pos = charaObj.transform.position;
        if(isMove) pos.x = pos.x - speed;

        if (pos.x < 196.0f & isMove)
        {
            pos.x = 196.0f;         //stop
            anim.SetBool("left", false);
        }
        charaObj.transform.position = pos;

        //messeage�̕\��
        wTime += Time.deltaTime;
        if (wTime > 2.0f)
        {
            this.GetComponent<Load_Scene_Name>().enabled = true;
        }
        if (wTime > 4.5f)
        {
            messe.GetComponent<Messeage>().FadeIn();
        }
        if (wTime > 7.0f)
        {
            messe1.SetActive(true);
        }
        if (wTime > 9.0f)
        {
            messe2.GetComponent<Messeage>().FadeIn();
        }
        if (wTime > 11.5f)
        {
            messe3.GetComponent<Messeage>().FadeIn();
            isMove = false;                                        //�ȉ����\�ɂ��邽�߂�false
            charaObj.GetComponent<playerCtrl>().enabled = true;    //����m�F�\

        }
    }
}