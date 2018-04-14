using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
    public KeyCode yRightRotationActivationKey = KeyCode.D;
    public KeyCode yLeftRotationActivationKey = KeyCode.A;
    public KeyCode xRotationActivationKey = KeyCode.W;
    public float forceAmount = 10;
    public Vector3 rotationAxis = new Vector3(1, 0, 0);
    public GameObject childObject;
    Rigidbody body;
    Vector3 relYAxis;
    Vector3 relXAxis;
    Vector3 relZAxis;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody>();
        relYAxis = (childObject.transform.position - transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        relYAxis = (childObject.transform.position - transform.position).normalized;
        rotationAxis = relYAxis;
        if (Input.GetKeyDown(yRightRotationActivationKey))
        {
            body.AddTorque((relYAxis) * forceAmount, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(yLeftRotationActivationKey))
        {
            body.AddTorque((-relYAxis) * forceAmount, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(xRotationActivationKey))
        {
            body.AddTorque((Vector3.left) * forceAmount, ForceMode.Impulse);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + relYAxis);
    }
}
