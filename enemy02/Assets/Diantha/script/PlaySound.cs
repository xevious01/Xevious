using UnityEngine;
using System.Collections;

public class PlaySound : MonoBehaviour
{

    private AudioSource sound01;
    private AudioSource sound02;
    public int time = 0;
    void Start()
    {
        //AudioSourceコンポーネントを取得し、変数に格納
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sound01 = audioSources[0];
        sound02 = audioSources[1];
    }

    void Update()
    {
        if (time < 100)
        {
            sound01.PlayOneShot(sound01.clip);
        }
        else
        {
            sound02.PlayOneShot(sound02.clip);
        }
        time++;
    }
}