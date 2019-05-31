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
  

     public override void OnLeftRoom()
        {
            //PhotonNetwork.LoadLevel(1);
            SceneManager.LoadScene(0);
           // PhotonNetwork.DestroyAll();
            //PhotonNetwork.Disconnect();
            print("me desconecte pfffff");
        }

    public void LeaveRoom()
        {
            print("oi");
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LeaveLobby();
            PhotonNetwork.DestroyAll();
            //SceneManager.LoadScene(0);
            //PhotonNetwork.Disconnect();
           
        }
    // Update is called once per frame
  
}
}




