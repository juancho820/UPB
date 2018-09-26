using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiScores : MonoBehaviour {
    [SerializeField] private Text scorePlayerTxt;
    [SerializeField] private Text scoreAiTxt;
    private int scorePlayer;
    private int scoreAi;

    public void SumarPlayer()
    {
        scorePlayer++;
    }

    public void SumarAi()
    {
        scoreAi++;
    } 
	
	void Update () {
        scorePlayerTxt.text = scorePlayer.ToString();
        scoreAiTxt.text = scoreAi.ToString();
	}
}
