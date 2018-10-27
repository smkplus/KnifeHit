using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Singleton<Rotate> {
 public int Counter;
 public Quaternion FirstRotation;

	void Update () {
		Counter++;
		transform.rotation = Quaternion.Euler(0,0,3*Counter);

		if(NormalizeDegree(FirstRotation.eulerAngles.z) == NormalizeDegree(transform.eulerAngles.z)){
		Player.Instance.Fire(1);
	}

	}

	float NormalizeDegree(float angle){
		angle = (angle > 180) ? angle - 360 : angle;
        angle = Mathf.Round(angle);
        angle = Mathf.FloorToInt(angle);
		return angle;
	}
}
