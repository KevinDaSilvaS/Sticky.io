using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Tempo : MonoBehaviour
{
    float GameTime=50f;
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
            float countdown= timeleft+50;
            GameTimer.text=countdown.ToString();
        }else
        {
            string minSec=string.Format("{0}:{1:00}" ,timeleft/50,timeleft%50);
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
                    float countdown=50-GameTimeIntervalAt;
                    if (GameTimeIntervalAt>=50)
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
public StickyMove[] score;
    [PunRPC]
    public void RestartGame(){
        canvascore.SetActive(true);
        //PhotonNetwork.LeaveRoom();
        //PhotonNetwork.Disconnect();
        //PhotonNetwork.LoadLevel(0);
        score=(StickyMove[]) GameObject.FindObjectsOfType (typeof(StickyMove));
        count=PhotonNetwork.PlayerList.Length;
         List<string> badguys = new List<string>();
       foreach (var player in score)
       {
           
           
           scores.text+=player.jogador + player.size.ToString() + score.Length +"\n";
           badguys.Add(player.jogador + player.size.ToString() +"\n");
       }
       //scores.text=badguys.ToString() + "/n";
       
        StopAllCoroutines();
    }




}
