using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Script : MonoBehaviour
{
    public int score = 0;
    public Text ScoreText;
    

    void Start()
    {
        var asd = GetComponent<artificial_intelligence_enemy>();
    }

    
    void Update()
    {
        
    }


    public void ScoreInCrease(int Scorecomefrom)
    {
        score += Scorecomefrom;
        ScoreText.text = (" Score = " + score);
    } 

}
