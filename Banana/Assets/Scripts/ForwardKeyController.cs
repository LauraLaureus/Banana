using UnityEngine;
using System.Collections;

public class ForwardKeyController : MonoBehaviour {

	public float boosterSpeed = 2;
	public short maxSpeedBooster = 3;
	public short speedBoosterUsed = 0;

	public float boosterTimer = 2;
	public float timer = 2;

	public float useSpeedBooster(){
		
			if (speedBoosterUsed < maxSpeedBooster) {
				if (!coolDown ()) {
					speedBoosterUsed += 1;
					timer = 0;
					return boosterSpeed;
				} else {
					return boosterSpeed * (1 - timer / boosterTimer);
				}
				
			} else
				return 0;
		
	}

	public float getCoolDownSpeed(){
		if (timer / boosterTimer > 1)
			return 0;
		else
			return boosterSpeed * (1 - timer / boosterTimer);
	}

	void Update(){
		timer += Time.deltaTime;
	}

	public void recoverSpeedBooster(){
		speedBoosterUsed -= 1;
		if (speedBoosterUsed < 0)
			speedBoosterUsed = 0;
	}

	bool coolDown(){
		return timer < boosterTimer;
	}
}
