using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banim : MonoBehaviour {

    public bool zflg = true;
    public bool bflg = true;
    public int zcnt = 0;
    public int bcnt = 0;

    private Animator animator;
    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("space") && bflg == true)      // Space
        {
            animator.SetBool("Ground", true);
            bflg = false;

            //GetComponent<AudioSource>().Play();

            //yield return new WaitForSeconds(0.05f);
        }
        if (bflg == false)
        {
            bcnt++;
            //animator.SetBool("Ground", true);
        }

        if (bcnt >= 70)
        {
            bflg = true;
            animator.SetBool("Ground", false);
            bcnt = 0;
        }

    }
}
