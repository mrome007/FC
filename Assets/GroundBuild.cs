using UnityEngine;
using System.Collections;

public class GroundBuild : MonoBehaviour {
	public GameObject Ground;
	public GameObject LastGround;
	private float CompPos = 19.0f;
	private float GroundPos = 50.0f;
	private float Incr = 50.0f;
	// Use this for initialization
	private GameObject CurrGround;
	
	// Update is called once per frame
	void Update () 
	{
		if(transform.position.x >= CompPos)
		{
			GameObject d = LastGround;
			LastGround = null;
			Destroy(d,5.0f);
			CompPos += Incr;
			CurrGround = (GameObject)Instantiate(Ground,new Vector3(GroundPos,-6.0f,-5.0f),Quaternion.identity);
			GroundPos += Incr;
			LastGround = CurrGround;
		}
	}
}
