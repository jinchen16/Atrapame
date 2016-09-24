using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed = 3f;

	private int[] directionValue = new int[]{-1,1};
	private Rigidbody2D rb;
	private Transform myTrans;

	// Use this for initialization
	void Start () {
		myTrans = this.transform;
		float x = Random.Range(-8, 8);
		float y = Random.Range(-3, 3);
		myTrans.position = new Vector2(x,y);

		int xDirection = directionValue[Random.Range(0,2)];
		int yDirection = directionValue[Random.Range(0,2)];

		rb = GetComponent<Rigidbody2D>();

		rb.velocity = new Vector2(xDirection*speed, yDirection*speed);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(GameManager.instance.isPaused){
			rb.velocity = new Vector2(0,0);
		}
	}
}
