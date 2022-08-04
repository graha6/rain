using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    Animator anim;
    public float speed;

    public int action;      //0:mobが右進行
                            //1:mobが左進行

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;

        switch (action)
        {
            case 0:
                pos = this.transform.position;
                pos.x = pos.x + speed;
                anim.SetBool("right", true);
                if(pos.x > 800.0f)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = pos;
                break;

            case 1:
                pos = this.transform.position;
                pos.x = pos.x - speed;
                anim.SetBool("left", true);
                if (pos.x < -813.2f)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = pos;
                break;
        }
    }
}
