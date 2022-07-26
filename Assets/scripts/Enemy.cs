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
    //スコアの関数を使うための入れ物
    Gamecontroller gamecontroller;
    //敵のプレファブ
    public GameObject enemyprefab;
    //ゾンビ音
    AudioSource audioSource;
    //
    public AudioClip zombisound;

   

 

    private void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.Find("player");
        gamecontroller = GameObject.Find("Gamecontroller").GetComponent<Gamecontroller>();
        InvokeRepeating("enemygene", 5f, 0.5f);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(zombisound, 5f);
   
    }

    public void Update()
    {
        agent.destination = target.transform.position;

    }

    //当たり判定
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="enemy")
        {
            return;
        }
        
        Destroy(other.gameObject);
        gamecontroller.Addscore();
        
        
    }

    //敵が生成
    public void enemygene()
    {

        Instantiate(enemyprefab,transform.position, transform.rotation);

    }
}