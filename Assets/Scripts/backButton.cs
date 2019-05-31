using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
namespace Com.MyCompany.MyGame
{
public class backButton : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
  public GameObject scores;
  public Tempo resetTime;
     public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
            print("me desconecte pfffff");
            resetTime.GameTime=60;
            resetTime.GameTimeLeft=0f;
            resetTime.ActivateGameTimer();
            resetTime.IncreaseGameTime(0);
            resetTime.StartCoroutine("MatchGameTimer");
            scores.SetActive(false);

        }

    public void LeaveRoom()
        {
            print("oi");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.DestroyAll();
            
           
           
        }
    // Update is called once per frame
  
}
}




