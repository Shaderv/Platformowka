using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	protected ParticleSystem shoot;
	public static Shooting instance = null;
	Enemy enemy;


	private Image healthBar;
	int health, maxhealth, hitvalue = 20;


	void Awake(){
		instance = this;
	}

	void Start(){
		shoot = GetComponent<ParticleSystem> ();
		shoot.enableEmission = false;
	}

	void Update(){
		
		if (Input.GetKeyDown(KeyCode.Space)) {
			shoot.enableEmission = true;
			shoot.Emit (1);
		}
	}
	void OnParticleCollision(GameObject obj){
		if (obj.tag == "Enemy") {
			OnEnemyShotEventSender ();
		}
		if (obj.tag == "Skeleton") {
			OnEnemyShotEventSender ();
		}
}

	public event System.Action OnEnemyShot;
	void OnEnemyShotEventSender(){
		if (OnEnemyShot != null) 
		{
			OnEnemyShot ();
		}
	}


	void Shoot(int dmg){
		health -= dmg;
		healthBar.fillAmount =(float)health/(float)maxhealth;
		Debug.Log (health);
		if (health == 0){
			gameObject.SetActive (false);
			Debug.Log ("EnemyDown");
		}
	}



}