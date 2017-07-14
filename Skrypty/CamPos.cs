using UnityEngine;
using System.Collections;

public class CamPos : MonoBehaviour {

	public MouseOrbit mouseorbit;
	public float minDistance = 2f, maxDistance = 15f, scrollSpeed = 10f, prevPos;

	void Awake(){

		mouseorbit = GetComponent<MouseOrbit>();
	}
	
	void Start () {

		prevPos = Input.GetAxis ("Mouse ScrollWheel");
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("Mouse ScrollWheel") != prevPos)
			mouseorbit.distance -= (Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed);
	
		prevPos = Input.GetAxis ("Mouse ScrollWheel");

	}
}
