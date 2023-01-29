using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgain : MonoBehaviour
{
    public Button restartButton;
    
    void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
