using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	public GameObject Prefab;
	public Transform[] ShotPos;

	private void Update() {
		int index = NetworkManager.Instance.PlayerNumber;
		var shotpos = ShotPos[0].transform.position;
		ShotPos[index].transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,shotpos.y,shotpos.z);
		if(Input.GetKeyDown(KeyCode.Mouse0)){
		Fire();	
		}
	}


	public void Fire(){
		int index = NetworkManager.Instance.PlayerNumber;
		
		var knife = Instantiate(Prefab,ShotPos[index].position,ShotPos[index].rotation);
		NetworkManager.Instance.SendShootInfo(ShotPos[index].position);

	}
}