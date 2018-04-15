using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    [System.Serializable]
    public class AudioEffect{
        public string effectName;
        public AudioSource a_Source;
        public AudioClip a_clip;
        public bool playing;
        public float startAtSeconds;
        public void PlayEffect()
        {
            a_Source.PlayOneShot(a_clip);
        }
    }

    public List<AudioEffect> audioEffects;
    public void Start()
    {
        foreach(AudioEffect sound in audioEffects)
        {
            
            sound.PlayEffect();
        }
    }
    public void Update()
    {
        foreach (AudioEffect sound in audioEffects)
        {

            sound.PlayEffect();
        }
    }
}
