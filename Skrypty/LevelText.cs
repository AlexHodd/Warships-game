using UnityEngine;
using System.Collections;

public class LevelText : MonoBehaviour {

	private float counter;

	// Use this for initialization
	void Start () {
	
		counter = Time.time;
	}
	
	// Update is called once per frame
	void Update () {

		if ((Time.time - counter) > 6f)
			gameObject.SetActive (false);

	
	}
}
