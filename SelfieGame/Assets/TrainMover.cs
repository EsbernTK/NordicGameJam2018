using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour {
    public float trainSpeed = 10f;
    public float timeToPlayer = 3f;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(0-(timeToPlayer * trainSpeed),0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * trainSpeed * Time.deltaTime;
	}
}
