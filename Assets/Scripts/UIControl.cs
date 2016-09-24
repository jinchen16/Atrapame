using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour {

	public GameObject settingsUI;
	public GameObject gameUI;

	public Text txtTime;
	public Text txtDiff;

	//On Awake function
	void Awake(){
		settingsUI.SetActive(true);
		gameUI.SetActive(false);
	}

	//Add xTime to the game time variable
	public void AddTime(){
		GameManager.instance.gameTime += 10;
		SetTimeTxt();
	}

	//Substract xTime to the game time variable
	public void SubsTime(){
		if(GameManager.instance.gameTime > 0){
			GameManager.instance.gameTime -= 10;
			SetTimeTxt();
		}
	}

	//Add xDifficulty to the game time variable
	public void AddDiff(){
		if(GameManager.instance.difficulty < 4){
			GameManager.instance.difficulty += 1;
			SetDiffTxt();
		}
	}

	//Substract xDifficulty to the game time variable
	public void SubsDiff(){
		if(GameManager.instance.difficulty > 0){
			GameManager.instance.difficulty -= 1;
			SetDiffTxt();
		}
	}

	//Continue to play
	public void Continue(){
		if(GameManager.instance.gameTime > 0){
			settingsUI.SetActive(false);
			gameUI.SetActive(true);
			GameManager.instance.isPaused = false;
			GameManager.instance.CreateEnemies();
		}
	}

	//Restarting the game
	public void Restart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	//Setting time text
	public void SetTimeTxt(){
		txtTime.text = GameManager.instance.gameTime.ToString();
	}

	//Setting difficulty text
	public void SetDiffTxt(){
		int diff = GameManager.instance.difficulty;
		string diffText = "";
		switch(diff){
		case 0:
			diffText = "Noob";
			break;
		case 1:
			diffText = "Easy";
			break;
		case 2:
			diffText = "Normal";
			break;
		case 3:
			diffText = "Hard";
			break;
		case 4:
			diffText = "Damn";
			break;
		default:
			break;
		}
		txtDiff.text = diffText;
	}
}
