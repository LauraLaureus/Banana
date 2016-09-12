using UnityEngine;
using System.Collections;

public class ForwardKeyController : MonoBehaviour {

	public float boosterSpeed = 2;
	public short maxSpeedBooster = 3;
	public short speedBoosterUsed = 0;

	public float useSpeedBooster(){
		if (speedBoosterUsed < maxSpeedBooster) {
			speedBoosterUsed += 1;
			return boosterSpeed;
		}
		else
			return 0;
	}

	public void recoverSpeedBooster(){
		speedBoosterUsed -= 1;
	}

}
