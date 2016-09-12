using UnityEngine;
using System.Collections;

public class OnCollisionEnterDestroy : MonoBehaviour {

	void OnCollisionEnter(Collision col){
		if (col.collider.gameObject.name == "Enemy")
			Destroy (gameObject);
	}
}
