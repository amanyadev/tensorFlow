using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreboard : MonoBehaviour {
/*	public Timer timer;*/

	public Text scoreP1;
	public Text scoreP2;
	public int P1 = 0;
	public int P2 = 0;
	public GameObject ball;
	public float posX,posY;
	public float velocity ;
	public float minSpeed = 5f,maxSpeed = 10f;
	// Use this for initialization
	void Start () {
		/*timer = gameObject.AddComponent<Timer> ();
		timer.Duration = 1f;*/
		spawnBall ();
		/*ball = GameObject.FindWithTag ("ball");*/
			//spawnBall ();
		posX = ball.GetComponent<Transform> ().position.x;
		posY = ball.GetComponent<Transform> ().position.y;
	}
	
	// Update is called once per frame
	void Update () {
		
		posX = ball.GetComponent<Transform> ().position.x;
		posY = ball.GetComponent<Transform> ().position.y;
		/*GameObject ball = GameObject.FindWithTag ("ball");*/
		if (posX < -11.1f) {
			P2++;
		    spawnBall ();


		} else if (posX > 11.1f) {
			P1++;
			spawnBall ();

		}
		//Instantiate (ball,new Vector2(0f,0f),Quaternion.identity);


	    scoreP2.text = P2.ToString();
		scoreP1.text = P1.ToString();
		
	}


	void spawnBall(){
		
		//ball.transform.position = Vector2.zero;
		posX = 0f;
		posY = 0f;
		ball.transform.position = new Vector3 (0f, 0f, ball.transform.position.z);
		Rigidbody2D rb = ball.GetComponent<Rigidbody2D> ();
		rb.velocity = Vector2.zero;
		velocity = Random .Range(minSpeed, maxSpeed);
		/*ball.transform.rotation = Random.rotation;*/
		float service = Random .Range(0f, 2f);
		Vector2 direction;
		float angle= Mathf.Deg2Rad*0;
		if(service>=1f){
			angle = Random.Range (50, -50);
		}else if (service<1f){
			angle = Random.Range (130, 230);
		}

		direction = new Vector2 (Mathf.Cos (angle*Mathf.Deg2Rad), Mathf.Sin (angle*Mathf.Deg2Rad));
		rb.AddForce (direction * velocity, ForceMode2D.Impulse);

	}


}
