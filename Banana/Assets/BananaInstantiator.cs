using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaInstantiator : MonoBehaviour {

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		GameObject.Instantiate (prefab, this.transform.position, Quaternion.Euler (new Vector3 (90, 0, 0)));
	}
	
	// Update is called once per frame
	//void Update () {
		
	//}
}
