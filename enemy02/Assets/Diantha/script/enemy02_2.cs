using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy02 : MonoBehaviour
{
    public float speed = 1;
    public GameObject expPrefab;    //爆発アニメーション用プレハブ
    public GameObject after;        //痕アニメーション用プレハブ
    public GameObject enemyBullet; 	// EnemyBulletプレハブ

    public bool isShoot;

    private Animator animator;

    int t;


    // Use this for initialization
    IEnumerator Start()
    {
        animator = GetComponent<Animator>();
        Vector2 direction = transform.up * -1;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        //while (true)
        //{
        // 弾を子オブジェクト（３つ分）の位置/角度で作成
        Instantiate(enemyBullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
        //  Instantiate(enemyBullet, transform.GetChild(1).position, transform.GetChild(1).rotation);
        //Instantiate(enemyBullet, transform.GetChild(2).position, transform.GetChild(2).rotation);
        // 2.0秒待つ(弾を発射する間隔になる)
        yield return new WaitForSeconds(2.0f);

        //}

    }
    // Update is called once per frame
    void Update()
    {
        if (t < 20)
        {
            isShoot = true;
        }
        if (isShoot == true && t > 20)
        {
            isShoot = false;
            //    t = 0;
        }
        GetComponent<Animator>().SetBool("isShoot", isShoot);
        t++;
    }

    //衝突したときに呼ばれる（IsTriggerにチェックが入っているとき）
    void OnTriggerEnter2D(Collider2D c)
    {
        animator.SetBool("e2kill", true);
        Instantiate(expPrefab, transform.position, transform.rotation);
        Instantiate(after, transform.position, transform.rotation);
        Destroy(c.gameObject);  //弾の削除
    }

}