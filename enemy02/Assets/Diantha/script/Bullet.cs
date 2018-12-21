using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    public float speed = 250;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().velocity
            = transform.up * speed;

        Destroy(gameObject, 0.7f);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
