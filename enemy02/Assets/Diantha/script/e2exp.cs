using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e2exp : MonoBehaviour {

    public float speed = -1;

    // Use this for initialization
    void Start () {
        Vector2 direction = transform.up * -1;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
