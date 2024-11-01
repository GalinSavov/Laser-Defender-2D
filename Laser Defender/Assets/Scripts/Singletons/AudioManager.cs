using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [Header("Shooting")]
    [SerializeField] private AudioClip shootingAudioClip = null;
    [SerializeField][Range(0f, 1f)] private float shootingVolume = 1f;

    [Header("Taking Damage")]
    [SerializeField] private AudioClip damageAudioClip = null;
    [SerializeField][Range(0f,1f)] private float damageVolume = 1f;
    public void PlayShootingClip()
    {
        if(shootingAudioClip != null)
        AudioSource.PlayClipAtPoint(shootingAudioClip,Camera.main.transform.position,shootingVolume);
    }
    public void PlayDamageClip()
    {
        if(damageAudioClip != null)
        AudioSource.PlayClipAtPoint(damageAudioClip,Camera.main.transform.position,damageVolume);
    }
}
