using UnityEngine;
using System.Collections;

public class FloorSpawn : MonoBehaviour {

	public GameObject floorPrefab;
	public GameObject backgroundPrefab;

	public float distanceToActivate;
	private Vector3 lastPosition;



	public delegate void BuildLevelEvent();
	public static event BuildLevelEvent OnNewPositionReached;
	private short distanceToBuild = 0;
	private short distanceToBackground = 0;


	void Start(){
		lastPosition = transform.position;
	}


	void FixedUpdate () {
		if (Vector3.Distance (transform.position, lastPosition) > distanceToActivate) {
			lastPosition = transform.position;
			Instantiate (floorPrefab,this.transform.position,Quaternion.identity);
			distanceToBuild += 1;
			distanceToBackground += 1;
			if (OnNewPositionReached != null && distanceToBuild == 4) {
				OnNewPositionReached ();
				distanceToBuild = 0;
			
			}

			if (distanceToBackground == 8) {
				Instantiate (backgroundPrefab,new Vector3(-8.29f,-0.66f,this.transform.position.z+2*18.5f),Quaternion.identity);
				distanceToBackground = 0;
			}
		}
	}


}
