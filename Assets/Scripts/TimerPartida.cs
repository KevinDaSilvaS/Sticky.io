using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class TimerPartida : MonoBehaviour
{
    

    Text txt;
    public float time=180;
    
    public float speed=1;
  
  public PhotonView[] pvs;
    
    // Start is called before the first frame update
    void Start()
    {
        txt=GetComponent<Text>();
        InvokeRepeating("temporizador",0,1);

    }

    // Update is called once per frame
    void Update()
    {
       pvs=GameObject.FindObjectsOfType<PhotonView>();
     // pvs.GameObject.GetComponent<PhotonView>().RPC("temporizador",RpcTarget.All);
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
