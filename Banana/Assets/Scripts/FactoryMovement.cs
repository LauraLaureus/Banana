using UnityEngine;
using System.Collections;

public class FactoryMovement : MonoBehaviour {

	public float forwardAdjustement;
	public float playerForward;

	private Rigidbody rb;

	void Start(){
		rb = this.gameObject.GetComponent<Rigidbody> ();
	}

	void OnEnable(){
		DifficultyController.shareDifficulty += updateDifficulty;
		UserCharacterController.onPlayerForward += updatePlayerForward;
	}

	void updateDifficulty(float d){
		forwardAdjustement = d;
	}

	void updatePlayerForward(float d){
		playerForward = d;
	}

	void OnDisable(){
		DifficultyController.shareDifficulty -= updateDifficulty;
		UserCharacterController.onPlayerForward -= updateDifficulty;
	}


	void FixedUpdate () {
		rb.velocity = Vector3.forward*(forwardAdjustement+playerForward);
	}
}
