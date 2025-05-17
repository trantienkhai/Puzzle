using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public int difficultyLevel = 0;
    public float fallTime = 0.8f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;

        if (score >= 400) difficultyLevel = 2;
        else if (score >= 200) difficultyLevel = 1;

        switch (difficultyLevel)
        {
            case 1: 
                fallTime = 0.4f; 
                break;
            case 2: 
                fallTime = 0.2f; 
                break;
            default: 
                fallTime = 0.8f; 
                break;
        }
    }

    public void ResetAll()
    {
        score = 0;
        difficultyLevel = 0;
        fallTime = 0.8f;
    }
}
