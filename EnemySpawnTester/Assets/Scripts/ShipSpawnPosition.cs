using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawnPosition : MonoBehaviour 
{
	[SerializeField]
	public GameObject ShipPrefab;

	Vector3 TopLeft;

	bool EnemiesSpawned = false;

	bool KeepSpawning = true;

	int SpawnCount = 0;
	// Use this for initialization
	void Start () 
	{
		float distanceToCamera = transform.position.z - Camera.main.transform.position.z;
		TopLeft = Camera.main.ViewportToWorldPoint (new Vector3 (0, 1, distanceToCamera));
	}

	// Update is called once per frame
	void Update () 
	{
		if(!EnemiesSpawned)
		{
			InvokeRepeating("SpawnNewShip", 1, 1);
			EnemiesSpawned = true;
		}
	}

	void SpawnNewShip()
	{
		if(KeepSpawning)
		{
			GameObject spawnedShip = (GameObject)Instantiate(ShipPrefab, TopLeft, Quaternion.identity);
			Enemy enemy = spawnedShip.gameObject.GetComponent<Enemy>();
			SpawnCount++;
			KeepSpawning =  SpawnCount < enemy.GetSpawnCount();
		}

	}
}
