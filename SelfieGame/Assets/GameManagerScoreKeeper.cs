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
    public AudioManager audioManager;
    float timer = 0f;
    bool takingSelfie = false;
	// Use this for initialization
	void Start () {
        trainTime = train.GetComponent<TrainMover>().timeToPlayer;
        halfWayPoint = (train.GetComponent<TrainMover>().trainSpeed *trainTime) / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.R) && !takingSelfie)
        {
            Player.GetComponent<Animator>().StartPlayback();
            Debug.Log("Taking Selfie");
            takingSelfie = true;
            StartCoroutine(takeSelfie());
            
        }
		if(Time.time > trainTime && !evaluator.takingSelfie)
        {

            Debug.Log("DEAD");
        }
	}
    public float calculateScore()
    {
        float dist = ((Player.transform.position.z - train.transform.position.z) - halfWayPoint)/(halfWayPoint*2);

        float score = evaluator.selfieEvaluation + dist * trainModifier ;
        return score;
    }
    public IEnumerator takeSelfie()
    {
        float timer = 0f;
        while(timer < 1.2f)
        {
            yield return new WaitForSeconds(0.01f);
            timer += Time.deltaTime;
        }
        evaluator.takingSelfie = true;
    }
}
