using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lady : MonoBehaviour
{
    public float speed;
    public float Range_x, Range_x1;     //�s���͈�
    float time;
    Animator anim;

    Vector2 movepos;

    [SerializeField]
    private string load_scenename;

    public GameObject fo;            //������v���C�I�����̃t�F�[�h�A�E�g
    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        movepos = RandomPos();          //�n�߂ɖړI�ʒu�ݒ�
        time = 0.0f;


    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        time += Time.deltaTime;
        pos = this.transform.position;

        //1.5�b�u���ɌĂ΂��
        if (time > 1.5f)
        {
            if (movepos == pos)
            {
                movepos = RandomPos();
            }
            time = 0.0f;
        }
        pos = Vector2.MoveTowards(pos, movepos, speed);

        //���݈ʒu�ƖړI�ʒu���r������
        if (pos.x < movepos.x)
        {
            anim.SetBool("right", true);
        }
        else
        {
            anim.SetBool("right", false);
        }
        if (pos.x > movepos.x)
        {
            anim.SetBool("left", true);
        }
        else
        {
            anim.SetBool("left", false);
        }
        this.transform.position = pos;
    }

    ////X���W�������_���ɐݒ�
    Vector2 RandomPos()
    {
        Vector2 randompos = new Vector2(Random.Range(Range_x, Range_x1), -162);
        return randompos;
    }

    private void OnTriggerStay2D(Collider2D rain)
    {
        if (rain.gameObject.tag == "Rain")
        {
            fo.GetComponent<FadeIn>().enabled = false;
            alpha += 3f * Time.deltaTime;
            fo.GetComponent<Image>().color = new Color(0, 0, 0, alpha);
            Invoke("Toscene", 2);
        }
    }
    void Toscene()
    {
        SceneManager.LoadScene(load_scenename);
    }
}
