using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameObject _gameUI;
    private GameObject _gameOverUI;
    //Variables for Timer 
    public float timeRemaining = 20;
    public Text oxygenText;
    public AudioSource lowSound;
    private bool countingDown = true;

     //Variables for result UI
    private Text _resultUI;
     public string resultLost = "You lost!";
    public string resultWin = "You won!";

    // variables for Game Over
    private bool gameWon;
    private bool gameLost;
    private bool gameOver = false;

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
       
        
        
    
       


    }

    
       
    void Update()
    {
        OxygenTimer();
    }

    private void OxygenTimer()
    {
        if(countingDown)
        {
            if (timeRemaining > 0)
            {
            timeRemaining -= Time.deltaTime;
            oxygenText.text= "Oxygen empty in: " + Mathf.Round(timeRemaining).ToString() + " seconds";

                
                if (timeRemaining < 6)
                {
                    oxygenText.color= Color.red;
                    
                }
            }
             if (timeRemaining < 0)
            {
                
                oxygenText.text = "Oxygen Empty";
                oxygenText.color= Color.red;
                countingDown = false; 
                lowSound.Stop();
                CheckGameOver();
            }

        }
    }
        
    private void CheckGameOver()
    {
        //  void OnTriggerEnter(Collider other)
        // {
        //     // When player collides with goal 
        //     if(_astroBoi.name == _spaceShip.name)
        //     {
        //         gameWon = true;
        //         gameOver = true;

        //         _resultUI.text = resultWin;
        //         _resultUI.color = Color.green;

        //     }
            
            
            if (timeRemaining < 0)
            {
                gameLost = true;
                gameOver = true;
                _resultUI.text = resultLost;
                _resultUI.color = Color.red;

            }
             if (gameOver)
        {
             _gameUI.SetActive(false);
            _gameOverUI.SetActive(true);
        }
    }
}
    

    


        


