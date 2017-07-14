using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	public void QuitGame(){
		Debug.Log ("GameExited");
		Application.Quit();
	}
	
	public void ToMainMenu(){
		Debug.Log ("MainMenu");
		Screen.showCursor = true;
		Time.timeScale = 1;
		Application.LoadLevel ("MainMenu");
	}
}
