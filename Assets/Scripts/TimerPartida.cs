using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class TimerPartida : MonoBehaviour
{

    Text txt;
    float time=180;
    
    float speed=1;
  
    
    // Start is called before the first frame update
    void Start()
    {
        txt=GetComponent<Text>();
        InvokeRepeating("temporizador",0,1);

    }

    // Update is called once per frame
    void Update()
    {
       
     // GetComponent<PhotonView>().RPC("temporizador",RpcTarget.All);
    }

    [PunRPC]
    void temporizador(){
      
        time-=speed;
        
        
     
        if (time<=0)
        {
           
            time=0;
        }
       
        string seconds=  (time).ToString("000");
        txt.text=  seconds;
        
    }
}
