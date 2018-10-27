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

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Apple"){
		MyGameManager.Instance.Score += 1;
		Destroy(gameObject);	
		}
		if(other.tag == "Body"){
		IsMove = false;
		transform.SetParent(other.transform);
		MyGameManager.Instance.Score += 1;
		}

		if(other.tag == "Knife"){
		MyGameManager.Instance.Loose();
		Destroy(gameObject);
		}
		
	}
}
