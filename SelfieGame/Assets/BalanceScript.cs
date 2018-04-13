using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceScript : MonoBehaviour {
    public List<BodyPart> bodyParts;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public Vector3 CalcCenterOfMass()
    {
        Vector3 center = Vector3.zero;
        float totWeight = 0;
        foreach(BodyPart part in bodyParts)
        {
            center += part.transform.position * part.weight;
            totWeight += part.weight;
        }

        return center/totWeight;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(CalcCenterOfMass(), 0.1f);
    }
}
