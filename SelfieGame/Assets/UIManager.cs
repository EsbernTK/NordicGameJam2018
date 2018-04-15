using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject titlescreen;
    public GameObject TakePicture;
    public int followers;
    public Text followerText; 


    public void updateFollowers()
    {
        followers += 100;

        followerText.text = "Followers: " + followers; 
    }

    public void showTitleScreen()
    {
        titlescreen.SetActive(true);
        followerText.text = "";
        TakePicture.SetActive(true); 
        
    }

    public void hideTitleScreen()
    {
        titlescreen.SetActive(false);
        followerText.text = "Followers: ";
        TakePicture.SetActive(false);
    }



}
