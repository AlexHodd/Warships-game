using UnityEngine;
using System.Collections;

public class ZoomCameraFollow : MonoBehaviour {

	public float turnSpeed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.E) )
			transform.Rotate (0, -turnSpeed *Time.deltaTime, 0);
		if (Input.GetKey(KeyCode.Q) )
			transform.Rotate (0, turnSpeed *Time.deltaTime, 0);
	
	}
}
