using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies01 : MonoBehaviour
{
    public float speed = 1;
    public GameObject expPrefab; 	//爆発アニメーション用プレハブ
    public GameObject Enemies_bullet;  // EnemyBulletプレハブ
                                       // Use this for initialization
    public GameObject Player;
    // Use this for initialization
    bool A = false;
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
            if(iRandNum == 2)
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
    {/**/
        Transform TurnbackTransform = this.transform;
        Vector3 Turnback = TurnbackTransform.position;
        Turnback.x = 207;
       // Turnback.x = 0;
        Turnback.y = 50;
        
        /*Transform PlayerTransform = this.transform;
        Vector3 Player = PlayerTransform.position;*/
        
        // transformを取得
        Transform myTransform = this.transform;
        // 座標を取得
        Vector3 Rpos = myTransform.position;
        if (Rpos.y - Turnback.y <= 250)
        //if (Rpos.y - Player.y <= 100)
        {
            if (A == false)
            {
                Rpos.x -= 0.5f;    // x座標へ0.5加算
            }

             if (Rpos.x <= Turnback.x)
            //if (Rpos.x <= Player.x)

            {
                A = true;
            }

            if (A == true)//5>=5
            {
                Rpos.x += 1f;
                Rpos.y -= 0.5f;
            }

            myTransform.position = Rpos;  // 座標を設定
        }
    }
}
