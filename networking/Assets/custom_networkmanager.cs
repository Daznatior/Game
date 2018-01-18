using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class custom_networkmanager : NetworkManager {

	public void StartupHost()
	{
        SetPort();
		NetworkManager.singleton.StartHost ();
	}
	public void JoinGame()
	{
		SetIPAddress();
		SetPort ();
		NetworkManager.singleton.StartClient ();

	}
	public void SetIPAddress()
	{
		string ipAddress = GameObject.Find("InputField_IP").transform.Find("Text").GetComponent<Text>().text;
		NetworkManager.singleton.networkAddress = ipAddress;
	}
	void SetPort()
	{
		NetworkManager.singleton.networkPort = 20015;

	}
}
