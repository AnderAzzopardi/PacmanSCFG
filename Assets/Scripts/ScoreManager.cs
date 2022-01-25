using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString()+ " Points";
        highscoreText.text = " Highscore " + highscore.ToString();
    }

    public void AddPoint(){

       score += 1;
       scoreText.text = score.ToString()+ " Points";

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
