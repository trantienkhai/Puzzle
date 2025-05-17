using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Update()
    {
        if (ScoreManager.instance != null)
        {
            scoreText.text = "Score: " + ScoreManager.instance.score;
        }
    }
}
