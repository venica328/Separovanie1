using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    private Text scoreText, separatingText, finalScore, finalSeparatedScore, countDown;
    [SerializeField]
    private GameObject gameMenu, gameOverMenu, menu;

    private int currentSeparating, currentScore;
    private int timeLeft = 60;




    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 0;
        separatingText.text = "" + 0;

        StartCoroutine("LoseTime");
        Time.timeScale = 1;
    }

    void Update()
    {
        countDown.text = ("" + timeLeft);
        if(timeLeft == 0)
        {
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);

        }
    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }


    // Update is called once per frame
    public void IncreaseSeparating()
    {
        currentSeparating++;
        separatingText.text = "" + currentSeparating;
    }


    public void IncreaseScore()
    {
        currentScore++ ;
        scoreText.text = "" + currentScore;
    }


    public void PlayButton()
    {
        menu.SetActive(false);
        gameMenu.SetActive(true);
        Player.instance.StartMoving = true;
    }

    public void GameOver()
    {
            FallingObjects.instance.gameObject.SetActive(false);
            gameMenu.SetActive(false);
            menu.SetActive(false);
            gameOverMenu.SetActive(true);
            finalScore.text = "Spadnuté: " + currentScore;
            finalSeparatedScore.text = "Vyzbierané: " + currentSeparating;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
