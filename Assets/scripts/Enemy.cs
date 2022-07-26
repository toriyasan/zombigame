using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Enemy : MonoBehaviour
{
    //移動スピード
    public float enemyspeed;
    //アニメーター
    Animator anim;
    //ターゲット
    public GameObject target;
    //エージェント
    NavMeshAgent agent;
    //スコアの入れ物
    Gamecontroller gamecontroller;
    //敵のプレファブ
    public GameObject enemyprefab;
    
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("player");
        gamecontroller = GameObject.Find("Gamecontroller").GetComponent<Gamecontroller>();
        
    }

    public void Update()
    {
        agent.destination = target.transform.position;

    }

    //当たり判定
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="bullet")
        {
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            gamecontroller.Addscore();
            
        if (other.gameObject.tag =="enemy")
        {
                return;
                
            }
        }
    }

    //敵が生成
    public void Enemygene()
    {

        Instantiate(enemyprefab,transform.position, transform.rotation);

    }
}