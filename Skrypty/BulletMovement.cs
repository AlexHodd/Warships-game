using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour {
	
	public float bulletForce = 3f;
	public float bulletUpForce = 1f;
	public float bulletLifeTime = 10f;
	private float lifeTimeCounter;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(transform.forward * bulletForce, ForceMode.Impulse);
		rigidbody.AddForce(transform.up * bulletUpForce, ForceMode.Impulse);
		rigidbody.useGravity = true;
		lifeTimeCounter = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		lifeTimeCounter += Time.deltaTime;
		if (lifeTimeCounter > bulletLifeTime)
			Destroy (gameObject);
		
	}
}
