using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    
    public static int PlayerOneScore = 0;
    [SerializeField] public TextMeshProUGUI playerOneScoreText;

    public static int PlayerTwoScore = 0;
    [SerializeField] public TextMeshProUGUI playerTwoScoreText;

    // Update is called once per frame
    void Update() {
        this.playerOneScoreText.text = $"P1: {PlayerOneScore}";
        this.playerTwoScoreText.text = $"P2: {PlayerTwoScore}";
    }
}
