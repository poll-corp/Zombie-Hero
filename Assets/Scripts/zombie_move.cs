using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour
{		
		public Transform target;
		/// Object speed
		public float speed = 0.4f;

		void Update ()
		{
				if(target != null)
					transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
				//Debug.Log (target.position);
				//Debug.Log (transform.position);
		}
		
		void FixedUpdate ()
		{
				// Apply movement to the rigidbody
//				rigidbody2D.velocity = movement;
		}

		void OnCollisionEnter2D (Collision2D coll)
		{
		if (coll.gameObject.tag == "hero") {
						Debug.Log ("zombie hit hero");	
						//Destroy(coll.gameObject);//Destry hero
						//Tam thoi xoa zombie di cho gon
					Destroy(gameObject);
				} else {
						//Debug.Log ("other collison");	
				}
		
		}

}