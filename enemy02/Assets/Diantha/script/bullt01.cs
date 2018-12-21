using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class bullt01 : MonoBehaviour {
    public float speed = 1;

    // Use this for initialization
    void Start()
    {
        Vector2 direction = transform.up * 100;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }

    // Update is called once per frame
    void Update () {
        }
    void OnTriggerEnter2D(Collider2D c)
    {
        Destroy(gameObject);    //敵を削除
        Destroy(c.gameObject);  //弾の削除
    }

    //画面外に出たら消去
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}