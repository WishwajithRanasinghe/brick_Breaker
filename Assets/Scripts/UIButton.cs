using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    private void Start()
    {
        Time.timeScale = 1;
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;

    }
    public void Exit()
    {
        Application.Quit();
        //Time.timeScale = 1;
        Debug.Log("Exit");
    }
    public void Play()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
        _mainMenu.SetActive(false);

    }
}//Class
