using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class moveBala : MonoBehaviour {

 // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody rb=this.gameObject.GetComponent<Rigidbody>();
		rb.AddRelativeForce(Vector3.forward*10,ForceMode.Impulse);
		Destroy(this.gameObject,5);
	}


		void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")  && other.GetComponent<PhotonView>().IsMine)
		{
			print("opa");
			//this.GetComponent<PhotonView>().RPC("bala",RpcTarget.All);
			other.GetComponent<move>().Danos(10);
		}
	} 


}
