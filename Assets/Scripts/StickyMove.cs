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

   
    // Start is called before the first frame update
    void Start()
    {
        
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
      // ui.SetActive(true);
        //target=rotacionar.target.transform;
        if (respawn==false)
        {
            if (pv.IsMine)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                
                    //transform.Translate(new Vector3(0,0,2));
                    this.transform.GetComponent<Rigidbody>().AddForce(cam.transform.forward * thrust*15);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    
                    //transform.Translate(new Vector3(0,0,-2));
                    this.transform.GetComponent<Rigidbody>().AddForce( -cam.transform.forward * -thrust*-15);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    cam.transform.RotateAround(this.transform.position, new Vector3(0.0f, -/*1*/5.0f, 0.0f), 10 * Time.deltaTime * speedMod);
                //target.transform.Translate(-Vector3.right * Time.deltaTime);
                    //cam.transform.Rotate(this.transform.position*Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    cam.transform.RotateAround(this.transform.position, new Vector3(0.0f, /*1 */5.0f, 0.0f), 10 * Time.deltaTime * speedMod);
                // target.transform.Translate(Vector3.right * Time.deltaTime);
                    //target.transform.Rotate(new Vector3(0,1.5f,0)*Time.deltaTime);
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
            if (stmv.size<this.size &&  other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                size+=15;
                print(stmv.size);
                print(size);
                //other.transform.localScale=new Vector3(1,1,1);
                //other.transform.DetachChildren();
                //stmv.size=1;
                stmv.StartCoroutine(Timer());
               pv.RPC("Timer",RpcTarget.AllBuffered);
                //stmv.respawn=true;
                print("venceu");
                other.gameObject.transform.position=new Vector3(0,25,0);
                
            }else if (stmv.size>this.size &&  other.gameObject.GetComponent<PhotonView>().IsMine)
            {
                stmv.size+=15;
                //this.transform.DetachChildren();
               // size=1;
                StartCoroutine(Timer());
                pv.RPC("Timer",RpcTarget.AllBuffered);
               // respawn=true;
                print("morreu");
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


    [PunRPC] 
    IEnumerator Timer(){
        respawn=true;
        Debug.Log("start");
        ui.SetActive(true);
       this.GetComponent<Collider>().enabled=false;
        yield return new WaitForSeconds(3);
        
        podecolidir=false;
        
        
         StartCoroutine(tempocolisao());
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

    private void FixedUpdate() {
       // this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(unitV2.x,0,unitV2.y)*z*3);
    }
}
