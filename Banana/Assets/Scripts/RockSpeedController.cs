using UnityEngine;
using System.Collections;

public class RockSpeedController : MonoBehaviour {

	private Vector3 speed;
	public float difficulty;

	private Rigidbody rb;
	private float boosterIncrement = 0;

	void OnEnable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}

	void updateDifficulty(float d){
		difficulty = d;
	}

	void OnDisable(){
		DifficultyController.shareDifficulty += updateDifficulty;
	}

	// Use this for initialization
	void Start () {
		speed = Vector3.forward;
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = speed * (difficulty+boosterIncrement);
	}

	void boosterCaught(){
		boosterIncrement = 3;
	}
}
