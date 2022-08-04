using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{

    public float speed;

    public int action;

    // Start is called before the first frame update
    void Start()
    {
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
                if (pos.x > 800.0f)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = pos;
                break;

            case 1:
                pos = this.transform.position;
                pos.x = pos.x - speed;
                if (pos.x < -813.2f)
                {
                    gameObject.SetActive(false);
                }
                this.transform.position = pos;
                break;
        }
    }
}
