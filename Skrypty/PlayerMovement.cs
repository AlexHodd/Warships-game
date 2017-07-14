using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float PlayerSpeed = 20f;
	public float RotateSpeed = 25f;
	public float cam2Distance = 15f;
	public GameObject enemy, cam2, mainCam, pauseMenu;
	private PlayerHealthScript HPScript;
	private CamPos campos;
	public bool isCam2, isPaused;
	private float EngineVolume, EngineVolumeMax;
	private MouseOrbit mouseorbit;




	// Use this for initialization
	void Start () {

		HPScript = GetComponent<PlayerHealthScript>();
		pauseMenu = GameObject.Find ("PauseMenuFill");
		pauseMenu.SetActive (false);
		campos = mainCam.GetComponent<CamPos>();
		mouseorbit = GetComponentInChildren<MouseOrbit> ();
		transform.eulerAngles = new Vector3 (0, 0, 90f);
		isCam2 = false;
		cam2.SetActive (isCam2);
		gameObject.audio.pitch = 0.7f;
		isPaused = false;
		Screen.showCursor = false;



	}
	
	// Update is called once per frame
	void Update () {

		if (!HPScript.Dead && !isPaused)
		{
			if (Input.GetKey(KeyCode.W))
			{
				rigidbody.AddForce(transform.up * PlayerSpeed);
			}
			if (Input.GetKeyDown(KeyCode.W))
				gameObject.audio.pitch = 0.9f;
			if (Input.GetKeyUp(KeyCode.W))
				gameObject.audio.pitch = 0.7f;
			if (Input.GetKey(KeyCode.S))
			{
				rigidbody.AddForce(-transform.up * PlayerSpeed * 0.9f);
			}
			if (Input.GetKeyDown(KeyCode.S))
				gameObject.audio.pitch = 0.8f;
			if (Input.GetKeyUp(KeyCode.S))
				gameObject.audio.pitch = 0.7f;
			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(RotateSpeed * Time.deltaTime, 0, 0);
			}
			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(-RotateSpeed * Time.deltaTime, 0, 0);
			}

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				isCam2 = !isCam2;
				mainCam.SetActive(!isCam2);
				cam2.SetActive (isCam2);
			}
		}
		if (Input.GetKeyUp(KeyCode.Escape)){
			isPaused = !isPaused;
			PauseUnpause(isPaused);
			
			
		}


	}

	void PauseUnpause(bool b){
		if (b) {
			Time.timeScale = 0;
			gameObject.audio.enabled = !isPaused;
			Screen.showCursor = !Screen.showCursor;
			pauseMenu.SetActive(!pauseMenu.activeSelf);
			campos.enabled = !campos.enabled;
			mouseorbit.enabled = !mouseorbit.enabled;

		} else {
			Time.timeScale = 1;
			gameObject.audio.enabled = !isPaused;
			Screen.showCursor = !Screen.showCursor;
			pauseMenu.SetActive(!pauseMenu.activeSelf);
			campos.enabled = !campos.enabled;
			mouseorbit.enabled = !mouseorbit.enabled;
		}
	}
}
