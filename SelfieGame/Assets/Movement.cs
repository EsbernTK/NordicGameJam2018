using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {
    public KeyCode yRotationActivationKey = KeyCode.Q;
    public KeyCode xRotationActivationKey = KeyCode.W;
    public KeyCode ownAxisRotationActivationKey = KeyCode.A;
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
        relYAxis = -(childObject.transform.position - transform.position).normalized;
    }
	
	// Update is called once per frame
	void Update () {
        relYAxis = (childObject.transform.position - transform.position).normalized;
        rotationAxis = relYAxis;
        if (Input.GetKey(yRotationActivationKey))
        {
            //body.AddRelativeForce((Vector3.forward + Vector3.up) * forceAmount, ForceMode.Force);
            //body.r
            body.AddTorque((Vector3.down) * forceAmount, ForceMode.Force);
            //transform.localRotation = transform.localRotation * Quaternion.Euler(rotationAmount*Time.deltaTime) ;
            Debug.Log("calling");
        }
        if (Input.GetKey(xRotationActivationKey))
        {
            //body.AddRelativeForce((Vector3.forward + Vector3.up) * forceAmount, ForceMode.Force);
            //body.r
            body.AddTorque((Vector3.left) * forceAmount, ForceMode.Force);
            //transform.localRotation = transform.localRotation * Quaternion.Euler(rotationAmount*Time.deltaTime) ;
            Debug.Log("calling");
        }
        if (Input.GetKey(ownAxisRotationActivationKey))
        {
            //body.AddRelativeForce((Vector3.forward + Vector3.up) * forceAmount, ForceMode.Force);
            //body.r
            body.AddTorque((relYAxis) * forceAmount, ForceMode.Force);
            //transform.localRotation = transform.localRotation * Quaternion.Euler(rotationAmount*Time.deltaTime) ;
            Debug.Log("calling");
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + relYAxis);
    }
}
