using System;
using _Code.Utils;
using UnityEngine;
using UnityEngine.Audio;

namespace _Code.Core
{
    public class SoundManager : SingletonMono<SoundManager>
    {
        [SerializeField] private AudioSource sfxSource;

        private float _timeScale;

        public void Play(AudioClip clip, float volume = 1)
        {
            sfxSource.PlayOneShot(clip, volume);
        }

    }
}