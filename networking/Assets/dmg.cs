using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class dmg : NetworkBehaviour
{


   

    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall1")
        {
            Debug.Log("hit ye ya fucking wall boii");
        }
        if (collision.gameObject.tag == "Player")
        {

            GameObject.Find("Player").GetComponent<PlayerController>().hp -= 5;


     
            Debug.Log("we hit the player yay!");
        }

    }
}
