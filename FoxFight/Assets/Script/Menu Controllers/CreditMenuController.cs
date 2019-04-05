using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditMenuController : MonoBehaviour
{
    void Awake()
    {
        print("Button Touched");
    }

    public void GameAssets()
    {
        Application.OpenURL("https://assetstore.unity.com/publishers/18720");
    }

    public void MenuUI()
    {
        Application.OpenURL("https://assetstore.unity.com/publishers/1");
    }

    public void GameMusic()
    {
        Application.OpenURL("https://assetstore.unity.com/publishers/9508");
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


} //creditMenu
