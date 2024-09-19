using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardControllerScript : MonoBehaviour {

    [SerializeField] GameObject playerScoreCanvas;
    [SerializeField] GameObject offlineScoreCanvas;
    [SerializeField] GameObject leaderBoadCanvas;
    [SerializeField] GameObject leaderBoadCanceledCanvas;
    [SerializeField] GameObject list;
    [SerializeField] GameObject listC;

    private PlayerDataCanvas[] playerDataCanvas;
    private GameObject invalidInput;
    private GameObject nameList;
    private GameObject waveList;
    private GameObject scoreList;
    private GameObject nameListC;
    private GameObject waveListC;
    private GameObject scoreListC;
	private DeathManager deathManager;
	private Fading fading;
	private bool cancel = false;
    private bool isPlayerInList = false;
    private bool isFirstTime = true;
	private float wave;
	private float score;
    private int playerRank;
	private string playerName;

    public void SetPlayerScoreCanvasActive(bool setActive)
    {
        playerScoreCanvas.SetActive(setActive);
    }

    public void SetWave(float _wave){
		wave = _wave;
	}

	public void SetScore(float _score){
		score = _score;
	}

	private void Start(){
		deathManager = GameObject.Find ("GameMaster").GetComponent<DeathManager> ();
		fading = GameObject.Find ("GameMaster").GetComponent<Fading> ();

        nameList = GameObject.Find("NameList");
        waveList = GameObject.Find("WaveList");
        scoreList = GameObject.Find("ScoreList");
        nameListC = GameObject.Find("NameListC");
        waveListC = GameObject.Find("WaveListC");
        scoreListC = GameObject.Find("ScoreListC");
    }
}
