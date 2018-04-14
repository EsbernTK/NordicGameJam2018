using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainMover : MonoBehaviour {
    public float trainSpeed = 10f;
    public float timeToPlayer = 3f;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y,-(timeToPlayer * trainSpeed));
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.forward * trainSpeed * Time.deltaTime;
	}
}
