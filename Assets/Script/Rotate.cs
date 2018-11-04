using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : Singleton<Rotate> {
 public int FirstHitAngle = -1;
 public int HitAngle;

 void Start(){
		StartCoroutine(Delay());
 }


		IEnumerator Delay(){
		yield return new WaitForSeconds(0.2f);
		float rotationAngle = NormalizeDegree(transform.rotation.eulerAngles.z);
		HitAngle = Mathf.RoundToInt((rotationAngle));
		print(HitAngle);
		transform.Rotate(Vector3.forward*10);
		StartCoroutine(Delay());

	}

	 public float NormalizeDegree (float angle)
 {
     if (angle < -360)
         angle += 360;
     if (angle > 360)
         angle -= 360;
     return angle;
 }

}
