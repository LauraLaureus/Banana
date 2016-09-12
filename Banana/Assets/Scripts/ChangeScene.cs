using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void changeScene(string scene){
		if (scene.Equals ("Quit"))
			Application.Quit ();
		else
			SceneManager.LoadScene (scene);
	}


}
