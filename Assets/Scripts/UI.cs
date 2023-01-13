using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
private bool _canStart;
    
    public float timeRemaining = 20;
    public Text oxygenText;
    public AudioSource lowSound;


    void Start()
    {
      oxygenText = GetComponent<Text>() as Text;
      lowSound  = GetComponent<AudioSource> () as AudioSource;
      Invoke("PlaySound", 13.0f);


    }

    
       
    void Update()
    {
        OxygenTimer();
    }

    private void OxygenTimer()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            oxygenText.text= "Oxygen empty in: " + Mathf.Round(timeRemaining).ToString() + " seconds";

        }
        if (timeRemaining < 6)
        {
            oxygenText.color= Color.red;
        }
        //if (timeRemaining <= 0)
        //{

        //}
    }

    void PlaySound() 
    {

        lowSound.Play();
    }

}
