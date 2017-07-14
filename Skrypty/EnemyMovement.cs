using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private GameObject player, returner;
	public GameObject bullet, bulletspawn;
	//private Transform bs;
	public EnemyHealth enemyhealth;
	public float EnemySpeed = 2f;
	public float delayTime = 4f;
	public float ShootDist = 50f;
	private bool isCounting;
	private float colcounter, dist, returnDist, shotcounter, Timer, TimerMax = 2f, TimerAdj = 1.5f, RandomTimer;

	void Start () {
		player = GameObject.Find ("Player");
		returner = GameObject.Find ("EnemyReturner");
		enemyhealth = GetComponent<EnemyHealth>();
		dist = Vector3.Distance(player.transform.position, transform.position);
		Vector3 relativePos = player.transform.position - transform.position;
		transform.rotation = Quaternion.LookRotation (relativePos/*, new Vector3(0,0,1)*/);
		isCounting = false;
		
	}
	// Update is called once per frame
	void Update () {


		if (!enemyhealth.Dead) {

			dist = Vector3.Distance(player.transform.position, transform.position);
			
			if (dist < 100f){

				chase();
				
			}
			
			else {

				ownbusiness();
			}
			
			
			if (colcounter > delayTime || !isCounting) {
				rigidbody.AddForce(transform.forward * EnemySpeed);
			}
			
			if (shotcounter > delayTime && dist < ShootDist){
				shotcounter = 0;
				Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation);
			}

			if (isCounting)
				colcounter += Time.deltaTime;
			shotcounter += Time.deltaTime;
			Timer += Time.deltaTime;
		}

	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.name == "Player") {
			isCounting = true;
			colcounter = 0;
		}
		//if (col.gameObject.name == "Daylight Simple Water")
			//rigidbody.AddForce (Vector3.up * rigidbody.mass * 5f, ForceMode.Acceleration);
	}
	/*
	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.name == "Daylight Simple Water") {
			rigidbody.AddForce (Vector3.up * rigidbody.mass * 1.5f, ForceMode.Acceleration);
		}
	}
	*/
	void chase(){
		Vector3 relativePos = player.transform.position - transform.position;
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(relativePos), Time.deltaTime * 6);
		//Debug.Log("ChasingPlayer, Distance = " + dist, gameObject);
	}

	void ownbusiness(){
		if (Timer > RandomTimer) {
			Timer = 0;
			RandomTimer = TimerMax + Random.Range (-TimerAdj, TimerAdj);
			returnDist = Vector3.Distance (returner.transform.position, transform.position);
			if (returnDist > 700f) {
				Vector3 returnPos = returner.transform.position - transform.position;
				transform.rotation = Quaternion.LookRotation (returnPos/*, new Vector3(0,0,1)*/);
				//Debug.Log("Returning, Distance = " + returnDist, gameObject);
				
			} else {
				Quaternion newRotation = transform.rotation;
				newRotation.SetLookRotation (Vector3.left * Random.Range (-20f, 20f));
				transform.rotation = Quaternion.Slerp (transform.rotation, newRotation, Time.deltaTime * 3f);
				//Debug.Log("ChangingCourse from :"+transform.rotation+" to: "+newRotation, gameObject);
			}
		}
	}
}
