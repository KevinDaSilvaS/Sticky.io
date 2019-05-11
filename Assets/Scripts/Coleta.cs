using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Coleta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player") && other.GetComponent<PhotonView>().IsMine)
		{
			this.GetComponent<PhotonView>().RPC("bala",RpcTarget.All);
		}
	}

[PunRPC]
	void bala(){
		//Destroy(this.gameObject);
		this.transform.position=this.transform.position;
		this.transform.localScale=this.transform.localScale;
		this.transform.rotation=this.transform.rotation;
	}
}
