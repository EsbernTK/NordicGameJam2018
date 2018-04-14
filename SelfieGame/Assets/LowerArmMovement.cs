using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerArmMovement : MonoBehaviour {

    public KeyCode yRightRotationActivationKey = KeyCode.D;
    public KeyCode yLeftRotationActivationKey = KeyCode.A;
    public KeyCode xUpRotationActivationKey = KeyCode.W;
    public KeyCode xDownRotationActivationKey = KeyCode.S;
    public float forceAmount = 10;
    public Vector3 rotationAxis = new Vector3(1, 0, 0);
    public GameObject childObject;
    public Transform parentTrans;
    Rigidbody body;
    Vector3 relYAxis;
    Vector3 relXAxis;
    Vector3 relZAxis;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody>();
        relYAxis = (childObject.transform.position - transform.position).normalized;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (Input.GetKeyDown(xUpRotationActivationKey))
        {
            body.AddTorque((-parentTrans.right) * forceAmount, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(xDownRotationActivationKey))
        {
            body.AddTorque((parentTrans.right) * forceAmount, ForceMode.Impulse);
        }
        body.AddForce(new Vector3(Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f), Random.Range(-0.05f, 0.05f)),ForceMode.Impulse);
    }
}
