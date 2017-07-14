using UnityEngine;
using System.Collections;

public class Floating : MonoBehaviour {
	
	private PlayerMovement PMscript;
	private GameObject player;

	void Start(){
		player = GameObject.FindGameObjectWithTag ("Player");

		PMscript = player.GetComponent<PlayerMovement> ();
	}



	void OnTriggerEnter(Collider other)
	{
		if (other.rigidbody == true) {
			other.rigidbody.AddForce (Vector3.up * other.rigidbody.mass * 10f);
		}
	}

	void OnTriggerStay(Collider other)
	{
		//if ((Time.time - counter) < 1f)
			//other.rigidbody.AddForce (Vector3.up * other.rigidbody.mass * 15f, ForceMode.Force);
		//else 
			if (other.rigidbody == true && !PMscript.isPaused) {
				other.rigidbody.AddForce (Vector3.up * other.rigidbody.mass * 4.99f, ForceMode.Force);
			}
	}

}
