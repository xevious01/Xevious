using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemieskabe : MonoBehaviour {
    public float speed = 1;     // 移動スピード


    // Use this for initialization
    void Start () {
        Vector2 direction = transform.up * -100;
        GetComponent<Rigidbody2D>().velocity = direction * speed;

    }
    //画面外に出たら消去
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
