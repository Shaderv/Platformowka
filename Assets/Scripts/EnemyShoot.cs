using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyShoot : MonoBehaviour {

	protected ParticleSystem enemyShoot;
	public static EnemyShoot instance = null;

	void Awake(){
		instance = this;
	}

	void Start(){
		enemyShoot = GetComponent<ParticleSystem> ();
		enemyShoot.enableEmission = true;
	}

	void Update(){

		enemyShoot.enableEmission = true;
		enemyShoot.Emit (1);
	}
	void OnParticleCollision(GameObject obj){
		if (obj.tag == "Player") {
			OnPlayerShotEventSender ();
		}
	}
		


	public event System.Action OnPlayerShot;
	void OnPlayerShotEventSender(){
		if (OnPlayerShot != null) 
		{
			OnPlayerShot ();
		}
	}
		
}