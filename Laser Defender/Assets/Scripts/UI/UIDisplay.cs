using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private Slider healthSlider = null;
    [SerializeField] private Health playerHealth = null;
    void Start()
    {
        healthSlider.maxValue = playerHealth.CurrentHealth;
    }

    
    void Update()
    {
        scoreText.text = ScoreManager.instance.GetCurrentScore().ToString("000000000");
        healthSlider.value = playerHealth.CurrentHealth;
    }
}
