using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {
    public GameObject[] waves;  // Waveプレハブを格納する
    private int currentWave;        // 現在のWave
    IEnumerator Start()
    {
        // Waveが存在しなければコルーチンを終了する
        if (waves.Length == 0)
        {
            yield break;
        }
        while (true)
        {
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, Quaternion.identity); // Waveを作成
            wave.transform.parent = transform;          // WaveをEmitterの子要素にする
                                                        // Waveの子要素のEnemyが全て削除されるまで待機する
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            Destroy(wave);          // Waveの削除
                                    // 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
    }
}
