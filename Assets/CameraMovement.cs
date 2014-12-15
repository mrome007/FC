using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour 
{
	public Transform BirdPos;
	private float OffsetPos = 2.25f;
	private Vector3 Pos;
	BirdMovement BM;
	// Use this for initialization
	void Start () 
	{
		Pos = new Vector3 ();
		BM = BirdPos.gameObject.GetComponent<BirdMovement> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Pos = new Vector3(BirdPos.position.x, 0, -10);
		//transform.position = Pos;
			transform.Translate (Vector3.right * BM.BirdSpeed * Time.deltaTime);
	}
}
