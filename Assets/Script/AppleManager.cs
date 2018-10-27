using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleManager : MonoBehaviour {
	public int AppleNumber = 3;

	// Use this for initialization
	void Start () {
	for(int i = 0;i< AppleNumber;i++){
	int index =	Random.Range(0,transform.childCount);
	transform.GetChild(index).gameObject.SetActive(true);	
	}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
