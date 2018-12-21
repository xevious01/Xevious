using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E02_1 : MonoBehaviour
{

    public float speed = 1;
    public GameObject expPrefab; 	//爆発アニメーション用プレハブ
    public GameObject Enemies_bullet;  // EnemyBulletプレハブ
                                       // Use this for initialization

    public GameObject Player;

    public bool e2kill;
    public int atcnt;
    public bool atflg = false;

    private Animator animator;
    private Animator atcanim;

    //  public  GameObject.Find: PlayerMove{ }
    // Use this for initialization
    public int intelligence = 3;
    bool B = false;
    bool End = false;

    public int e2alive;
    void Start()
    {

        animator = GetComponent<Animator>();
        atcanim = GetComponent<Animator>();
        Vector2 direction = transform.up * -1;
        GetComponent<Rigidbody2D>().velocity = direction * speed;
        //atcanim.SetBool("isShoot", false);
        /*while (true)
        {
            // 弾を子オブジェクト（３つ分）の位置/角度で作成
            Instantiate(Enemies_bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(1).position, transform.GetChild(1).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(2).position, transform.GetChild(2).rotation);
            // 2.0秒待つ(弾を発射する間隔になる)
            yield return new WaitForSeconds(0.2f);
        }*/
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        e2kill = true;
        if (e2kill == true)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
        
            GetComponent<AudioSource>().Play();
        }
        GameObject.Find("ScoreText").SendMessage("ScoreUp2");
        animator.SetBool("e2kill", e2kill);
        Instantiate(expPrefab, transform.position, transform.rotation);
        Destroy(gameObject);        //敵を削除
        Destroy(c.gameObject);      //弾の削除
    }

    // Update is called once per frame
    void Update()
    {
        if(atflg == true)
        {
            // 弾を子オブジェクト（３つ分）の位置/角度で作成
            Instantiate(Enemies_bullet, transform.GetChild(0).position, transform.GetChild(0).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(1).position, transform.GetChild(1).rotation);
            Instantiate(Enemies_bullet, transform.GetChild(2).position, transform.GetChild(2).rotation);
            atflg = false;
        }
        if(atcnt >= 180)
        {
            atflg = true;
        }
        atcnt++;
    }
}
