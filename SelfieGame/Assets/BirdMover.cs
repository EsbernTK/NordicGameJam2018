using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMover : MonoBehaviour {
    public float patrolLength = 15;
    public float patrolSpeed = 1;
    float time = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(time >= patrolLength / patrolSpeed)
        {
            time = 0;
            transform.rotation = Quaternion.Lerp( transform.rotation, transform.rotation * Quaternion.Euler(0, 180, 0), 1);
        }
        transform.position += -transform.forward * patrolSpeed * Time.deltaTime;
        time += Time.deltaTime;
	}
}
