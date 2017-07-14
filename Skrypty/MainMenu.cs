using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void QuitGame(){
		Debug.Log ("GameExited");
		Application.Quit();
	}

	public void PlayGame(){
		Debug.Log ("GameStarted");
		Screen.showCursor = false;
		Application.LoadLevel ("Level1");
	}
}
