using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	public GameObject enemy;
	public float score = 0;
	public float distance;

	
	// Update is called once per frame
	void FixedUpdate () {
		distance = Vector3.Distance (enemy.transform.position, transform.position);
		score += Mathf.Round(distance * Time.fixedDeltaTime);
	}
}
