using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    void Awake()
    {
        print("Button Touched");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level01");
    }

    public void Credit()
    {
        SceneManager.LoadScene("Credits");
    }


} //mainmenucontroller
