using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Gamecontroller : MonoBehaviour
{
    //スコアテキスト
    public Text scoretext;
    //初期のスコア
    public static int score;
    //エネミーテキスト
    public Text enemytext;
    //エネミーの数
    public int enemycout;



    void Start()
    {
        scoretext.text = "SCORE:" + score;
        enemytext.text = ""+enemytext;
        
    }

    void FixedUpdate()
    {
        
        Enemycount();

    }

    //スコア加算
    public void Addscore()
    {
        score += 100;
        scoretext.text = "SCORE:" + score;
      
    }

    //敵の数
    public void Enemycount()
    {
        enemytext.text = "敵の数" + enemycout.ToString("0");
        if(enemycout < 0)
        {
            enemytext.text = "敵の数" + enemycout.ToString("0");
        }
    }

}
