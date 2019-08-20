using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public void PlayButton(){
		SceneManager.LoadScene("1stScene", LoadSceneMode.Single);
	}

	public void QuitButton(){
		Application.Quit ();
	}

	public void PauseButton(){
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
