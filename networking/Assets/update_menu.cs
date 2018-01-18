using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class update_menu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		string ipAddress = GameObject.Find("InputField_IP").transform.Find("Text").GetComponent<Text>().text;
		var btncolors = GameObject.Find ("Button_Join").GetComponent<Button> ().colors;
		btncolors.normalColor = new Color(0,(30f/255f),0);
		if (ipAddress.Length > 4) {
			btncolors.normalColor = new Color(0,255,0);

		} 

		GameObject.Find ("Button_Join").GetComponent<Button> ().colors = btncolors;
	}
}
