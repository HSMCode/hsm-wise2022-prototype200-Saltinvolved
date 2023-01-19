using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NextLevelButton : MonoBehaviour
{
    public Button nextLevelButton;
    
    void Start()
    {
        nextLevelButton.onClick.AddListener(Scene);
    }

    private void Scene()
    {
        SceneManager.LoadScene(2);
    }

    
}