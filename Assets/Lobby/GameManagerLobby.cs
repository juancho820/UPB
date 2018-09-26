using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerLobby : MonoBehaviour {

    public void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    public void Survival()
    {
        SceneManager.LoadScene("Survival");
    }
    public void Topos()
    {
        SceneManager.LoadScene("Topos");
    }
    public void Hockey()
    {
        SceneManager.LoadScene("Hockey");
    }
    public void Lego()
    {
        SceneManager.LoadScene("Lego");
    }
}
