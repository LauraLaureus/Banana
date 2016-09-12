using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public GameObject prefab;
	public GameObject banana;

	private bool wasLastOneZero = false;

	void OnEnable(){
		FloorSpawn.OnNewPositionReached += generate; 
	}

	void OnDisable(){
		FloorSpawn.OnNewPositionReached -= generate;
	}

	void generate(){
		float r = Random.value;
		if (r < f ()) {
			genPlatform ();
		} 
		else{
			wasLastOneZero = true;
			genBanana (0f);
		}
	}

	float f(){
		return 0.5f;
	}

	float f2(){
		if (wasLastOneZero)
			return 0f;
		else
			return 0.5f;
	}

	float f3(){
		return 0.5f;
	}

	void genPlatform(){
		float r = Random.value;
		if (r < f2 ()) {
			genBanana (3.5f);
			Instantiate (prefab, new Vector3 (6f, 3.5f, gameObject.transform.position.z), Quaternion.identity);
		} 
		else {
			genBanana (7f);
			Instantiate (prefab, new Vector3 (6f, 7f, gameObject.transform.position.z), Quaternion.identity);
		}
	}

	void genBanana(float height){
		if (Random.value < f3())
			Instantiate (banana, new Vector3 (0.8f, height+1f, gameObject.transform.position.z), Quaternion.identity);
	}


}
