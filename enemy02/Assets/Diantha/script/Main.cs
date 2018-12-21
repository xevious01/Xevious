using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {
    int cnt = 0;
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = ""; //スタート時は空文字

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            GetComponent<AudioSource>().Play();
            if (cnt >= 50)
            {
                SceneManager.LoadScene("Main_Game");           //シーン「01」をロード
                cnt = 0;
            }
        }
        cnt++;
    }

}
