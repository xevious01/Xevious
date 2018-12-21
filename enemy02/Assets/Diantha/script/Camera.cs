using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public float speed = 0.1f;  // スクロールするスピード
    private Renderer ren;			// rendererの格納用


    // Use this for initialization
    void Start () {
        ren = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update () {

        // 時間によってYを0から1に変化。1になったら0に戻り、繰り返す。
        float y = Mathf.Repeat(Time.time * speed, 1);
        // Yの値がずれていくオフセットを作成
        Vector2 offset = new Vector2(0, y);
        // マテリアルにオフセットを設定する
        ren.sharedMaterial.SetTextureOffset("_MainTex", offset);


    }
}
