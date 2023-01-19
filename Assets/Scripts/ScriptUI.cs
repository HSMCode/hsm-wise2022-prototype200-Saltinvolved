using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptUI : MonoBehaviour
{
    private GameObject _gameUI;
    private GameObject _gameOverUI;
    //Variables for Timer 
    public float timeRemaining = 20;
    public Text oxygenText;
    public AudioSource lowSound;
    public bool _countingDown = true;

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
    
    



    void Start()
    {
        //get components for GameOverUI
        _gameUI = GameObject.Find("GameUI");
        _gameOverUI = GameObject.Find("GameOverUI");
        _resultUI = GameObject.Find("Result").GetComponent<Text>();
        // get components for Oxygen low 
        oxygenText = GetComponent<Text>() as Text;
        lowSound  = GetComponent<AudioSource> () as AudioSource;
        //get components for Winbedingungen 
        _astroBoi = GameObject.Find("AstroBoi");
        _spaceShip = GameObject.Find("SpaceShip");
      
        _gameUI.SetActive(true);
        _gameOverUI.SetActive(false);        
        // Play Low oxygen Audio at 14 sek
        //LowPlay();
         Invoke("LowPlay",14f);
       
       
        
    
       


    }

    
       
    void Update()
    {
        OxygenTimer();
    }

    private void OxygenTimer()
    {
        if(_countingDown)
        {
            if (timeRemaining > 0)
            {
            timeRemaining -= Time.deltaTime;
            oxygenText.text= "Oxygen empty in: " + Mathf.Round(timeRemaining).ToString() + " seconds";

                
                
            
                if (timeRemaining < 6)
                {
                    oxygenText.color= Color.red;
                    
                }
            
             if (timeRemaining < 0)
            {
                
                oxygenText.text = "Oxygen Empty";
                oxygenText.color= Color.red;
                _countingDown = false; 
                //lowSound.Stop();
                CheckGameOver();
            }

        }
    }
        
    void CheckGameOver()
    {
        if (_gameWon)
        {
            _resultUI.text = resultWin;
            _resultUI.color = Color.green;
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
            Destroy(lowSound);
        }
    }

    // void LowPlay()
    // {
    //     lowSound.Play();
    // }
}
}

    

    


        


