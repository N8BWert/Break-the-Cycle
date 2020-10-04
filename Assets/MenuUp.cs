using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUp : MonoBehaviour
{
    public GameObject menuButton;
    public GameObject restartButton;
    public GameObject quitButton;

    public bool on = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(on) {
                menuButton.SetActive(false);
                restartButton.SetActive(false);
                quitButton.SetActive(false);
                on = false;
            }
            if(!on) {
                menuButton.SetActive(true);
                restartButton.SetActive(true);
                quitButton.SetActive(true);
                on = true;
            }
        }
    }
}
