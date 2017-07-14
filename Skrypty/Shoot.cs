using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;
	public float delayTime = 3f;
	private float counter;
	public Transform target;
	private GameObject player;
	private PlayerMovement PMscript;

	// Use this for initialization
	void Start () {
		counter = 0f;
		player = GameObject.FindGameObjectWithTag ("Player");
		PMscript = player.GetComponent<PlayerMovement> ();

	
	}
	
	// Update is called once per frame
	void Update () {

		//self.position = target.position;
		transform.eulerAngles = target.eulerAngles;
		transform.Rotate (-90f, 0, 0);
		//transform.Translate (-0.3f, 0, 0);
		if ((Input.GetKey (KeyCode.Mouse0)|| Input.GetKey(KeyCode.Space))&& counter > delayTime && !PMscript.isPaused) 
		{
			Instantiate(bullet, transform.position, transform.rotation);
			counter = 0;
		}
	
		counter += Time.deltaTime;
	}
}
