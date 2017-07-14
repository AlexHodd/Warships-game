using UnityEngine;
using System.Collections;

public class TurretFollow : MonoBehaviour {
	
	public Transform gun;
	public float TurnSpeed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKey(KeyCode.E) ) {
			transform.Rotate (0, -TurnSpeed*Time.deltaTime, 0);//-PMscript.TurretTurnSpeed * Time.deltaTime, 0);
			gun.RotateAround(transform.position, Vector3.up, 25f * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Q) ) {
			transform.Rotate (0, TurnSpeed *Time.deltaTime, 0);//PMscript.TurretTurnSpeed * Time.deltaTime, 0);
			gun.RotateAround(transform.position, Vector3.down, 25f * Time.deltaTime);
		}

	}
}
