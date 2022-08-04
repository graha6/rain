using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{

    private Animator anim;
    public float speed;

    public float posXclamp;         //�����͈�


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position -= transform.right * speed;
            anim.SetBool("left", true);

            Clamp();    //�ړ�����
        }
        else
        {
            anim.SetBool("left", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed;
            anim.SetBool("right", true);

            Clamp();    //�ړ�����
        }
        else
        {
            anim.SetBool("right", false);
        }
    }

    //�ړ�����
    private void Clamp()
    {
        Vector2 pos;
        pos = this.transform.position;

        pos.x = Mathf.Clamp(pos.x, -posXclamp, posXclamp);

        this.transform.position = new Vector2(pos.x, -112.1f);
    }

}
