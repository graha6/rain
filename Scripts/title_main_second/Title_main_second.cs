using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_main_second : MonoBehaviour
{
    Animator anim;
    public float speed;

    GameObject butler;

    bool isArrival;             //MoveTowards���ł��邩
    private float wTime;

    [SerializeField]
    private string load_scenename;//�V�[�����w��


    // Start is called before the first frame update
    void Start()
    {
        butler = GameObject.Find("butlerSpeak(Clone)");

        anim = butler.GetComponent<Animator>();

        butler.GetComponent<ButlerSpeak>().enabled = false;
        butler.GetComponent<playerCtrl>().enabled = false;

        isArrival = true;
        wTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;

        pos = butler.transform.position;
        if (isArrival) pos = Vector2.MoveTowards(pos, new Vector2(0, -112.1f), speed);

        //butler�̍��W���ȉ��l�����Ɍ��o�Aanim�̕����
        if (pos.x >= 0)
        {
            anim.SetBool("left", true);

        }
        else
        {
            anim.SetBool("right", true);

        }

        if (pos.x == 0)
        {
            anim.SetBool("left", false);

        }

        //�ӂ������butler
        wTime += Time.deltaTime;
        if (wTime > 4.0f)
        {
            anim.SetBool("right", true);
        }
        if (wTime > 4.5f)
        {
            anim.SetBool("right", false);
        }
        if (wTime > 6.5f)
        {
            isArrival = false;
            pos.x = pos.x - speed;
            anim.SetBool("left", true);
        }
        butler.transform.position = pos;

        if(pos.x < -766)
        {
            SceneManager.LoadScene(load_scenename);
            GameObject rainCtrl = GameObject.Find("rainCtrl");
            SceneManager.MoveGameObjectToScene(rainCtrl.gameObject, SceneManager.GetActiveScene());     //����
            SceneManager.MoveGameObjectToScene(butler.gameObject, SceneManager.GetActiveScene());       //�I�u�W�F�N�g�����p���̉���

        }
    }

}