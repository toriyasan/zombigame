using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator : MonoBehaviour
{

    //敵の変数
    public GameObject enemyprefab;

    public GameObject[] enemypoints;

    //繰り返し生成
    void Start()
    {
        InvokeRepeating("spwan", 1f, 0.5f);
    }

    
    void Update()
    {
        
    }

    //敵の生成
    public void spwan()
    {
        Vector3 pos = enemypoints[Random.Range(0, enemypoints.Length)].transform.position;
        Instantiate(enemyprefab, pos, transform.rotation);
    }
}
