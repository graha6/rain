using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class title_main_thirdCtrl : MonoBehaviour
{
    public GameObject butler, lady;
    public float speed;
    Animator anim, anim1;

    private float wTime;

    bool isMove, isStop;        //初動移動であるか
                                //stop中であるか

    public Camera cam;
    public GameObject fo;


    [SerializeField]
    private string load_scenename;//シーン名指定

    //GameObject rainCtrl;


    // Start is called before the first frame update
    void Start()
    {
        butler.transform.position = new Vector2(583, -112.1f);
        anim = butler.GetComponent<Animator>();
        anim1 = lady.GetComponent<Animator>();

        wTime = 0.0f;

        isMove = true;
        isStop = true;
    }

    private void Update()
    {
        cam.GetComponent<CameraCtrl>().Follow();

        Vector2 pos;
        pos = butler.transform.position;
        if (isMove)
        {
            pos.x = pos.x - speed;
            anim.SetBool("left", true);
        }

        //早送り
        if (pos.x < 410 && pos.x > -10)
        {
            speed = 2.0f;
        }
        //stop
        if (pos.x < -250.0f & isStop)
        {
            pos.x = -250.0f;
            anim.SetBool("left", false);
        }


        wTime += Time.deltaTime;
        //butlerと目が合う
        if (wTime > 8.0f)
        {
            anim1.SetBool("right", true);
        }
        if (wTime > 8.5f)
        {
            anim1.SetBool("right", false);
        }
        
        if (wTime > 11.0f)
        {
            cam.GetComponent<CameraCtrl>().Focus();
        }
        //butler近づく
        if (wTime > 15.0f)
        {
            isStop = false;
            if (pos.x < -420.0f)
            {
                pos.x = -420.0f;
                anim.SetBool("left", false);
            }
        }

        Vector2 pos1;
        pos1 = lady.transform.position;

        //lady移動
        if (wTime > 19.0f)
        {
            pos1.x = pos1.x + speed;
            anim1.SetBool("right", true);
        }
        //butler移動
        if (wTime > 19.8f)
        {
            cam.GetComponent<CameraCtrl>().Zoomout();

            isMove = false;
            pos.x = pos.x + speed;
            anim.SetBool("right", true);
        }
        butler.transform.position = pos;
        lady.transform.position = pos1;
        //フェードアウト
        if (wTime > 23.5f)
        {
            fo.GetComponent<FadeOut>().Fadeout();
        }

        if (wTime > 26.0f)
        {
            SceneManager.LoadScene(load_scenename);
        }
    }
}

