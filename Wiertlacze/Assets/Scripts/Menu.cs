using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public static bool GameIsPlayer = false;

    public GameObject MenuPlayerUI;
   
    void Update(){
       if(Input.GetKeyDown(KeyCode.Escape))
       {
            if(GameIsPlayer)
            {
                Play();
            }
            else
            {
                Pause();
            }
       }
    }
    public void Play()
    {
        MenuPlayerUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPlayer = false;
    }
    void Pause()
    {
        MenuPlayerUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPlayer = true; 
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
