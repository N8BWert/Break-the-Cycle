using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public string nextScene;
    private AudioSource source;
    public AudioClip pop;

    void Start() {
        source = GetComponent<AudioSource>();
    }
    public void OnClick() {
        source.PlayOneShot(pop);
        SceneManager.LoadScene(nextScene);
    }
}
