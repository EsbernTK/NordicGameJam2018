using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SelfieEvaluator : MonoBehaviour {

    // Use this for initialization
    public GameObject[] g_features;

    public List<Transform> t_features;
    public Camera cam;
    public bool takingSelfie = false;
    public Material outputmaterial;
	void Start () {
        cam = Camera.main;
        g_features = GameObject.FindGameObjectsWithTag("SelfieFeature");
        foreach (var item in g_features)
        {
            t_features.Add(item.transform);
        }
    }
	
	// Update is called once per frame
	void Update () {
    }

    bool displaySelfie = false;

    void OnRenderImage(RenderTexture input, RenderTexture dest)
    {
        if (takingSelfie)
        {
            
            TakeSelfie(input);
            takingSelfie = false;
            displaySelfie = true;
        }
        if (!displaySelfie)
            Graphics.Blit(input, dest);
        else
        {
            Debug.Log("doing the thing");
            Graphics.Blit(r_selfie, dest);
        }
    }
    //render

    public RenderTexture r_selfie;
    public Texture2D t_selfie;
    void TakeSelfie(RenderTexture input)
    {
        r_selfie = new RenderTexture(input);
        r_selfie.Create();
        Graphics.Blit(input, r_selfie);
        outputmaterial.SetTexture("_MainTex", r_selfie);
        EvaluateSelfie();
    }

    int succesfullPoints = 0;
    int pointCount;
    public float selfieEvaluation;

    float calculateFeatureBoundingBoxArea()
    {
        Vector2 AABB = new Vector2();
        foreach (var item in t_features)
        {
            Vector3 screenPoint = cam.WorldToScreenPoint(item.position);
            if (IsWithinScreen(screenPoint))
            {
                if (AABB.x < screenPoint.x)
                    AABB.x = screenPoint.x;

                if (screenPoint.y > AABB.y)
                    AABB.y = screenPoint.y;
            }
        }

        float area = AABB.x * AABB.y;
        return area;
    }

    public GameManagerScoreKeeper gmsk;

    void EvaluateSelfie()
    {
        succesfullPoints = 0;
        Debug.Log("Evaluating Selfie");
        pointCount = t_features.Count;

        float featureboundingArea = calculateFeatureBoundingBoxArea();
        float screenArea = Screen.width * Screen.height;
        float areaFilledmodifier =  featureboundingArea / screenArea;
        for (int i = 0; i < pointCount; i++)
        {
            Transform feature = t_features[i];
            Vector3 screenPoint = cam.WorldToScreenPoint(feature.position);

            if (IsWithinScreen(screenPoint))
            {
                succesfullPoints++;
            }
        }
        selfieEvaluation = ((float)succesfullPoints/ (float)pointCount) * areaFilledmodifier;

        StartCoroutine(ShowEndInterface());
    }

    public Canvas endSelfieInterface;
    public Text followers;
    float timerCounter;
    IEnumerator ShowEndInterface()
    {
        //while (true)
        //{
        //    if(timerCounter < 3)
        //    {
        //
        //    }
            endSelfieInterface.transform.gameObject.SetActive(true);
            followers.text = "Congratulations! \n You've Gotten, " + gmsk.score + " Followers!";
            timerCounter += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        //}
        
    }

    bool IsWithinScreen(Vector3 screenPoint)
    {
        int screenX = Screen.width;
        int screenY = Screen.height;
        return (screenPoint.x < screenX && screenPoint.x > 0) && (screenPoint.y < screenY && screenPoint.y > 0);
    }

    public bool debug = false;
    private void OnDrawGizmos()
    {
        if (debug)
        {
            Vector2 AABB = new Vector2();
            foreach (var item in t_features)
            {
                Vector3 screenPoint = cam.WorldToScreenPoint(item.position);
                if (IsWithinScreen(screenPoint))
                {
                    if (AABB.x < screenPoint.x)
                        AABB.x = screenPoint.x;

                    if (screenPoint.y > AABB.y)
                        AABB.y = screenPoint.y;
                }
            }
            float area = AABB.x * AABB.y;
        }
    }
}
