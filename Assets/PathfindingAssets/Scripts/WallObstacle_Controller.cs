using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle_Controller : MonoBehaviour {

    [SerializeField] private Transform proxy;
    private Vector3 proxyLoc;
    //private Vector3 spriteLoc;

    private Vector3 proxyScale;
    //private Vector3 spriteScale;


    
    void Start() {
        transform.parent = proxy.transform.parent = null;


        //spriteLoc = new Vector3(transform.GetComponentInParent<Transform>().position.x, transform.GetComponentInParent<Transform>().position.y, 0f);
        //If you change the location of the 3D maze (the height), you must also change -19f to the appropriate value
        proxyLoc = new Vector3(transform.GetComponentInParent<Transform>().position.x, -19f, transform.GetComponentInParent<Transform>().position.y);

        //spriteScale = new Vector3(transform.GetComponentInParent<Transform>().localScale.x, transform.GetComponentInParent<Transform>().localScale.y, transform.GetComponentInParent<Transform>().localScale.z);
        proxyScale = new Vector3(transform.GetComponentInParent<Transform>().localScale.x, 1f, transform.GetComponentInParent<Transform>().localScale.y);

        //transform.parent = null;
        //proxy.transform.parent = null;
        //GetComponentInParent<Transform>().position = new Vector3(0f, 0f, 0f);
        //GetComponentInParent<Transform>().localScale = new Vector3(1f, 1f, 1f);

        //transform.position = spriteLoc;
        //transform.localScale = spriteScale;

        proxy.transform.position = proxyLoc;
        proxy.transform.localScale = proxyScale;

       // proxy.transform.localScale = new Vector3(proxy.localScale.x, 1f, proxy.localScale.y);

    }
}
