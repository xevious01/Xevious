using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemies_03 : MonoBehaviour
{

    public float speed = 1;
    public GameObject expPrefab; 	//爆発アニメーション用プレハブ
    public GameObject Enemies_bullet;  // EnemyBulletプレハブ
                                       // Use this for initialization
    public GameObject Player;
    //  public  GameObject.Find: PlayerMove{ }
    // Use this for initialization
    public int intelligence = 3;
    bool A = false;
    bool B = false;
    IEnumerator Start()
    {
        Vector2 direction = transform.up * 100;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        while (true)
        {
            // 弾を子オブジェクト（３つ分）の位置/角度で作成
            Instantiate(Enemies_bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(1).position, transform.GetChild(1).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(2).position, transform.GetChild(2).rotation);
            // 2.0秒待つ(弾を発射する間隔になる)
            yield return new WaitForSeconds(2.0f);
        }

    }
    void OnTriggerEnter2D(Collider2D c)
    {
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

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 Lpos = myTransform.position;
        if (Lpos.y <= 400)
        {

           if (Lpos.x <= 90)
            {
                B = true;
                A = false;
            }
            if (Lpos.x >= 300)
             {
                A = true;
                B = false;
             }

            if(B == true )
            {
                Lpos.x += 1f;
                Lpos.y += 0.2f;
            }
             if ( A == true)
             {
                Lpos.x -= 1f;
                Lpos.y += 0.2f;
            }

        }
        myTransform.position = Lpos;  // 座標を設定
    }
}
