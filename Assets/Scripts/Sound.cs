using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public static Sound instance;
    public AudioSource src1;
    public AudioSource src2;
    public AudioSource src3;
    public AudioSource src4;
    public AudioSource src5;
    public AudioSource src6;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void ButtonPressSound()
    {
        src1.Play();
    }
    public void BookDropped()
    {
        src2.Play();
    }
    public void BoilingWater(int index)
    {
        if (index == 1)
            src3.Play();
        else
            src3.Stop();
    }
    public void Dryer(int index)
    {
        if (index == 1)
            src4.Play();
        else
            src4.Stop();
    }
    public void GameMusic(int index)
    {
        if (index == 1)
            src5.Play();
        else
            src5.Stop();
    }
    public void CoinSound()
    {
        src6.Play();
    }
}
