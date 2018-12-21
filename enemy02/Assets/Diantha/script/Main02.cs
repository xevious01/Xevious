using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main02 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GetComponent<Text>().text = ""; //スタート時は空文字

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator GameOver()
    {
        GetComponent<Text>().text = "Game Over";  //表示文字変更
        yield return new WaitForSeconds(3.0f);  //3秒経ったら進む
        SceneManager.LoadScene("XEVIOUS_Title");           //シーン「01」をロード
    }

}
