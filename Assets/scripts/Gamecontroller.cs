using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamecontroller : MonoBehaviour
{
    //スコアテキスト
    public Text scoretext;
    //初期のスコア
    int score;

    //タイムテキスト
    public Text timelabel;
    //タイムカウント
    public float timecount;

    //初期のスコア表示
    void Start()
    {
        scoretext.text = "SCORE:" + score;
        timelabel.text = "" + timecount;
    }

    void Update()
    {
        timecount -= Time.deltaTime;
        timelabel.text = "" + timecount.ToString("0");
        if (timecount <= 0)
        {
            timelabel.text = "";

        }

    }

    //スコア加算
    public void Addscore()
    {
        score += 100;
        scoretext.text = "SCORE:" + score;
      

    }
   
}
