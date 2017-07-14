using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {

	public float wysokosc = 30f;

	public Texture2D crosshairTex;

	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (Screen.width / 2 - 20f, Screen.height / 2 - wysokosc, 100, 100), crosshairTex);
	}
}
