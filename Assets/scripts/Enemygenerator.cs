using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator : MonoBehaviour
{

    //敵の変数
    public GameObject enemyprefab;
    //敵のポジション
    public GameObject[] enemypoints;
    //敵の数
    public int enemycount;

    private int remeinenemy;
    //タイマー
    public float timer;
    //ネクストタイム
    public float nextspwantime;

    //繰り返し生成
    void Start()
    {
        //InvokeRepeating("spwan", 1f, 0.5f);
        remeinenemy = enemycount;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > nextspwantime&&remeinenemy > 0)
        {
            spwan();
            timer = 0;
            nextspwantime = Random.Range(1, 5);
            remeinenemy--;
        }

    }

    //敵の生成
    public void spwan()
    {
        Vector3 pos = enemypoints[Random.Range(0, enemypoints.Length)].transform.position;
        Instantiate(enemyprefab, pos, transform.rotation);
    }
}
