using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject player;       // Playerプレハブ
    private GameObject title;       // タイトル
    void Start()
    {
        title = GameObject.Find("Title");   // Titleオブジェクトを取得
    }
    void Update()
    {
        // ゲーム中ではなく、Xキーが押されたらtrueを返す。
        if (IsPlaying() == false && Input.GetKeyDown(KeyCode.Space))
        {
            GameStart();
        }
    }
    void GameStart()
    {
        // ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する
        title.SetActive(false);
        Instantiate(player, player.transform.position, player.transform.rotation);
    }
    public void GameOver()
    {
        title.SetActive(true);  // ゲームオーバー時に、タイトルを表示する
    }
    public bool IsPlaying()
    {
        return title.activeSelf == false;   // ゲーム中かをタイトルの表示で判断
    }
}

