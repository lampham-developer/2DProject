using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{

	public static GameMenuScript GameMenuSingleton;

	private void Start() {
		GameMenuSingleton = this;
	}

    public void backToMainMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
	}

    public void restartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void resumeGame(){
		GameController.ControllerSingleton.resumeGame();
	}

	public void pauseGame(){
        GameController.ControllerSingleton.pauseGame();
    }
}
