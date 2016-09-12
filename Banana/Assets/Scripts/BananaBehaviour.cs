using UnityEngine;
using System.Collections;

public class BananaBehaviour : MonoBehaviour {

		
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up *5f* Time.deltaTime,Space.World);
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.CompareTag ("Player") || col.gameObject.CompareTag ("Enemy")) {
			//mandar un mensaje al gameObject para que aumente su velocidad.
			col.gameObject.SendMessage("boosterCaught");
			Destroy (gameObject);
		}
			
	}
}
