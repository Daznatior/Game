using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class update_menu : MonoBehaviour {

	public Camera maincamera;
	public GameObject player;
	GameObject playerClone;
	Vector3 menu1pos = new Vector3 (403f, 275f, -971f);
	Vector3 menu2pos = new Vector3 (1711f, 275f, -971f);

	int Y=0;
	// Use this for initialization
	void Start () {
		var scene = SceneManager.GetSceneByName("menu");
		SceneManager.SetActiveScene(scene);
		playerClone = (GameObject)Instantiate (player, new Vector3(1727f,291f,-789f), transform.rotation);
		playerClone.transform.localScale = new Vector3(20f,20f,20f);
	}
	
	// Update is called once per frame
	void Update () {
		string ipAddress = GameObject.Find("InputField_IP").transform.Find("Text").GetComponent<Text>().text;
		var btncolors = GameObject.Find ("Button_Join").GetComponent<Button> ().colors;
		btncolors.normalColor = new Color(0,(30f/255f),0);
		if (ipAddress.Length > 4) {
			btncolors.normalColor = new Color(0,255,0);

		} 
		playerClone.GetComponent<MeshRenderer> ().material.color = new Color (GameObject.Find ("slider_r").GetComponent<Slider> ().value,
			GameObject.Find ("slider_g").GetComponent<Slider> ().value,
			GameObject.Find ("slider_b").GetComponent<Slider> ().value);
		playerClone.transform.Rotate (Vector3.up * (Time.deltaTime*10f));
		Y++;
		GameObject.Find ("Button_Join").GetComponent<Button> ().colors = btncolors;
	}


	public void tomainmenu()
	{
		GameObject.Find ("panel_main").GetComponent<CanvasGroup> ().alpha = 1f;
		GameObject.Find ("panel_blockedit").GetComponent<CanvasGroup> ().alpha = 0f;
	}

	public void toblockedit()
	{
		GameObject.Find ("panel_main").GetComponent<CanvasGroup> ().alpha = 1f;
		GameObject.Find ("panel_blockedit").GetComponent<CanvasGroup> ().alpha = 0f;
	}
}

