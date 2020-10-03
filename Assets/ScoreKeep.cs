using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeep : MonoBehaviour
{
    public int currentScore;

    public Text ScoreText;

    void Update() {
        ScoreText.text = currentScore.ToString();
    }
}
