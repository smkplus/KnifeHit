using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour {

public GameObject checkNameMenu;
public GameObject findMatch;
public GameObject Game;

private void Update() {
	if(NetworkManager.Instance.findMatch && !NetworkManager.Instance.startGame){
	FindMatch();
	}
	if(NetworkManager.Instance.startGame){
	StartGame();
	}
}
void FindMatch(){
	checkNameMenu.SetActive(false);
	findMatch.SetActive(true);
}

void StartGame(){
	findMatch.SetActive(false);
	checkNameMenu.SetActive(false);
	Game.SetActive(true);
}
public void ChangeYourName(){
Debug.LogError("ChangeYourName");
}
}
