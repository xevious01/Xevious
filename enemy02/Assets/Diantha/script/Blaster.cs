using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Blaster : MonoBehaviour
{
    public float speed = 15;
    public PlayerMove PlayerMove;
    public int dcnt;

    // private Collider pcollider;

    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity
            = transform.up * speed;
        /*if (dcnt >= 90 && dcnt <= 100)
        {
            GetComponent<PolygonCollider2D>().enabled = true;
        }
        if(dcnt > 100)
        {
            dcnt = 0;
        }*/

        Destroy(gameObject, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        dcnt++;
    }
}
