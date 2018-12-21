using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies0102 : MonoBehaviour {

    public float speed = 1;
    public GameObject expPrefab; 	//爆発アニメーション用プレハブ
    public GameObject Enemies_bullet;  // EnemyBulletプレハブ
                                       // Use this for initialization
    public GameObject Player;
  //  public  GameObject.Find: PlayerMove{ }
    // Use this for initialization
    public int intelligence = 3;
    bool B = false;
    bool End = false;
    IEnumerator Start()
    {
        Vector2 direction = transform.up * -100;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        while (true)
        {
            int iRandNum = Random.Range(0, 3);
           
            if (iRandNum == 0)
            {
                
                yield return new WaitForSeconds(4.5f);
                // 弾を子オブジェクト（３つ分）の位置/角度で作成
                Instantiate(Enemies_bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
                // 2.0秒待つ(弾を発射する間隔になる)
            }
            if (iRandNum == 1)
            {
                break;
            }
            if (iRandNum == 2)
            {
                
                yield return new WaitForSeconds(3.0f);
                // 弾を子オブジェクト（３つ分）の位置/角度で作成
                Instantiate(Enemies_bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
                // 2.0秒待つ(弾を発射する間隔になる)
            }
        }

    }
    void OnTriggerEnter2D(Collider2D c)
    {
        GameObject.Find("ScoreText").SendMessage("ScoreUp");
        Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);        //敵を削除
        Destroy(c.gameObject);      //弾の削除
    }
    //画面外に出たら消去
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

        Transform TurnbackTransform = this.transform;
        Vector3 Turnback = TurnbackTransform.position;
        Turnback.x = 187;
        //Turnback.x = 0;
        Turnback.y = 50;

        /*
        Transform PlayerTransform = this.transform;
        Vector3 Player = PlayerTransform.position;
       // Player.x = 0;
*/
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 Lpos = myTransform.position;
        if (Lpos.y - Turnback.y <= 250)
        {
            if (B == false)
            {
                Lpos.x += 0.5f;
            }
            if (Lpos.x >= Turnback.x)
            //if (Lpos.x >= Player.x)
            {
                B = true;
            }

            if (B == true)//1<=5
            {
                Lpos.x -= 1f;    // x座標へ0.5加算
                Lpos.y -= 0.5f;
            }
            /* if (End == false && Lpos.y == -200)
             {
                 Lpos.x = -100;
                 Lpos.y = 200;
                 B = false;
             }*/

            myTransform.position = Lpos;  // 座標を設定
        }
    }
}
