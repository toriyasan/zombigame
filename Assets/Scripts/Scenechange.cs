using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scenechange : MonoBehaviour
{
    //メインシーンに画面切り替え
    public void Gamestart()
    {
        SceneManager.LoadScene("main");
    }

    //ゲームクリア画面に切り替え
    public void Gameclear()
    {
        SceneManager.LoadScene("CLEAR");
    }

}
