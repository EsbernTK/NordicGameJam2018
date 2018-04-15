using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScoreKeeper : MonoBehaviour {
    public GameObject Player;
    public UpperArmMovement upperArm;
    public LowerArmMovement lowerArm;
    public GameObject train;
    float halfWayPoint;
    public float score = 100;
    public SelfieEvaluator evaluator;
    public float trainModifier = 10;
    float trainTime;
    public AudioManager audioManager;
    float timer = 0f;
    bool takingSelfie = false;
    public UIManager uIManager;
    bool dead;
	// Use this for initialization
	void Start () {
        trainTime = train.GetComponent<TrainMover>().timeToPlayer;
        halfWayPoint = (train.GetComponent<TrainMover>().trainSpeed *trainTime) / 2;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space) && !takingSelfie)
        {

            Player.GetComponent<Animator>().SetBool("takePhoto", true);
            Debug.Log("Taking Selfie");
            takingSelfie = true;
            upperArm.freeze = true;
            lowerArm.freeze = true;
            
            StartCoroutine(takeSelfie());
            
        }
		if(Time.time >= trainTime && !evaluator.takingSelfie && !dead)
        {
            if(!dead)
                audioManager.audioEffects[2].PlayEffect();
            score = 100000;
            dead = true;
            Debug.Log("DEAD");
        }
	}
    public float calculateScore()
    {
        float dist = ((Player.transform.position.z - train.transform.position.z) - halfWayPoint)/(halfWayPoint*2);

        float score = evaluator.selfieEvaluation + dist * trainModifier ;
        return (int)(score * 100);
    }
    public IEnumerator takeSelfie()
    {
        float timer = 0f;
        while(timer < 1.2f)
        {
            yield return new WaitForSeconds(0.01f);
            timer += Time.deltaTime;
        }
        train.GetComponent<TrainMover>().enabled = false;
        
        evaluator.takingSelfie = true;

        yield return new WaitForSeconds(0.01f);
        score = calculateScore();
    }
}
