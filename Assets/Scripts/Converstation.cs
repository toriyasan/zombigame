using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Converstation : MonoBehaviour
{
    public GameObject Dailogtext;
    
    void Start()
    {
        Daialogshow();
    }

    
    void Update()
    {
        
    }

    public void Daialogshow()
    {
        Dailogtext.SetActive(true);
        
    }
}
