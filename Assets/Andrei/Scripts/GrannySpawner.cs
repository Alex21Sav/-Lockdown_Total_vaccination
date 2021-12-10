using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GrannySpawner : MonoBehaviour
{
	
	[SerializeField]
	GameObject prefabGranny;
    private Timer spawnTimer;
    private Vector3 spawnLocation;

    void Start()
    {
        spawnTimer = gameObject.AddComponent<Timer>();
		StartRandomTimer();
	}

    void Update()
    {
		if (spawnTimer.Finished)
		{
			HandleSpawnTimerFinishedEvent();
		}
	}

	private void HandleSpawnTimerFinishedEvent()
	{
            if (GameObject.FindObjectsOfType<Granny>().Length < 10)
            {
                GrannySpawn();
                StartRandomTimer();
            }
	}

    //Spawn granny on an edge of the map
	void GrannySpawn()
    {
		spawnLocation.y = 0.1f;
		int i = Random.Range(1, 6);
        if (i == 1)
        {
            spawnLocation.x = -13.5f;
            spawnLocation.z = 0;
        }
        else if (i == 2)
        {
            spawnLocation.x = -4.6f;
            spawnLocation.z = -14;
        }
        else if (i == 3)
        {
            spawnLocation.x = 13.2f;
            spawnLocation.z = -14;
        }
        else if (i == 4)
        {
            spawnLocation.x = 13.2f;
            spawnLocation.z = 14;
        }
        else
        {
            spawnLocation.x = 3;
            spawnLocation.z = 14;
        }

        Instantiate<GameObject>(prefabGranny, new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z), Quaternion.identity);
	}

	void StartRandomTimer()
    {
        float minimumSpawnTime;
        float maximumSpawnTime;
        if (GameObject.FindObjectsOfType<Granny>().Length == 0)
        {
            minimumSpawnTime = 1;
            maximumSpawnTime=2;
        }
        else
        {
            minimumSpawnTime = 4;
            maximumSpawnTime = 7;
        }
		spawnTimer.Duration =Random.Range(minimumSpawnTime,maximumSpawnTime);
		spawnTimer.Run();
	}
}
