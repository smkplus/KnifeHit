using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player> {
	public GameObject Prefab;
	public Transform[] ShotPos;
	public bool NextTurn;
	public string PlayerNumber;


	public void Fire(int index){
		Rotate.Instance.FirstRotation = transform.rotation;
		var obj = Instantiate(Prefab,ShotPos[index].position,ShotPos[index].transform.rotation);
		obj.transform.rotation = ShotPos[index].rotation;
		NextTurn = !NextTurn;
	}


    void Update () {
	int index = 0;
		if(Input.GetKeyDown(KeyCode.Mouse0) && !MyGameManager.Instance.IsGameOver){
		Fire(index);
	}
	}

	void Fire(){
		Debug.Log(MyGameManager.Instance.IsGameOver);
		Debug.Log(PlayerNumber);

		if(PlayerNumber != null){
		CheckPlayer();
		}
		
		if(PlayerNumber.ToString() == "Player1" && Input.GetKeyDown(KeyCode.Mouse0) && !MyGameManager.Instance.IsGameOver && NextTurn){
		var obj = Instantiate(Prefab,ShotPos[0].position,ShotPos[0].transform.rotation);
		obj.transform.rotation = ShotPos[0].rotation;
		NextTurn = false;
		NetworkManager.Instance._ws_Fire();
		}

		if(PlayerNumber.ToString() == "Player2" && Input.GetKeyDown(KeyCode.Mouse0) && !MyGameManager.Instance.IsGameOver && NextTurn){
		var obj = Instantiate(Prefab,ShotPos[1].position,ShotPos[1].transform.rotation);
		obj.transform.rotation = ShotPos[1].rotation;
		NextTurn = false;
		NetworkManager.Instance._ws_Fire();
		}

	}

	    private void CheckPlayer()
    {
		if(PlayerNumber.ToString() == "Player1"){
		PlayerNumber = 	"Player1";
		}else if(PlayerNumber.ToString() == "Player2"){
		PlayerNumber = 	"Player1";	
		}
    }
}