using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeBuild : MonoBehaviour 
{
	public GameObject Pipe;
	private float SpaceBetween = 4.5f;
	private BirdMovement BM;
	public GameObject [] Pipes;
	public GameObject [] PipesOld;
	private int PipesCapacity = 10;
	private float? LastPipeXPos;	
	private float? MidPipeXPos;
	bool startOff = true;
	GameObject OrganizePipes;
	// Use this for initialization
	void Start () 
	{
		startOff = true;
		Pipes = new GameObject[PipesCapacity];
		PipesOld = new GameObject[PipesCapacity];
		BM = gameObject.GetComponent<BirdMovement> ();
		OrganizePipes = new GameObject ("OrganizeDaPipes");
		OrganizePipes.transform.position = Vector3.zero;
	}
	
	void Update()
	{
		if(!BM.StartIt)
			return;
		if(startOff && BM.StartIt)
		{
			startOff = false;
			float xpos = transform.position.x + 15.0f;
			for(int i = 0; i < PipesCapacity; i++)
			{
				GameObject p = (GameObject)Instantiate(Pipe,
				                           new Vector3(xpos,Random.Range(-3.0f,4.0f),0.0f),
				                           Quaternion.identity);
				p.transform.parent = OrganizePipes.transform;
				xpos += SpaceBetween;
				Pipes[i] = p;
			}
			MidPipeXPos = Pipes[PipesCapacity/2].transform.position.x;
			LastPipeXPos = Pipes[PipesCapacity-1].transform.position.x;
		}

		if(MidPipeXPos.HasValue && transform.position.x >= MidPipeXPos)
		{
			for(int i = 0; i < PipesCapacity; i++)
				PipesOld[i] = Pipes[i];
			float xpos = Pipes[PipesCapacity-1].transform.position.x + SpaceBetween;
			for(int i = 0; i < PipesCapacity; i++)
			{
				GameObject p = (GameObject)Instantiate(Pipe,
				                                       new Vector3(xpos,Random.Range(-3.0f,4.0f),0.0f),
				                                       Quaternion.identity);
				p.transform.parent = OrganizePipes.transform;
				xpos += SpaceBetween;
				Pipes[i] = p;
			}
			MidPipeXPos = Pipes[PipesCapacity/2].transform.position.x;
		}
		if(LastPipeXPos.HasValue && transform.position.x >= LastPipeXPos + 2.0f)
		{
			LastPipeXPos = Pipes[PipesCapacity-1].transform.position.x;
			for(int i = 0; i < PipesCapacity; i++)
				PipesOld[i].SetActive(false);
		}

	}
		
}
