using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleChara : MonoBehaviour
{
    Animator anim, anim2;
    public int chara;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (chara)
        {
            case 0:
                anim.SetBool("right", true);
                break;
            case 1:
                //子オブジェクトの取得
                GameObject child = transform.Find("butler").gameObject;
                anim2 = child.GetComponent<Animator>();
                anim.SetBool("left", true);
                anim2.SetBool("left", true);
                break;
        }
    }
}
