using UnityEngine;
using System.Collections;

public class shot_controller : MonoBehaviour
{

		// Speed to be modified in the Inspector
		public float speed = 60.0f;
		
		void Start ()
		{
				// Give the ball some initial movement direction
				rigidbody2D.velocity = Vector2.one.normalized * speed;
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
		if (coll.gameObject.tag == "boundary") {
			//Hit boundary, bounce off
			//Debug.Log ("wall collison");		
		} else {
			//Debug.Log ("other collison");	
			//1. Zombie - thit luon
			//2. Hero - Kill yourself
		}

		}
}