using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CriaPlayer : MonoBehaviourPunCallbacks {

	// Use this for initialization
	void Start () {
		PhotonNetwork.Instantiate(login.instance.player.name,
		new Vector3(Random.Range(1,8),5,Random.Range(1,8)),
		login.instance.player.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
