using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamecontroller : MonoBehaviour
{
    public Text scoretext;

    int score;
    void Start()
    {
        scoretext.text = "SCORE:" + score;
    }

   
    void Update()
    {
        
    }

    public void Addscore()
    {
        score += 100;
        scoretext.text = "SCORE:" + score;

    }
}
