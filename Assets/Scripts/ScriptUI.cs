using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;


public class ScriptUI : MonoBehaviour
{
    // Diffrent UIs for Play mode and Game Over Mode 
    private GameObject _gameUI;
    private GameObject _gameOverUI;
    
    //Variables for Timer 
    public float timeRemaining;
    public Text _oxygenText;
   
    public bool countingDown = true;
    
    // Low Oxygen Effects
     public AudioSource _lowSound;
     public Image danger;
    


     //Variables for result UI
    private Text _resultUI;
     public string resultLost = "You lost!";
    public string resultWon = "You won!";

    // variables for Game Over
    public bool gameWon;
    public bool gameLost;
    public bool gameOver = false;
    public GameObject _nextLevelButton;

      //getting script for Win
    public SpaceshipGoal _script;
    public GameObject  SpaceShip;
   
      void Start()
    {
        //get components for GameOverUI
        _gameUI = GameObject.Find("GameUI");
        _gameOverUI = GameObject.Find("GameOverUI");
        _resultUI = GameObject.Find("Result").GetComponent<Text>();
       
        // get components for Oxygen low 
        _oxygenText = GetComponent<Text>() as Text;
        _lowSound  = GetComponent<AudioSource> () as AudioSource;
        
        //get components for Win
        _script = SpaceShip.GetComponent<SpaceshipGoal>();


        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false); 

        //Playing Low sound 5seconds before end 
        _lowSound.PlayDelayed(25f);       
        
        // Showing danger image that indcates that oxygen is low 
         danger.enabled = false;
    } 
       
    void Update()
    {
        OxygenTimer();
        CheckGameOver();
    }


    
    //Methode Checkes when Game is over and what to do when Game is Over 
    private void CheckGameOver()
    {

        //When player reaches ship Game is over and Won
        if (_script._hasLanded == true)
        {
            gameWon = true;
            gameOver = true;
            countingDown = false;
            _resultUI.text = resultWon;
            _resultUI.color = Color.green;
        }

        // If he doesn't reach ship and timer is at zero Game is over and lost
         else if (timeRemaining < 0)
        {
            gameLost = true;
            gameOver = true;
            countingDown = false;
            _resultUI.text = resultLost;
            _resultUI.color = Color.red;
            _nextLevelButton.SetActive(false);
            

        }
        // when game is over we swicht to the Gameover UI and the Low Oxygensound stops playing 
        if (gameOver)
        {
            _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
            Destroy(_lowSound);
        }

    }

    //Method for the Timer  
    private void OxygenTimer()
    {
        if (countingDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                _oxygenText.text = "Oxygen empty in: " + Mathf.Round(timeRemaining).ToString() + " seconds";
                LowOxygenEffects();
            }
                
                else if (timeRemaining < 0)
                {
                    _oxygenText.text = "Oxygen Empty";
                    _oxygenText.color = Color.red;
                    countingDown = false;
                    danger.enabled = false;
                }

        }
        
    }
    //Method for Low Oxygen Effects 
    private void LowOxygenEffects()
    {
        if (timeRemaining < 6)
        {
            _oxygenText.color = Color.red;
            danger.enabled = true;
                
         }
            
        if (timeRemaining < 5)        
        {
            danger.enabled = false;
        }

         if (timeRemaining < 4)
        {
            _oxygenText.color = Color.red;
            danger.enabled = false;
                
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
    }
    
}
    













