using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScoreKeeper : MonoBehaviour {
    public GameObject Player;
    public GameObject train;
    float halfWayPoint;
    public float score;
    public SelfieEvaluator evaluator;
    public float trainModifier = 10;
    float trainTime;
	// Use this for initialization
	void Start () {
        trainTime = train.GetComponent<TrainMover>().timeToPlayer;
        halfWayPoint = (train.GetComponent<TrainMover>().trainSpeed *trainTime) / 2;
    }
	
	// Update is called once per frame
	void Update () {
		if(Time.time > trainTime)
        {

        }
	}
    public float calculateScore()
    {
        float dist = ((Player.transform.position.z - train.transform.position.z) - halfWayPoint)/(halfWayPoint*2);

        float score = evaluator.selfieEvaluation + dist * trainModifier ;
        return score;
    }
}
