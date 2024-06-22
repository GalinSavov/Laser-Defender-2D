using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;

    private static ScoreKeeper instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void ResetScore()
    {
        currentScore = 0; 
    }

    public void IncreaseScore(int amount)
    {
        currentScore += amount;
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
}
