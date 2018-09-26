using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerButtons : MonoBehaviour {

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Landscape;
    }

    void Update () {
        if (Input.GetMouseButton(0)&&Input.mousePosition.x>(Screen.width/2)&&transform.localPosition.x<0.3f)
        {
            transform.Translate(new Vector3(1,0,0)*Time.deltaTime*6);
        }
        else if (Input.GetMouseButton(0) && Input.mousePosition.x < (Screen.width/2) && transform.localPosition.x > -0.3f)
        {
            transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 6);
        }
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
