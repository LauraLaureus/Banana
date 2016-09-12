using UnityEngine;
using System.Collections;

public class OnCollisionExitDestroy : MonoBehaviour {
	
	void OnCollisionExit(Collision col){
		if (col.collider.gameObject.name == "Enemy")
			Destroy (gameObject);
	}
}
