using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rainCtrl : MonoBehaviour
{

    private float time;�@        //rain�̏o���^�C��

    public GameObject rain, rain2;

    private float x, xx;

    public float Range_x;
    public float Range_x2;


    // Start is called before the first frame update
    void Start()
    {
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //�O�t���[��������Z���Ă���
        time += Time.deltaTime;
        //�����_�������͈�
        x = Random.Range(Range_x, Range_x2);

        //1�b�u���ɌĂ΂��
        if (time > 1)
        {
            Instantiate(rain, new Vector2(x, 490), transform.rotation);

            time = 0f;      //�o�ߎ��ԃ��Z�b�g
        }

        ////��L�ɕ��ׂ�Ɠ����ʒu�ɐ��������̂ŁA��������       
        time += Time.deltaTime;
        xx = Random.Range(Range_x, Range_x2);

        if (time > 1)
        {

            Instantiate(rain2, new Vector2(xx, 490), transform.rotation);

            time = 0f;
        }
    }
}
