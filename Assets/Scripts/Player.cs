using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Transform myTrans;
	public bool isMoving;

	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Check if mouse click is being pressed
		if(!GameManager.instance.isPaused){
			if(Input.GetMouseButton(0)){	
				Vector3 mousePos = Input.mousePosition;
				mousePos.z = 10;

				Vector3 screenPos = Camera.main.ScreenToWorldPoint(mousePos);
				RaycastHit2D hit = Physics2D.Raycast(screenPos, Vector2.zero);

				//Checking the player collider
				if(hit != null && hit.collider != null){
					if(hit.collider.tag == "Player"){
						isMoving = true;
					}else{
						isMoving = false;
					}
				}

				//Move the player 
				if(isMoving){
					myTrans.position = screenPos;
				}
			}

			//Check if mouse click isn't pressed
			if(Input.GetMouseButtonUp(0)){
				isMoving = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.tag == "Enemy"){
			GameManager.instance.isDead();
		}
	}
}
