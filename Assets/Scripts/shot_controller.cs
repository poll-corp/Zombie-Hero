using UnityEngine;
using System.Collections;

public class shot_controller : MonoBehaviour
{

		// Speed to be modified in the Inspector
		public float speed ;
		public int count_coll;
		void Start ()
		{
				// Give the ball some initial movement direction
				rigidbody2D.velocity = Vector2.one.normalized * speed;
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
		count_coll = count_coll + 1;
		Debug.Log ("COUNT = " + count_coll);
		if (coll.gameObject.tag == "boundary") {
			//Hit boundary, bounce off
			Debug.Log ("Shot: hit wall");		
		} else {
			//Debug.Log ("other collison");	
			//1. Zombie -thit luon
			if(coll.gameObject.tag == "zombie"){
				Debug.Log ("Shot: hit zombie");
				if(count_coll == 1){
					// = 1: bounce off
				}else{
					// = 2: kill zombie, remove shot
					Destroy(coll.gameObject);
					Destroy(gameObject);
				}
			}else{
				if(coll.gameObject.tag == "hero"){
					//hero - kill hero, remove shot
					Debug.Log ("Shot: hit hero");
					//Destroy(coll.gameObject);
					//Destroy(gameObject);
				} else{//Dan gap nhau, romove ca hai, Ban chan
					if(coll.gameObject.tag == "shot"){
						Destroy(coll.gameObject);
						Destroy(gameObject);
					}
				}
			}
		}
		if(count_coll == 2){
			Destroy(gameObject);
		}

		
	}
}