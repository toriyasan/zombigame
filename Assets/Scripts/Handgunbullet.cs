using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgunbullet : MonoBehaviour
{
    //ハンドガンの弾の方向
    void Update()
    {
        transform.position += new Vector3(0, 0, 0.1f);
    }
}
