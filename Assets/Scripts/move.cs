using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class move : MonoBehaviour {

[SerializeField]
PhotonView pv;

[SerializeField]
GameObject bala;

[SerializeField]
GameObject pos;

Camera cam;
public static Transform alvo;
	// Use this for initialization
	void Start () {
		pv.GetComponent<PhotonView>();
		if (pv.IsMine)
		{
			alvo=transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (pv.IsMine)
		{
			if (Input.GetKey(KeyCode.UpArrow))
			{
				transform.Translate(new Vector3(0,0,2));
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.Translate(new Vector3(0,0,-2));
			}
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				transform.Rotate(new Vector3(0,-5,0));
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
				transform.Rotate(new Vector3(0,5,0));
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				//Tiros();
				pv.RPC("Tiros",RpcTarget.All);
			}
		}

		 if (vida<=0)
		{
			//Destroy(this.gameObject);
			print("oi");
		}
	}

[PunRPC]
	void Tiros(){

		//PhotonNetwork.Instantiate(bala.name,pos.transform.position,bala.transform.rotation);
		Instantiate(bala,pos.transform.position,bala.transform.rotation);
	}

 float vida=10;
	public void Danos(float dano){

		pv.RPC("callDamage",RpcTarget.AllBuffered,dano);

	}

[PunRPC]
	void callDamage(float dano){
		vida-=dano;
		print("chamou");
	}
}
