using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleCtrl : MonoBehaviour
{
    public GameObject chara, chara1;     //butler,lady+butler                          
    public float speed;                  // �ړ����x

    private GameObject charaObj;          // �L�����N�^����p
    private GameObject charaObj1;         // �L�����N�^����p
    private float wTime;                 // ���Ԍv�Z�p

    private int state;                   // 0:wait(2s) & butler�ړ�����
                                         // 1:butler�ړ�
                                         // 2:wait(20s) & lady+butler�ړ�����
                                         // 3:lady+butler�ړ�
    public GameObject titlename;
    private int title;

    // Start is called before the first frame update
    void Start()
    {
        charaObj = Instantiate(chara, new Vector2(-813.2f, -112.1f), transform.rotation);    // �I�u�W�F�N�g����
        charaObj.SetActive(false);                       // �\��OFF
        charaObj1 = Instantiate(chara1, new Vector2(800.0f, -163.5f), transform.rotation);   // �I�u�W�F�N�g����
        charaObj1.SetActive(false);                      // �\��OFF
        wTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;

        ////�������[�v
        switch (state)
        {
            case 0:                                     // wait(2s) & butler�ړ�����
                wTime += Time.deltaTime;                // �o�ߎ��Ԍv�Z
                if (wTime > 4.0f)                       // �҂����ԃ`�F�b�N
                {
                    state = 1;                          // ���X�e�[�^�X�֑J��
                    wTime = 0.0f;                       // �o�ߎ��ԃN���A
                    charaObj.SetActive(true);            // �\��ON
                }
                break;
            case 1:                                     // butler�ړ�
                pos = charaObj.transform.position;       // Position�擾
                pos.x = pos.x + speed;                  // �ʒu�v�Z
                if (pos.x > 800.0f)                     // �I�[�`�F�b�N
                {
                    charaObj.SetActive(false);           // �\��OFF
                    pos.x = -813.2f;                    // �����ʒu�ɖ߂�
                    state = 2;                          // ���X�e�[�^�X�֑J��
                }
                charaObj.transform.position = pos;       // Position�ݒ�
                break;
            case 2:                                     // wait(20s) & lady+butler�ړ����� 
                wTime += Time.deltaTime;                // �o�ߎ��Ԍv�Z
                if (wTime > 10.0f)                      // �҂����ԃ`�F�b�N
                {
                    state = 3;                          // ���X�e�[�^�X�֑J��
                    wTime = 0.0f;                       // �o�ߎ��ԃN���A
                    charaObj1.SetActive(true);           // �\��ON
                }
                break;
            case 3:                                     // lady+butler�ړ�
                pos = charaObj1.transform.position;      // Position�擾
                pos.x = pos.x - speed;                  // �ʒu�v�Z
                if (pos.x < -813.2f)                    // �I�[�`�F�b�N
                {
                    charaObj1.SetActive(false);          // �\��OFF
                    pos.x = 800.0f;                     // �����ʒu�ɖ߂�
                    state = 0;                          // �n�߂ɕԂ�
                }
                charaObj1.transform.position = pos;      // Position�ݒ�
                break;
        }
        switch (title)
        {
            case 0:
                pos = titlename.transform.position;
                pos.y = pos.y - 0.5f;
                if (pos.y < -3.0f)
                {
                    title = 1;
                }
                titlename.transform.position = pos;
                break;
            case 1:
                pos = titlename.transform.position;
                pos.y = pos.y + 0.5f;
                if (pos.y > 3.0f)
                {
                    title = 0;
                }
                titlename.transform.position = pos;
                break;
        }
    }
}