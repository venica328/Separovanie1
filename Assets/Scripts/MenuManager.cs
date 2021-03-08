using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    [SerializeField]
    private Text scoreText, separatingText, finalScore, finalSeparatedScore, countDown, fullScore, inputFieldName, changeTime, score;
    [SerializeField]
    private GameObject gameMenu, gameOverMenu, menu, inputFieldMenu, changeTimeMenu;

    private int currentSeparating, currentScore;
    public int timeLeft = 60;
    public int counting;

    public string inputFieldString;


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
        fullScore.text = "Dosiahli ste skóre";
        score.text = "" + 0;
        changeTime.text = "Váš čas doby hry je nastavený na: " + timeLeft;

        
    }

    void Update()
    {
        countDown.text = ("" + timeLeft);
        if (timeLeft == 0)
        {
            MenuManager.instance.InputFieldMenu();
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


    public void IncreaseSeparating()
    {
        currentSeparating++;
        separatingText.text = "" + currentSeparating;
    }


    public void IncreaseFalling()
    {
        currentScore++;
        scoreText.text = "" + currentScore;
    }

    public void ReduceScore()
    {
        currentSeparating--;
        separatingText.text = "" + currentSeparating;
    }


    public void PlayButton()
    {
        GameMenu();
    }

    public void GameMenu()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1;
        menu.SetActive(false);
        gameMenu.SetActive(true);
        inputFieldMenu.SetActive(false);
        changeTimeMenu.SetActive(false);
        Player.instance.StartMoving = true;
        FallingObjects.instance.gameObject.SetActive(true);
        FallingObjects.instance.startFalling = true;
    }

    public void InputFieldMenu()
    {
        menu.SetActive(false);
        gameMenu.SetActive(false);
        inputFieldMenu.SetActive(true);
        Player.instance.StartMoving = false;
        FallingObjects.instance.gameObject.SetActive(false);
        FallingObjects.instance.startFalling = true;
        counting = currentSeparating;
        score.text = "" + counting;
        fullScore.text = "Dosiahli ste skóre: ";
        Debug.Log(inputFieldName.text);

    }

    public void ChangeTimeMenu()
    {
        menu.SetActive(false);
        gameMenu.SetActive(false);
        inputFieldMenu.SetActive(false);
        changeTimeMenu.SetActive(true);
        Player.instance.StartMoving = false;
        FallingObjects.instance.gameObject.SetActive(false);
        FallingObjects.instance.startFalling = true;
    }
    public void GameOver()
    {
        FallingObjects.instance.gameObject.SetActive(false);
        Player.instance.StartMoving = false;
        gameMenu.SetActive(false);
        menu.SetActive(false);
        gameOverMenu.SetActive(true);
        inputFieldMenu.SetActive(false);
        //finalScore.text = "Spadnuté: " + currentScore;
        //finalSeparatedScore.text = "Vyzbierané: " + currentSeparating;
    }



    public void ChangeTimeTo30()
    {
        timeLeft = 0;
        timeLeft = 30;
        changeTime.text = "Váš čas doby hry bude zmenený na: " + timeLeft;
    }

    public void ChangeTimeTo60()
    {
        timeLeft = 0;
        timeLeft = 60;
        changeTime.text = "Váš čas doby hry bude zmenený na: " + timeLeft;
    }

    public void ChangeTimeTo90()
    {
        timeLeft = 0;
        timeLeft = 90;
        changeTime.text = "Váš čas doby hry bude zmenený na: " + timeLeft;
    }

    public void ChangeTimeTo120()
    {
        timeLeft = 0;
        timeLeft = 120;
        changeTime.text = "Váš čas doby hry bude zmenený na: " + timeLeft;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitApplication()
    {
        Debug.Log("the end");
        Application.Quit();
    }
}
