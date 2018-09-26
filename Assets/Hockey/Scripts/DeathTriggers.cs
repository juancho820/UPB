using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggers : MonoBehaviour {
    [SerializeField] private GuiScores scores;
    [SerializeField] private int identifier;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            if (identifier==1)
            {
                scores.SumarPlayer();
            }
            if (identifier == 0)
            {
                scores.SumarAi();
            }
            if (identifier == 3)
            {
                
            }
            Ball ballScript = other.GetComponent<Ball>();
            ballScript.RestartBall();
        }
    }
}
