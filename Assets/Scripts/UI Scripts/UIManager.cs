using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Ref to high score text field in canvas.
    [SerializeField]
    private TextMeshProUGUI highScoreCounter;

    private void Update()
    {
        // Display players current high score.
        highScoreCounter.text = HighScoreManager.Instance.playersHighScore.ToString();

        
    }
}
