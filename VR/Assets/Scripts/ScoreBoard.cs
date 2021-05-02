using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public static float score;

    // Start is called before the first frame update
    void Start()
    {
        if(score < GameManager.lastScore)
        {
            score = GameManager.lastScore;
            scoreText.text = score.ToString();
        }
        else
        {
            scoreText.text = score.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
