using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlemanager : MonoBehaviour {
    public ParticleSystem par;

    void playParticle()
    {
        par.Play();
    }
}
