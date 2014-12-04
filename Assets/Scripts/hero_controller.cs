using UnityEngine;
using System.Collections;

public class hero_controller : MonoBehaviour
{	public Transform shot_prefab;
	public float shootingRate = 0.25f;
	private float shootCooldown;
	void Start()
	{
		shootCooldown = 0f;
	}
	
	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
		//Shooting from keyboard
		bool shoot = Input.GetButtonDown("Fire1");
		shoot |= Input.GetButtonDown("Fire2");
		// Careful: For Mac users, ctrl + arrow is a bad idea
		//Shooting from Touch input
		// Look for all fingers
		if(Input.touchCount > 0){
			Touch touch = Input.GetTouch(0);
			// -- Tap: quick touch & release
			if (touch.phase == TouchPhase.Ended && touch.tapCount == 1)
			{
				// Touch are screens location. Convert to world
				Vector3 position = Camera.main.ScreenToWorldPoint(touch.position);
				Debug.Log("Touch at : " + position);
				transform.Rotate(Vector3.forward, Vector3.Angle(transform.position, position));
				// Effect for feedback
				shoot = true;
			}
		}
		if (shoot)
		{
			Attack();
		}
	}
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
	//--------------------------------
	// 3 - Shooting from another script
	//--------------------------------
	
	/// <summary>
	/// Create a new projectile if possible
	/// </summary>
	public void Attack()
	{
		if (CanAttack)
		{
			Debug.Log("Shoot one");
			shootCooldown = shootingRate;
			
			// Create a new shot
			var shotTransform = Instantiate(shot_prefab) as Transform;
			
			// Assign position, and direction
			Debug.Log ("Angle Before: " + transform.eulerAngles);
			shotTransform.position = transform.position;
			float r =  Random.Range(0f, 360f);
			shotTransform.eulerAngles += new Vector3(0, 0, r);
			transform.eulerAngles = shotTransform.eulerAngles;
			Debug.Log ("r = " + r + " " + transform.rotation + "and " +shotTransform.rotation);
			Debug.Log ("Angle After: " + transform.eulerAngles);
			//shotTransform.rotation = transform.rotation;

		}
	}
}
