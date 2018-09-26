using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerTopos : MonoBehaviour {

    [SerializeField]
    private Text score;
    [SerializeField]
    private Text tiempoText;
    [SerializeField]
    private Text finalScore;
    [SerializeField]
    private Text highScore;
    private int highscore;

    public bool noMasMonedas;

    private int scoreCoins;

    private float tiempo = 40;

    private AudioSource auds;

    [SerializeField]
    public GameObject win;
    public GameObject touch;
    public GameObject touch2;

    private RaycastHit hit;
    private Ray ray;

    Vector3 worldPos;
    Vector2 wantedScreenSpawnPos;

    public static GameManagerTopos Instance { set; get; }

    // Use this for initialization
    void Start ()
    {
        Screen.orientation = ScreenOrientation.Landscape;
        auds = GetComponent<AudioSource>();
        Time.timeScale = 1;
        Instance = this;
        score.text = scoreCoins.ToString("0");
        tiempoText.text = tiempo.ToString("0");
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Enemy")
                {
                    if(noMasMonedas == false)
                    {
                        hit.collider.GetComponent<Topos>().tocado = true;
                    }
                }
                else
                {
                    touch.transform.position = hit.point + new Vector3(0, 0.01f, 0);
                    touch.SetActive(true);
                    touch.GetComponentInChildren<Animator>().Play("Bounce");

                    touch2.transform.position = hit.point + new Vector3(0, 0.01f, 0);
                    touch2.SetActive(true);
                    touch2.GetComponentInChildren<Animator>().Play("Bounce");
                }
            }
        }
    }

    private void FixedUpdate()
    {
        tiempo -= Time.fixedDeltaTime;
        tiempoText.text = tiempo.ToString("0");

        if(tiempo <= 0)
        {
            Time.timeScale = 0;
            tiempo = 0;
            win.SetActive(true);
            finalScore.text = "Puntaje Final: " + scoreCoins.ToString("0");

            highscore = PlayerPrefs.GetInt("highscore");
            highScore.text = "Maximo Puntaje: " + highscore.ToString("0");

            if (scoreCoins > highscore)
            {
                highscore = scoreCoins;
                highScore.text = "Maximo Puntaje: " + highscore.ToString("0");

                PlayerPrefs.SetInt("highscore", highscore);
            }
        }
    }
    public void GetCoin()
    {
        auds.Play();
        scoreCoins++;
        score.text = scoreCoins.ToString("0");
    }

    public void Resetiar()
    {
        SceneManager.LoadScene("Topos");
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
