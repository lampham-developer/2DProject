using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public void backToMainMenu(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
	}

    public void restartGame(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void resumeGame(){
		Time.timeScale = 1;
	}

	public void pauseGame(){
        Time.timeScale = 0;
    }
}
