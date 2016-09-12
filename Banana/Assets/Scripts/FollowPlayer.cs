using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;
	public float distance;
	public float height;


	void LateUpdate () {
		if (player != null) {
			transform.position = player.transform.position + Vector3.right * distance + Vector3.up * height;
			transform.LookAt (player.transform.position);
		}
	}
}
