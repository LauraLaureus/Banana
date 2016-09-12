using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BooterDisplay : MonoBehaviour {

	private GameObject player;
	private Text txt;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		txt = gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void LateUpdate () {
		if (player != null)
			txt.text = "Left" + (3 - player.GetComponent<ForwardKeyController> ().speedBoosterUsed).ToString();
	}
}
