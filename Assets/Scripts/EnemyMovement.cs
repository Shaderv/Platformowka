using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	float speed = 3;
	float origX;
	int distance = 10;
	public Vector3 theScale;
	private float useSpeed;

	void Start ()
	{
		origX = transform.position.x;
		theScale = transform.localScale;
		Debug.Log (origX);
	}
	void Update (){
		
	}
	void FixedUpdate(){
		moveEnemy ();
	}


	void moveEnemy(){
		if (gameObject.tag == "Enemy") {
			if (transform.position.x < origX + 0.1) {
				theScale.x = (float)0.2;
				transform.localScale = theScale;
				useSpeed = speed;
				Debug.Log (transform.position.x);
			} else if (transform.position.x > origX + distance) {
				theScale.x = (float)-0.2;
				transform.localScale = theScale;
				useSpeed = -speed;
			}
			transform.Translate (useSpeed * Time.deltaTime, 0, 0);
		}
		if (gameObject.tag == "Skeleton") {
			if (transform.position.x < origX + 0.1) {
				theScale.x = (float)9;
				transform.localScale = theScale;
				useSpeed = speed;
				Debug.Log (transform.position.x);
			} else if (transform.position.x > origX + distance) {
				theScale.x = (float)-9;
				transform.localScale = theScale;
				useSpeed = -speed;
			}
			transform.Translate (useSpeed * Time.deltaTime, 0, 0);
		}		
	}
}