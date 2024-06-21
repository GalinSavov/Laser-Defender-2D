using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int currentScore = 0;

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
