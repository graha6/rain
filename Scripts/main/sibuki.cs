using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sibuki : MonoBehaviour
{
    public GameObject hajiki;

    int size;           //0:�g��
                        //1:�k��

    public float speed;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Vector2 scale;
        switch (size)
        {
            case 0:
                scale = transform.localScale;
                scale.x = scale.x + 0.01f;
                scale.y = scale.y + 0.01f;
                if (scale.x > 0.8f)
                {
                    size = 1;
                }
                transform.localScale = scale;
                break;
            case 1:
                scale = transform.localScale;
                scale.x = scale.x - 0.01f;
                scale.y = scale.y - 0.01f;
                if (scale.x < 0.6f)
                {
                    size = 0;       //�߂�
                }
                transform.localScale = scale;
                break;

        }


    }

    //�^�OPlayer�ɐڐG�ŏ���
    private void OnTriggerStay2D(Collider2D player)
    {

        if (player.gameObject.tag == "Player")
        {
            Instantiate(hajiki, transform.position, transform.rotation);
            spr.color = Color.Lerp(spr.color, Color.clear, speed);
            Invoke("Col", 0.05f);
        }
    }
    void Col()
    {
        GetComponent<EdgeCollider2D>().enabled = false;   //����ȏ�쓮���Ȃ��悤�ɔ�����A�N�e�B�u��

    }
}
