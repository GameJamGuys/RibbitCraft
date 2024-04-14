using System;
using System.Collections.Generic;
using _Code.Utils;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

namespace _Code.Core
{
    [Serializable]
    public class Sound
    {
        public SoundType type;
        public List<AudioClip> sfx = new List<AudioClip>();
    }

    [Serializable]
    public class Sounds
    {
        public List<Sound> sound = new List<Sound>();

        public AudioClip GetSoundByType(SoundType type)
        {
            foreach (var s in sound)
            {
                if (s.type == type)
                    return s.sfx[Random.Range(0,s.sfx.Count)];
            }

            return null;
        }
    }
    public enum SoundType
    {
        Pickup,
        PickupFail,
        Drop,
        FireLight,
        DropCrystal,
        Craft,
        CraftSuccess,
        CraftFail,
        OpenBook,
        FlipBook,
        Writing,
        UnlockNewComponent,
        Teeth,
        ClickButton,
        UnfocusButton
        
    }
    public class SoundManager : SingletonMono<SoundManager>
    {
        [SerializeField] private Sounds sounds;
        [SerializeField] private AudioSource sfxSource;

        private float _timeScale;

        public void Play(SoundType type, float volume = 1)
        {
            AudioClip sfx = sounds.GetSoundByType(type);
            if (sfx != null)
                Play(sfx, volume);
                
        }
        public void Play(AudioClip clip, float volume = 1)
        {
            sfxSource.PlayOneShot(clip, volume);
        }

        #if UNITY_EDITOR
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.F1))
                Play(SoundType.Pickup);
            if(Input.GetKeyDown(KeyCode.F2))
                Play(SoundType.PickupFail);
            if(Input.GetKeyDown(KeyCode.F3))
                Play(SoundType.Drop);
            if(Input.GetKeyDown(KeyCode.F4))
                Play(SoundType.FireLight);
        }
        #endif
    }
}