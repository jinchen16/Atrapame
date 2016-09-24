using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public bool isPaused;
	public float gameTime;
	public int gameTimeAux;
	public int difficulty;

	public Text txtTime;
	public GameObject message;
	public Text txtLabelWin;

	public GameObject enemy;

	// Use this for initialization
	void Awake () {
		instance = this;
		isPaused = true;
		message.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(!isPaused){
			gameTimeAux = (int) Mathf.Floor(gameTime -= Time.deltaTime);
			SetTimeTxt();

			//Check if time is 0
			if(gameTime < 0){
				gameTimeAux = 0;
				SetTimeTxt();
				isPaused = true;
				message.SetActive(true);
				txtLabelWin.text = "You Win";
			}
		}
	}

	//Check if the player is dead
	public void isDead(){		
		isPaused = true;
		message.SetActive(true);
		txtLabelWin.text = "You Lose";
	}

	//Change game text in game
	public void SetTimeTxt(){
		txtTime.text = gameTimeAux.ToString();
	}

	//Method for creating enemies
	public void CreateEnemies(){
		int limit = (int) Mathf.Pow(2,difficulty) + 4;
		for(int i = 0; i < limit; i++){
			GameObject enem = Instantiate(enemy, Vector3.one, Quaternion.identity) as GameObject;
			enem.transform.SetParent(GameObject.Find("Enemies").transform);
		}
	}

}
