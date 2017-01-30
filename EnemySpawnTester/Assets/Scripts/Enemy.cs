using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour 
{
	float XMax = 0;
	float XMin = 0;

	bool MovingRight = true;

	bool MoveDownStep = false;

	private int spawnCount = 50;

	public int GetSpawnCount()
	{
		return spawnCount;
	}

	void Start()
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		XMin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distanceToCamera)).x;
		XMax = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0, distanceToCamera)).x;
	}

	void Update()
	{
		if(MovingRight)
			transform.position += Vector3.right * 2 * Time.deltaTime;
		else
			transform.position += Vector3.left * 2 * Time.deltaTime;
	
		if(transform.position.x < XMin)
		{
			MovingRight = true;
			MoveDownStep = true;
		} 
		else if(transform.position.x > XMax)
		{
			MovingRight = false;
			MoveDownStep = true;
		}

		if(MoveDownStep)
		{
			transform.position += Vector3.down * 2;
			MoveDownStep = false;
		}
	}
}


