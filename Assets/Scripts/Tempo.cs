using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Tempo : MonoBehaviour
{
    float GameTime=180f;
    float GameTimeMax;
    float GameTimeLeft;
    float GameTimeIntervalAt=0;
     public Text GameTimer;
    // Start is called before the first frame update
    void Start()
    {
        GameTimeMax=GameTime;
        ActivateGameTimer();
    }

    // Update is called once per frame
    void Update()
    {
        print(GameTimeLeft);
    }
   


    [PunRPC]
    public void IncreaseGameTime(float timeleft){
        if (timeleft<=0)
        {
            //GameTimeIntervalAt++;
            float countdown= timeleft+180;
            GameTimer.text=countdown.ToString();
        }else
        {
            string minSec=string.Format("{0}:{1:00}" ,timeleft/60,timeleft%60);
            GameTimer.text=minSec.ToString();
        }
    }

    public void ActivateGameTimer(){
        if (PhotonNetwork.IsMasterClient==true)
        {
            StopCoroutine("MatchGameTimer");
            StartCoroutine("MatchGameTimer");
        }else
        {
            StopCoroutine("MatchGameTimer");
        }
    }

    IEnumerator MatchGameTimer(){
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameTime++;
            GameTimeLeft=GameTimeMax-GameTime;

            GetComponent<PhotonView>().RPC("IncreaseGameTime",RpcTarget.All,GameTimeLeft);

                if (GameTimeLeft<=0)
                {
                    GameTimeIntervalAt++;
                    float countdown=180-GameTimeIntervalAt;
                    if (GameTimeIntervalAt>=180)
                    {
                        GameTimeIntervalAt=0;
                        GetComponent<PhotonView>().RPC("RestartGame",RpcTarget.All,null);
                    }
                }
        }
    }






}
