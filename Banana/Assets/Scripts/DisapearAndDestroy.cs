using UnityEngine;
using System.Collections;

public class DisapearAndDestroy : MonoBehaviour {

	public GameObject enemy;

	void Start(){
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
	}

	void LateUpdate(){
		if (Vector3.Distance (transform.position, enemy.transform.position) > 38f && enemy.transform.position.z > transform.position.z)
			Destroy (gameObject);
	}
}
