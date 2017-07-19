using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receiver : MonoBehaviour 
{
	private ManInstance maninstance;

	void Start () 
	{
		if (ManInstance.instance != null) 
		{
			maninstance = ManInstance.instance;
		}

		if (maninstance != null) 
		{
			ManInstance.instance.OnInstanceChanged += handleOnInstanceChanged;
			maninstance.OnFloatAndStringChanged += handleOnFloatAndStringChanged;
		}

		if (Movement.instance != null) 
		{
			Movement.instance.CharacterJumped += handlePlayerJumped;
		}

		if (Shooting.instance != null) {
			
			Shooting.instance.OnEnemyShot += handleOnEnemyShot;
		}
		if (EnemyShoot.instance != null) {

			EnemyShoot.instance.OnPlayerShot += handleOnPlayerShot;
		}

	}

	void OnDestroy()
	{
		if (maninstance != null) 
		{
			maninstance.OnInstanceChanged -= handleOnInstanceChanged;
			maninstance.OnFloatAndStringChanged -= handleOnFloatAndStringChanged;

		}
		if (Movement.instance != null) 
		{
			Movement.instance.CharacterJumped -= handlePlayerJumped;
		}
		if (Shooting.instance != null) {

			Shooting.instance.OnEnemyShot -= handleOnEnemyShot;
		}
		if (EnemyShoot.instance != null) {

			EnemyShoot.instance.OnPlayerShot -= handleOnPlayerShot;
		}
	}
	void handleOnEnemyShot(){
		Debug.Log ("Enemy was shot");
	}
	void handleOnPlayerShot(){
		Debug.Log ("Player was shot");
	}

	void handlePlayerJumped()
	{
		Debug.Log ("HEY I'VE JUST JUMPED");
	}

	void handleOnFloatAndStringChanged(float x, string s)
	{
		Debug.LogError (x.ToString () + " " + s);
	}

	void handleOnInstanceChanged()
	{
		Debug.LogError ("handle on instance changed");
	}

	void Update () {
		
	}
}
