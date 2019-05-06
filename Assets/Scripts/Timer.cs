using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text txt;
    float time=3;
    float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        txt=GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time-=Time.deltaTime*speed;
        if (time<=0)
        {
            time=0;
        }
        if (time==0)
        {
            time=3;
        }
        string seconds=(time%60).ToString("00");
        txt.text=/*"Respawn" + */seconds;
    }
}
