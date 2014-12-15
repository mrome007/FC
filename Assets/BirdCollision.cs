using UnityEngine;
using System.Collections;

public class BirdCollision : MonoBehaviour 
{
	private BirdMovement BM;
	void Start()
	{
		BM = gameObject.GetComponent<BirdMovement> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.tag == "Pipe" || other.gameObject.tag == "Ground")
		{
			//Debug.Log("I hit the pipe");
			BM.BirdSpeed = 0.0f;
			BM.CanMove = false;
			transform.position = new Vector3(transform.position.x,transform.position.y,-7.0f);
			StartCoroutine("StartOver");

		}
	}

	IEnumerator StartOver()
	{
		FlappyManager.ObstaclesOverCome = 0;
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel(Application.loadedLevel);
	}
}
