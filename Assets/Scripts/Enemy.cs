using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	private Image healthBar;
	int health, maxhealth, hitvalue;

	void Start(){
		healthBar = transform.FindChild ("EnemyCanvas").FindChild ("HealthBG").FindChild ("Health").GetComponent<Image> ();
		health = 100;
		maxhealth = 100;
		hitvalue = 20;
	}


	void OnParticleCollision(GameObject obj){
		if (gameObject.tag == "Enemy") {
			gameObject.GetComponent<Enemy> ().Shoot (hitvalue);
		}
		if (gameObject.tag == "Skeleton") {
			gameObject.GetComponent<Enemy> ().Shoot (hitvalue);
		}

	}
	public void Shoot(int dmg){
		health -= dmg;
		healthBar.fillAmount =(float)health/(float)maxhealth;
		Debug.Log (health);
		if (health == 0){
			gameObject.SetActive (false);
			Debug.Log ("EnemyDown");
		}
	}
		
}
