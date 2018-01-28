using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class name : NetworkBehaviour
{
    public string playername;

    

	// Use this for initialization
	void Start () {
		
	}

    public void setplayername()
    {
        playername = GameObject.FindGameObjectWithTag("playername").GetComponent<InputField>().text.ToString();
        Debug.Log(playername);
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
