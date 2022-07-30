using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
   　//弾の速度
    public float bulletspeed;

   //アサルトライフルの弾方向
    void Update()
    {
        transform.position += transform.forward * bulletspeed;
    }
}
