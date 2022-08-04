using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour
{

    private Animator anim;
    public float speed;

    public float posXclamp;         //制限範囲


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

            Clamp();    //移動制限
        }
        else
        {
            anim.SetBool("left", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * speed;
            anim.SetBool("right", true);

            Clamp();    //移動制限
        }
        else
        {
            anim.SetBool("right", false);
        }
    }

    //移動制限
    private void Clamp()
    {
        Vector2 pos;
        pos = this.transform.position;

        pos.x = Mathf.Clamp(pos.x, -posXclamp, posXclamp);

        this.transform.position = new Vector2(pos.x, -112.1f);
    }

}
