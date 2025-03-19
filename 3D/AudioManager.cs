using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource bgm_Player;
    private AudioSource sePlayer;
    private void Awake()
    {
        instance = this;
        bgm_Player = gameObject.AddComponent<AudioSource>();
        bgm_Player.loop = true;
        sePlayer = gameObject.AddComponent<AudioSource>();
    }
    public void Playbgm(string path)
    {
        if (bgm_Player.isPlaying == false)
        {
            AudioClip clip = Resources.Load<AudioClip>(path);
            bgm_Player.clip = clip;
            bgm_Player.Play();
        }
    }
    public void Stopbgm()
    {
        if (bgm_Player.isPlaying)
        {
            bgm_Player.Stop();
        }
    }
    public void PlaySE(string path)
    {
        AudioClip clip = Resources.Load<AudioClip>(path);
        sePlayer.PlayOneShot(clip);
    }
}
