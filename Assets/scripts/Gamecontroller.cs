using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamecontroller : MonoBehaviour
{
    //スコアテキスト
    public Text scoretext, timertext;
    
    //初期のスコア
    int score;

    public int timecount = 10;
  

    //初期のスコア表示
    void Start()
    {
        scoretext.text = "SCORE:" + score;
        StartCoroutine(Countdown());
        timertext.text = timecount.ToString();
       
    }

    
   
    void Update()
    {
      
       

    }

    //スコア加算
    public void Addscore()
    {
        score += 100;
        scoretext.text = "SCORE:" + score;

    }

    IEnumerator Countdown()
    {
        while(timecount <　0)
            {
            yield return new WaitForSeconds(1);
            timecount--;
            timertext.text = timecount.ToString();
        }
       
    }
   
}
