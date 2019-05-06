using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
public class canvasJogador : MonoBehaviour {

[SerializeField]
PhotonView pv;

[SerializeField]
Text nomeJogador;

[SerializeField]
GameObject canvas;

public GameObject cam;
	// Use this for initialization
	void Start () {
		//cam=GetComponentInParent<Camera>();
		pv=this.gameObject.GetComponentInParent<PhotonView>();
		nomeJogador.text=pv.Owner.NickName;
		if (pv.IsMine)
		{
			
			nomeJogador.color=Color.blue;
		}

	}
	
	// Update is called once per frame
	void Update () {
		//canvas.gameObject.transform.LookAt(Camera.main.transform);
		
		canvas.gameObject.transform.LookAt(cam.transform);
	}
}
