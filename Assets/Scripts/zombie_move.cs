using UnityEngine;
using System.Collections;

public class zombie_move : MonoBehaviour
{		
		public Transform target;
		/// Object speed
		public float speed = 0.4f;

		void Update ()
		{
				transform.position = Vector2.MoveTowards (transform.position, target.position, speed * Time.deltaTime);
			Debug.Log (target.position);
			Debug.Log (transform.position);
		}
		
		void FixedUpdate ()
		{
				// Apply movement to the rigidbody
//				rigidbody2D.velocity = movement;
		}
}