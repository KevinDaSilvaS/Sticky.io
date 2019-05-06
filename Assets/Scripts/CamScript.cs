using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;


public class CamScript : MonoBehaviour {


CinemachineVirtualCamera vcam;
public static GameObject canvas;
public GameObject pegaCanvas;
public static Transform target;
	// Use this for initialization
	void Start () {
		canvas=pegaCanvas;
	
		
	}
	
	// Update is called once per frame
	void Update () {
		
		target=transform;
			vcam=GetComponent<CinemachineVirtualCamera>();
			//vcam.m_Follow=move.alvo.transform;
			//vcam.m_LookAt=move.alvo.transform;
			vcam.m_Follow=StickyMove.alvo.transform;
			vcam.m_LookAt=StickyMove.alvo.transform;
			
		
	}
}
