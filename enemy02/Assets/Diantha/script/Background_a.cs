using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_a : MonoBehaviour {
    public float speed = 0.1f;  // スクロールするスピード
    private Renderer ren;           // rendererの格納用
    public float y;
    float tm;

    // Use this for initialization
    void Start () {
        ren = GetComponent<Renderer>();
        tm = Time.time;
    }

    // Update is called once per frame
    void Update () {
        y = Mathf.Repeat((Time.time -tm) * speed, 1);
        // Yの値がずれていくオフセットを作成
        Vector2 offset = new Vector2(0, y);
        // マテリアルにオフセットを設定する
        ren.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
