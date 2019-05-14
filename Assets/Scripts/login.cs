using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class login : MonoBehaviourPunCallbacks {
[SerializeField]
GameObject canvas;
//[SerializeField]
public InputField nomeJogador;

 //[SerializeField]
public GameObject player;

public static login instance;
Text txt;
public GameObject canvastempo; 


//singleton acesso todas as informações publicas

	 private void Awake() {

		if (instance==null)
		{
			instance=this;
			DontDestroyOnLoad(this.gameObject);
			
		}else
		{
			Destroy(gameObject);
		}
		
	canvastempo.SetActive(false);
		
	}
	// Use this for initialization
	void Start () {
		//PhotonNetwork.ConnectUsingSettings();
		PhotonNetwork.AutomaticallySyncScene=true;
		 txt=GetComponentInChildren<Text>();
	}
	
	public void btnconecta(){
		PhotonNetwork.ConnectUsingSettings();
		PhotonNetwork.NickName=nomeJogador.text;
		canvas.SetActive(false);
		print(PhotonNetwork.NickName);
	}
	// Update is called once per frame
	void Update () {
	
	}

	public override void OnConnectedToMaster() {
	
		print("conectou");
		//PhotonNetwork.JoinRandomRoom();
		PhotonNetwork.JoinLobby();
	}

	public override void OnJoinedLobby() {
		
		print("lobby");
		PhotonNetwork.JoinRandomRoom();
		
	}

	public override void OnDisconnected(DisconnectCause cause) {
		
		print("desconectou");
	}

	public override void OnJoinRandomFailed(short returnCode,string message){
		
		print("Nao existem salas");
		PhotonNetwork.CreateRoom(null, new RoomOptions());
	}
	
	public override void OnJoinedRoom(){
		print("entrei");
		print(PhotonNetwork.CurrentRoom.Name);
		print(PhotonNetwork.CurrentRoom.PlayerCount);

		canvastempo.SetActive(true);
		

		if (PhotonNetwork.IsMasterClient)
		{
			PhotonNetwork.LoadLevel(1);
			
		}
		//PhotonNetwork.Instantiate(player.name,new Vector3(Random.Range(1,8),Random.Range(1,8),Random.Range(1,8)),player.transform.rotation);
	}
}
