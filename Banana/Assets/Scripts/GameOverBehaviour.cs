using UnityEngine;
using System.Collections;

public class GameOverBehaviour : MonoBehaviour {

	public GameObject background;
	public GameObject text;
	public GameObject playButton;
	public GameObject menuButton;


	

	void gameover () {
		
		background.SetActive (true);
		text.SetActive (true);
		playButton.SetActive (true);
		menuButton.SetActive (true);
		Time.timeScale = 0;
	}


}
