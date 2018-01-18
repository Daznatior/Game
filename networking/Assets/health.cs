using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class health : NetworkBehaviour {

    [SyncVar]
    public int hp;

    void start()
    {
        if (isLocalPlayer)
        {

            hp = 100;
            Debug.Log(hp);


        }
    }




}
