using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialVerifier : MonoBehaviour 
{
    private const string tutorialKey = "PlayedTutorial";
    //private GameObject tutorialAlertCanvas;
    private bool playedTutorial;
	
    public void PlayTutorial()
    {
        playedTutorial = true;
        PlayerPrefs.Save();
    }

    public bool GetPlayedTutorial()
    {
        return playedTutorial;
    }

    private void Start()
    {
        playedTutorial = PlayerPrefs.HasKey(tutorialKey);
    }

    private void Update()
    {
        if( Input.GetKeyDown("k") )
        {
            PlayerPrefs.DeleteKey(tutorialKey);
            Debug.LogWarning("Deleted key: " + tutorialKey);
            PlayerPrefs.Save();
            playedTutorial = PlayerPrefs.HasKey(tutorialKey);
        }
    }
}
