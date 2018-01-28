using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public GameObject cany;
    public Vector3 hpoffset = new Vector3(0,6,0);
    public Camera cam;
    public Vector3 offset;
    public Quaternion rot;
    public GameObject nameofplayerholder;

    [SyncVar]
    public int hp = 100;


    public override void OnStartLocalPlayer()
    {
        Camera camerathing = Instantiate(Resources.Load("personcam", typeof(Camera))) as Camera;
        offset = new Vector3(-0.68f, 19.31f, 26.65f);
        cam = camerathing;
        cam.transform.position = offset;
        GetComponent<MeshRenderer>().material.color = Color.blue;
        Debug.Log(hp);
        GameObject playerhps = Instantiate(Resources.Load("Playerhp", typeof(GameObject))) as GameObject;
        cany = playerhps;
        nameofplayerholder = Instantiate(Resources.Load("playernameholder", typeof(GameObject))) as GameObject;
        GameObject.FindGameObjectWithTag("playerhp").GetComponent<Text>().text = nameofplayerholder.GetComponent<name>().playername;

    }

    [Command]
    void CmdFire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            transform.position - -transform.forward,
            Quaternion.identity);


        // make the bullet move away in front of the player
        bullet.GetComponent<Rigidbody>().velocity = transform.forward + this.transform.forward * 8;
        // make bullet disappear after 2 seconds

        NetworkServer.Spawn(bullet);

 

        Destroy(bullet, 2.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "wall1")
        {
            Debug.Log("hit ye ya fucking wall boii");
        }
        if (collision.gameObject.tag == "Player")
        {
            hp = hp - 5;
            Debug.Log(hp);
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (!isLocalPlayer)
        {
            return;
        }

        if(cam.enabled == false)
        {
            cam.enabled = true;
        }



        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 9.0f;


        cam.transform.position = this.transform.position + offset;

        cany.transform.position = this.transform.position + hpoffset;



        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

    }


}
