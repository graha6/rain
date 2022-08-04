using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sloperain : MonoBehaviour
{
    public float xspeed, yspeed;//óéâ∫ë¨ìx

    public GameObject hajiki;

    // Start is called before the first frame update
    void Start()
    {
        transform.eulerAngles = new Vector3(0, 0, -30);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos;
        pos = this.transform.position;
        pos.x = pos.x - xspeed;
        pos.y = pos.y - yspeed;
        this.transform.position = pos;


    }
    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    //É^ÉOPlayerÇ…ê⁄êGÇ≈èàóù
    private void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            Instantiate(hajiki, transform.position, transform.rotation);
        }
    }
}

