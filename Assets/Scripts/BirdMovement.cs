using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour 
{
	public float BirdSpeed;
	private float Gravity = 23.0f;
	public Vector2 MoveAmount;
	private bool startIt;
	public bool StartIt
	{
		get{ return startIt;}
	}
	public bool CanMove;
	// Use this for initialization
	void Start () 
	{
		CanMove = true;
		startIt = false;
		MoveAmount = new Vector2 (1.0f,0.0f);
	}
	
	// Update is called once per frame
	void Update()
	{

		if(Input.GetKeyDown(KeyCode.Space) && CanMove)
		{
			startIt = true;
			MoveAmount.y = 500.0f * Time.deltaTime;
			MoveAmount.y = Mathf.Clamp(MoveAmount.y,7.7f,8.0f);
		}
		MoveAmount.x = BirdSpeed;
		if(startIt)
			MoveAmount.y -= Gravity * Time.deltaTime;
		transform.Translate (MoveAmount * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, 
		                                  Mathf.Clamp (transform.position.y, -5.0f, 6.16f),
		                                  transform.position.z);
	}
}
