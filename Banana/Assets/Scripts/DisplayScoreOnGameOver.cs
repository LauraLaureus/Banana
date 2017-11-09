using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayScoreOnGameOver : MonoBehaviour {


	void OnEnable(){
		string txt = "Your Score is: \n";
		txt += GameObject.Find ("Character").GetComponent<ScoreCounter> ().score.ToString();
		gameObject.GetComponent<Text> ().text = txt;
	}
}
