using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scemeManagment : MonoBehaviour
{
    public string restartLevel;
    public string menu;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart() {
        SceneManager.LoadScene(restartLevel);
    }
    public void MainMenu() {
        SceneManager.LoadScene(menu);
    }
    public void Escape() {
        Application.Quit();
    }
}
