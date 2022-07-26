using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text Timelabel;
    public float timecount;

    void Start()
    {
       
        Timelabel.text = "" + timecount;
    }

    // Update is called once per frame
    void Update()
    {
        timecount -= Time.deltaTime;
        Timelabel.text = "" + timecount.ToString("0");


    }
}
