using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Movement : MonoBehaviour {

	public float speed;
	public float jump = 400;
	public int jumpCounter = 0;
	public bool ground = false;
	public bool rock = false;
	private Rigidbody2D movement;
	public static Movement instance = null;
	public GameObject player;

	void Awake()
	{
		instance = this;
	}

	void Start(){
		movement = GetComponent<Rigidbody2D>();
	}

	void Update (){
		if (Input.GetKey(KeyCode.LeftArrow)){
			if (movement.velocity.magnitude < 5f) 
			{
				movement.AddForce (new Vector2 (-speed, 0));
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)){
				Vector3 theScale = transform.localScale;
			theScale.x = (float)-0.2;
				transform.localScale = theScale;
		
		}
		if (Input.GetKey(KeyCode.RightArrow)){
			if (movement.velocity.magnitude < 5f) {
				movement.AddForce (new Vector2 (speed, 0));
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow)){
			Vector3 theScale = transform.localScale;
			theScale.x = (float)0.2;
			transform.localScale = theScale;

		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (rock == false) {
				if (ground == true && jumpCounter < 2) {
					jumpCounter += 1;
					movement.AddForce (new Vector2 (0, jump));
					Debug.Log (KeyCode.UpArrow);
					Jumped ();
					Debug.Log ("Aktualny jumpCounter" + jumpCounter);
				} else if (jumpCounter > 2) {
					jumpCounter = 0;
					ground = false;
					Debug.Log ("jumpCOunter obnizony do 0");
				}

			}
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			if (rock == true) {
				if (movement.velocity.magnitude < 5f) {
					movement.AddForce (new Vector2 (0, speed));
					Debug.Log ("Wspinam sie");
				}
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){

		switch (coll.collider.tag) {
		case "Ground":
			ground = true;
			jumpCounter = 0;
			break;
		case "Rock":
			rock = true;
			break;
		case "PortalEnter":
			GameObject portalExit = GameObject.FindGameObjectWithTag ("PortalExit");
			transform.position = new Vector2 (portalExit.transform.position.x + 1f, portalExit.transform.position.y);
			break;
		} 
/*//			transform.position = new Vector2 (GameObject.FindGameObjectWithTag ("Player").transform.position.x+ 
//											   (GameObject.FindGameObjectWithTag("PortalExit").transform.position.x - 
//											    GameObject.FindGameObjectWithTag ("Player").transform.position.x), 
//												 GameObject.FindGameObjectWithTag ("Player").transform.position.y+
//											     (GameObject.FindGameObjectWithTag("PortalExit").transform.position.y-
//												  GameObject.FindGameObjectWithTag ("Player").transform.position.y));
		
		}  */
	}
	void  OnCollisionStay2D(Collision2D coll){
		switch (coll.collider.tag) {
		case "Rock":
			rock = true;
			break;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if (coll.collider.tag == "Rock") {
			rock = false;
		}
	}

	public event System.Action CharacterJumped;
	void Jumped()
	{
		if (CharacterJumped != null) 
		{
			CharacterJumped ();
		}
	}
}

