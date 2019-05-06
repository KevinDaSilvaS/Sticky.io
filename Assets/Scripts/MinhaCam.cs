using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class MinhaCam : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera vcam;
     [SerializeField]
    Camera cam;
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        Instantiate(cam);
        Instantiate(vcam);
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
