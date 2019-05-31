using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    public login getlogin;
    // Start is called before the first frame update
    void Start()
    {
       getlogin.canvas=GameObject.FindGameObjectWithTag("Canvas");
       getlogin.nomeJogador=getlogin.canvas.GetComponentInChildren<InputField>();
       getlogin.canvastempo=GameObject.FindGameObjectWithTag("Finish");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
