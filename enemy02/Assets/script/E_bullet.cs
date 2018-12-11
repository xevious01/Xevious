using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Rigidbody2D>().velocity
             = new Vector2(0, 3.0f);

    }

    // Update is called once per frame
    void Update () {

        Animator anim = GetComponent<Animator>();
        AnimatorStateInfo animInfo = anim.GetCurrentAnimatorStateInfo(0);


        if (animInfo.normalizedTime > 3.0f)
        {
            Destroy(gameObject);    //自分自身を消去する
        }

    }
}
