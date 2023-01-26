using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class ScriptUI : MonoBehaviour
{
    private GameObject _gameUI;
    private GameObject _gameOverUI;
    //Variables for Timer 
    public float timeRemaining;
    public Text oxygenText;
   
    public bool _countingDown = true;
    // Low Oxygen Effects
     public AudioSource lowSound;
     public Image danger;
     public bool isDangerOn;


     //Variables for result UI
    private Text _resultUI;
     public string resultLost = "You lost!";
    public string resultWin = "You won!";

    // variables for Game Over
    public bool _gameWon;
    private bool gameLost;
    public bool _gameOver = false;

    // Variables for Win
    private GameObject _astroBoi;
    private GameObject _spaceShip;

    //getting script for Win
    public SpaceshipGoal script;
    
    



    void Start()
    {
        //get components for GameOverUI
        _gameUI = GameObject.Find("GameUI");
        _gameOverUI = GameObject.Find("GameOverUI");
        _resultUI = GameObject.Find("Result").GetComponent<Text>();
        // get components for Oxygen low 
        oxygenText = GetComponent<Text>() as Text;
        //lowSound  = GetComponent<AudioSource> () as AudioSource;
        //danger = GetComponent <danger>() as Image;
        //get components for Winbedingungen 
        _astroBoi = GameObject.Find("AstroBoi");
        _spaceShip = GameObject.Find("SpaceShip");
      
        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false); 
        lowSound.PlayDelayed(5f);       
        //Invoke("LowSound",10f-5f);
          
         danger.enabled = false;
         
        

        } 
       
    void Update()
    {
        OxygenTimer();
    }


    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);

        if (_gameWon)
        {
            _resultUI.text = resultWin;
            _resultUI.color = Color.green;
            //Debug.Log("game Won");
        }
        else if (gameLost)
        {
            _resultUI.text = resultLost;
            _resultUI.color = Color.red;
        }

        _gameUI.SetActive(false);
        _gameOverUI.SetActive(true);

    }

    private void CheckGameOver()
    {
        if (script._landed == true)
        {
            _gameWon = true;
            _gameOver = true;

            StartCoroutine(GameOver());
        }

        if (timeRemaining < 0)
        {
            gameLost = true;
            _gameOver = true;
            _resultUI.text = resultLost;
            _resultUI.color = Color.red;

        }
        if (_gameOver)
        {
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
            //Destroy(lowSound);
        }

    }

    private void OxygenTimer()
    {
        if (_countingDown)
        {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            oxygenText.text = "Oxygen empty in: " + Mathf.Round(timeRemaining).ToString() + " seconds";
            //Debug.Log(timeRemaining);



            if (timeRemaining < 6)
            {
                oxygenText.color = Color.red;
                danger.enabled = true;
                

            }
             if (timeRemaining < 5)
            {
                
                danger.enabled = false;
            }
             if (timeRemaining < 4)
            {
                
                danger.enabled = true;
            }
             if (timeRemaining < 3)
            {
           
                danger.enabled = false;
            }
             if (timeRemaining < 2)
            {
           
                danger.enabled = true;
            }
             if (timeRemaining < 1)
            {
           
                danger.enabled = false;
            }

            if (timeRemaining < 0)
            {

                oxygenText.text = "Oxygen Empty";
                oxygenText.color = Color.red;
                _countingDown = false;
                danger.enabled = false;
                lowSound.Stop();
                CheckGameOver();
            }

        }
    }

    }


}







