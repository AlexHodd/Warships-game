using UnityEngine;
using System.Collections;

public class Level1Manager : MonoBehaviour {

	private float counter;

	void Start () {
		counter = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - counter)>10f && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0)
			Application.LoadLevel ("Level2");
		
	}
}
