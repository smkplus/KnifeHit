using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {
	public float Speed = 2;
	public float Delay;
	public bool IsMove = true;

	void Update () {
		if(IsMove){
		transform.Translate(transform.up * Mathf.Sign(transform.rotation.z) * Time.deltaTime*Speed);
		}
	}
}
