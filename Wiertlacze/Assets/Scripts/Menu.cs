using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public static bool GameIsPlayer = false;
    

    public GameObject MenuPlayerUI;

    private StatsManagement statsManagement;
    [SerializeField] private SaveManager saveManager;

    void Start()
    {
        statsManagement = GameObject.FindWithTag("Player").GetComponent<StatsManagement>();
    }

    void  CheckMenuOpen()
    {
        if (!statsManagement.IsInventory)
        {
            if (Input.GetButtonDown("Cancel"))
            {
                if (GameIsPlayer)
                {
                    Play();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    void Update(){
        CheckMenuOpen();
    }
    public void Play()
    {
        MenuPlayerUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPlayer = false;
    }
    
    public void Save()
    {
        if (saveManager == null)
            return;
        saveManager.Save();
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
