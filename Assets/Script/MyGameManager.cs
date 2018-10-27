using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : Singleton<MyGameManager> {
public int Score;
public Text ScoreText;
public GameObject GameOver;
public bool IsGameOver;

private void Update() {
//ScoreText.text = Score.ToString();
}

public void Loose(){
GameOver.SetActive(true);
IsGameOver = true;
}

public void Restart(){
	string scene = SceneManager.GetActiveScene().name;
SceneManager.LoadScene(scene,LoadSceneMode.Single);
}

}
