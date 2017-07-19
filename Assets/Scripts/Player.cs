using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Image healthBar;
	int health, maxhealth, hitvalue;

	void Start(){
		SetHP ();
	}

	IEnumerator RespawnAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		Respawn ();
	}


	void OnParticleCollision(GameObject obj){
		if (gameObject.tag == "Player") {
			gameObject.GetComponent<Player> ().Shoot (hitvalue);
		}

	}

	void OnCollisionEnter2D(Collision2D coll){
		switch (coll.collider.tag) {
		case "Spikes":
			health = 0;
			healthBar.fillAmount = (float)health;
			StartCoroutine(RespawnAfterTime((float)0.1));
			break;
		}
	}

	public void Shoot(int dmg){
		health -= dmg;
		healthBar.fillAmount =(float)health/(float)maxhealth;
		Debug.Log (health);
		if (health == 0){
			transform.position = new Vector2 (-9,-8);
			SetHP();
			Debug.Log ("PlayerDown");
		}
	}
	public void SetHP(){
		healthBar = transform.FindChild ("PlayerCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
		health = 100;
		maxhealth = 100;
		hitvalue = 20;
		healthBar.fillAmount = (float)health;
	}
	public void Respawn(){
		transform.position = new Vector2 (-9, -8);
		SetHP ();
	}

}