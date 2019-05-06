using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class connection : MonoBehaviourPunCallbacks {

	// Use this for initialization
	void Start () {
		PhotonNetwork.ConnectUsingSettings();
		/*if (PhotonNetwork.IsConnected)
		{
			print("conectou");
		}else
		{
			print("desconectou");
		} */
	}
	
	// Update is called once per frame
	void Update () {
		
		/*if (Input.GetKeyDown(KeyCode.Space))
		{
			PhotonNetwork.Disconnect();
		} */
	}

	public override void OnConnectedToMaster() {
		//base.OnConnectedToMaster();
		print("conectou");
		//PhotonNetwork.JoinRandomRoom();
		PhotonNetwork.JoinLobby();
	}

	public override void OnJoinedLobby() {
		
		print("lobby");
		PhotonNetwork.JoinRandomRoom();
		
	}

	public override void OnDisconnected(DisconnectCause cause) {
		//base.OnDisconnected();
		print("desconectou");
	}

	public override void OnJoinRandomFailed(short returnCode,string message){
		//base.OnJoinRandomFailed(returnCode,message);
		print("Nao existem salas");
		PhotonNetwork.CreateRoom(null, new RoomOptions());
	}

	public override void OnJoinedRoom(){
		print("entrei");
	}
}
