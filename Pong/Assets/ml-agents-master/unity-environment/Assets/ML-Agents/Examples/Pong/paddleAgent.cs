using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
//used to control the paddle.
public class paddleAgent : Agent 
{
	//THE AGENT CONTROLS THE PADDLE SO IT SHOULD KNOW ABOUT THE BALL.
	//therefore we add a gameobject..
	public GameObject ball;
	public float vel;
	public float speed = 5f;
	public Rigidbody2D rb;

	public override void InitializeAgent()
	{
		rb = gameObject.GetComponent<Rigidbody2D>()
		;
	}




	public override void AgentAction(float[] act,string textAction){
		//descrete are exact values 1 0 1.. continuous is any val btw 0 1 -1 etc.
		//if(brain.brainParameters.vectorActionSpaceType == SpaceType.continuous){
			/*float action = act [0];*/
		/*Debug.Log (act [0]);*/
			vel = rb.velocity.y;
		/*Debug.Log (vel);*/
			float location = gameObject.GetComponent<Transform> ().position.y;
			if (location < 4.8f && location > -4.8f) {
				vel = act [0] * speed;
			Debug.Log ("act is "+act [0]);
			rb.velocity = new Vector2 (rb.velocity.x, vel);
			AddReward (.001f);

			}
			else{
				if(location>4.8f){
					location = 4.8f;
				}
				if(location<-4.8f){
					location = -4.8f;
				}
				Vector2 loc = new Vector2 (gameObject.transform.position.x, location);
				location = loc.y;
				
			}
		//	if(ball.transform.position.y>transform.position.y){

			//}
		if(ball.transform.position.x>11f){
			AddReward (.1f);
			/*Debug.Log("rewarded+1");*/
		}
		if(ball.transform.position.x<-11f){
			AddReward(-1f);
			/*Debug.Log("rewarded -1");*/
		//	Debug.Log (ball.transform.position.x);
			gameObject.transform.position = new Vector2 (-10f, 0f);
		//	Debug.Log ("Done  agent");
			Done ();

		}
		else{
		}
	}
   

	//not controlled by start and update rather controlled by the ML agents..
	public override void  CollectObservations(){
		//getting state. of paddle as well as ball.
		//List <float> state = new List<float> ();
		AddVectorObs (gameObject.transform.position.x);
		AddVectorObs (gameObject.transform.position.y);
		AddVectorObs (ball.transform.position.x - gameObject.transform.position.x);
		AddVectorObs(ball.transform.position.y - gameObject.transform.position.y);
		AddVectorObs (ball.transform.GetComponent<Rigidbody2D> ().velocity.x);
		AddVectorObs (ball.transform.GetComponent<Rigidbody2D> ().velocity.y);
	}

	public override void AgentReset ()
	{
		
		/*Debug.Log ("Done called agent");*/
			//reset our agent
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "paddle"){
			AddReward (0.1f);
			Debug.Log("rewardedc+1");
		}
	}

}
