using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausedMenuController : MonoBehaviour {
	public Transform canvas; 
	static int mainMenuIndex = 0;
	
	// Update is called once per frame
	void Update () {
		//when user presses ESC
		if(Input.GetKeyDown(KeyCode.Escape)){
			callPausedMenu ();
		}
	}

	public void callPausedMenu(){
		//if the paused menu hasn't been activited, start it
		if (canvas.gameObject.activeInHierarchy == false) {
			canvas.gameObject.SetActive(true);
			Time.timeScale = 0;
		} 
		//shut the menu down if it is on
		else {
			canvas.gameObject.SetActive(false);
			Time.timeScale = 1;
		}
	}

	public void exitToMainMenu(){
		SceneManager.LoadScene (mainMenuIndex);
	}
}
