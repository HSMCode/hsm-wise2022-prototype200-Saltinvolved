using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BackToMenu : MonoBehaviour
{
    public Button menuButton;
    
    void Start()
    {
       menuButton.onClick.AddListener(Scene);
    }

    public void Scene()
    {
        SceneManager.LoadScene(0);
    }
}
