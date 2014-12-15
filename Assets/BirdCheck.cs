using UnityEngine;
using System.Collections;

public class BirdCheck : MonoBehaviour
{
	public Transform CheckBirdPos;
	public LayerMask Bird;
	private bool ThereIsABird;
	void Start () 
	{
		ThereIsABird = false;
		StartCoroutine ("CheckForBird");
	}
	
	IEnumerator CheckForBird()
	{
		while(!ThereIsABird)
		{
			Ray ray = new Ray(CheckBirdPos.position,-Vector2.up);
			RaycastHit2D hit;
			Debug.DrawRay(ray.origin,ray.direction * 2.0f);
			hit = Physics2D.Raycast(CheckBirdPos.position,-Vector2.up,2.0f,Bird);
			if(hit.collider != null)
			{
				ThereIsABird = true;
				FlappyManager.ObstaclesOverCome++;
			}
			yield return 0;
		}
		Debug.Log("Finished " + FlappyManager.ObstaclesOverCome);
	}
}
