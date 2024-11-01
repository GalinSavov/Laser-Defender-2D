using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Start()
    {
        scoreText.text = "YOUR SCORE\n" + ScoreManager.instance.GetCurrentScore().ToString("000000000");
    }
}
