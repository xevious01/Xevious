using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float speed = 5;         // 移動スピード
    public bool zflg = true;        // 空攻撃のタイミング用フラグ
    public bool bflg = true;        // 地攻撃のタイミング用フラグ
    public int zcnt = 0;            // 空敵用カウント変数
    public int bcnt = 0;            // 地敵用カウント変数

    public GameObject bullet;
    public GameObject blaster;
    public GameObject expPrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    //IEnumerator Update () {
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");   // 右・左の入力
        float y = Input.GetAxisRaw("Vertical");         // 上・下の入力
        Vector2 direction = new Vector2(x, y).normalized;       // 移動する向きを求める
                                                                // 画面左下のワールド座標を取得
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        // 画面右上のワールド座標を取得
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 pos = transform.position;               // プレイヤーの座標を取得
        pos += direction * speed * Time.deltaTime;  // 移動量を加える
        pos.x = Mathf.Clamp(pos.x, (min.x + 10), (max.x - 10));   // プレイヤーのx位置を画面内で制限する
        pos.y = Mathf.Clamp(pos.y, (min.y + 10), (max.y - 13));       // プレイヤーのy位置を画面内で制限する
        transform.position = pos; 		// 制限をかけた値をプレイヤーの位置とする

        if (Input.GetKey("return") && zflg == true)     // Enter
        {
            Instantiate(bullet, transform.position, transform.rotation);
            zflg = false;
        }
        if (zflg == false)          // false: 発射不可
        {
            zcnt++;
        }
        if ( zcnt >= 18)            // true: 発射可
        {
            zflg = true;
            zcnt = 0;
        }
        if (Input.GetKey("space") && bflg == true)      // Space
        {
            // 弾をプレイヤーと同じ位置/角度で作成
            Instantiate(blaster, transform.position, transform.rotation);
            bflg = false;

        }
        if( bflg == false )     // false: 発射不可
        {
            bcnt++;
        }

        if (bcnt >= 100)        // true: 発射可
        {
            bflg = true;
            bcnt = 0;
        }

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        GetComponent<BoxCollider2D>().enabled = false;  //コライダーを無効化
        GameObject.Find("MainText").SendMessage("GameOver");
        Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(c.gameObject);
    }

}
