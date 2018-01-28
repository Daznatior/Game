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
	int menuinc=0,lastmenuinc;
	float menucounter=0;
	float offscreen=1300f;
	Vector3 playerpos;

    //darrenshitty vars
    public InputField shite;

	int Y=0;
	// Use this for initialization
	void Start () {
		playerpos = new Vector3 (410.3f +offscreen,277.4f, -872.3f);
		var scene = SceneManager.GetSceneByName("menu");
		SceneManager.SetActiveScene(scene);
		playerClone = (GameObject)Instantiate (player, playerpos, transform.rotation);
		playerClone.transform.localScale = new Vector3(3f,3f,3f);

        //darrens shite
        //need to enable my name input field fk it

        shite.ActivateInputField();

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
		if (menuinc != lastmenuinc) {
			if (menuinc == 1 && menucounter>0) {
				GameObject.Find ("panel_main").GetComponent<RectTransform> ().localPosition = new Vector3 (-(offscreen)*((50-menucounter)/50f), 0, 0);
				playerClone.transform.position = playerpos -new Vector3 ((offscreen)*(menucounter/50f), 0, 0);
				GameObject.Find ("panel_blockedit").GetComponent<RectTransform> ().localPosition = new Vector3 ((offscreen)*(menucounter/50f), 0, 0);
				menucounter--;
			}

			if (menuinc == 2 && menucounter>0) {
				GameObject.Find ("panel_main").GetComponent<RectTransform> ().localPosition = new Vector3 (-(offscreen)*((menucounter)/50f), 0, 0);
				GameObject.Find ("panel_blockedit").GetComponent<RectTransform> ().localPosition = new Vector3 ((offscreen)*((50-menucounter)/50f), 0, 0);
				menucounter--;
			}


			if (menucounter <= 0) {
				lastmenuinc = menuinc;
			}
		}
	}


	public void tomainmenu()
	{
		menuinc = 2;
		menucounter = 50f;
	}
	//
	public void toblockedit()
	{
		menuinc = 1;
		menucounter = 50f;
	}
}

