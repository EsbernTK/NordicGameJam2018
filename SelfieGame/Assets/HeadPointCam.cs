using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HeadPointCam : MonoBehaviour {
    Vector3 toCam;

    // Use this for initialization
	
	// Update is called once per frame
	void Update () {
        toCam = Camera.main.transform.position - transform.position;
        
        transform.LookAt( Camera.main.transform );
        transform.rotation *= Quaternion.Euler(0, 0, -90);
	}

}
