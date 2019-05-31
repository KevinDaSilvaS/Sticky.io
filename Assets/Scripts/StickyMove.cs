using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Cinemachine;
public class StickyMove : MonoBehaviour
{
    [SerializeField]
    PhotonView pv;
    public static Transform alvo;
    public Transform cam;
    public GameObject ui;
    public float thrust=3;

   public string jogador;
    // Start is called before the first frame update
    void Start()
    {
        jogador=PhotonNetwork.NickName;
        //
        pv.GetComponent<PhotonView>();
		if (pv.IsMine)
		{
			alvo=this.transform;
		}
    }
    
    private float speedMod = 30.0f;
    // Update is called once per frame
    #region  movimentacao
    void Update()
    {
       print(respawn);
       cam=CamScript.target.transform;
       ui=CamScript.canvas;

        if (respawn==false)
        {
            if (pv.IsMine)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                
                   
                    this.transform.GetComponent<Rigidbody>().AddForce(cam.transform.forward * thrust*/* 1*/5);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    
                    
                    this.transform.GetComponent<Rigidbody>().AddForce( -cam.transform.forward * -thrust*-/* 1*/5);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    cam.transform.RotateAround(this.transform.position, new Vector3(0.0f, -5.0f, 0.0f), 10 * Time.deltaTime * speedMod);
               
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    cam.transform.RotateAround(this.transform.position, new Vector3(0.0f, 5.0f, 0.0f), 10 * Time.deltaTime * speedMod);
 
                }
            }
            
            
        }
     
    }
    #endregion
    #region  colisao objetos
    public  float size=1;
    
    private void OnTriggerEnter(Collider other) {
        
        if (other.transform.CompareTag("Sticky"))
        {
            if (0<size)
            {
                this.transform.localScale+= new Vector3(0.1f,0.1f,0.1f);
                size+=0.01f;
                CinemachineVirtualCamera cinecam= cam.GetComponent<CinemachineVirtualCamera>();
                cinecam.m_Lens.FieldOfView++;
                other.enabled=false;
                other.transform.SetParent(this.transform);
            }
            
        }
    }
    #endregion
    #region colisao players
    private void OnCollisionEnter(Collision other) {
        
        if (other.gameObject.CompareTag("Player") && podecolidir==true )
        {
            print("colidiu");
            StickyMove stmv=other.gameObject.GetComponent<StickyMove>();
            if (stmv.size>this.size /* &&  !other.gameObject.GetComponent<PhotonView>().IsMine*/)
            {
                //this.size+=15;
                print(stmv.size);
                //print(size);
                //other.transform.localScale=new Vector3(1,1,1);
                //other.transform.DetachChildren();
                //stmv.size=1;
                /* stmv.StartCoroutine(Timer());*/

                print("venceu");
                this.gameObject.transform.position=new Vector3(0,25,0);
                
            }else
            {
                print("continue tentando");
            }
        }
    }
    #endregion
    #region coroutine timer respawn
     public bool respawn=false;
     public bool podecolidir=true;


    //[PunRPC] 
    IEnumerator Timer(){
        respawn=true;
        Debug.Log("start");
        ui.SetActive(true);
       this.GetComponent<Collider>().enabled=false;
        yield return new WaitForSeconds(3);
        
        podecolidir=false;
        
        
         StartCoroutine(tempocolisao());
         StopCoroutine(Timer());
        Debug.Log("finalizou");
       
    }
    #endregion

    IEnumerator tempocolisao(){
        respawn=false;
        if (respawn!=false)
        {
            respawn=false;
        }
        ui.SetActive(false);
        gameObject.transform.position=new Vector3(0,5,0);
        yield return new WaitForSeconds(3);
        this.GetComponent<Collider>().enabled=true;
        podecolidir=true;
        StopAllCoroutines();
    }

   
}
