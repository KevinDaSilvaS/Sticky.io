using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Tempo : MonoBehaviour
{
    float GameTime=60f;
    float GameTimeMax;
    float GameTimeLeft;
    float GameTimeIntervalAt=0;
     public Text GameTimer;
     public Text scores;
     public GameObject canvascore;
    // Start is called before the first frame update
    void Start()
    {
        canvascore.SetActive(false);
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
            float countdown= timeleft+60;
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
                    float countdown=60-GameTimeIntervalAt;
                    if (GameTimeIntervalAt>=60)
                    {
                        GameTimeIntervalAt=0;
                        GetComponent<PhotonView>().RPC("RestartGame",RpcTarget.All,null);
                        //RestartGame();
                    }
                }
        }
    }
int count;
string nome;
public GameObject[] score;
    [PunRPC]
    public void RestartGame(){
        canvascore.SetActive(true);
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.Disconnect();
        //PhotonNetwork.LoadLevel(0);
        count=PhotonNetwork.PlayerList.Length;
        
       // print(count);

            score=GameObject.FindGameObjectsWithTag("Player");
             foreach (GameObject point in score)
              {
                  StickyMove scale=point.GetComponent<StickyMove>();
                  StickyMove nomes=point.GetComponent<StickyMove>();
                  nome=nomes.jogador;
                  scores.text=nome +" : "+ scale.size.ToString();
                  print(scale.size);
                GetComponent<PhotonView>().RPC("RestartGame",RpcTarget.All,scores);
              }
       
        StopAllCoroutines();
    }




}
