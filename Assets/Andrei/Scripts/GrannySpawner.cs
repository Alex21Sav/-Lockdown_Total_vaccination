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
    float spawnTime;

    [SerializeField] private GameObject _point1;
    [SerializeField] private GameObject _point2;
    [SerializeField] private GameObject _point3;
    [SerializeField] private GameObject _point4;
    [SerializeField] private GameObject _point5;

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
		int i = Random.Range(1, 6);
        if (i == 1)
        {
            spawnLocation = new Vector3(spawnLocation.x = _point1.transform.position.x, spawnLocation.y = _point1.transform.position.y, spawnLocation.z = _point1.transform.position.z);           
        }
        else if (i == 2)
        {
            spawnLocation = new Vector3(spawnLocation.x = _point2.transform.position.x, spawnLocation.y = _point2.transform.position.y, spawnLocation.z = _point2.transform.position.z);
            
        }
        else if (i == 3)
        {
            spawnLocation = new Vector3(spawnLocation.x = _point3.transform.position.x, spawnLocation.y = _point3.transform.position.y, spawnLocation.z = _point3.transform.position.z);       
        }
        else if (i == 4)
        {
            spawnLocation = new Vector3(spawnLocation.x = _point4.transform.position.x, spawnLocation.y = _point4.transform.position.y, spawnLocation.z = _point4.transform.position.z);
        }
        else
        {
            spawnLocation = new Vector3(spawnLocation.x = _point5.transform.position.x, spawnLocation.y = _point5.transform.position.y, spawnLocation.z = _point5.transform.position.z);
        }

        Instantiate<GameObject>(prefabGranny, new Vector3(spawnLocation.x, spawnLocation.y, spawnLocation.z), Quaternion.identity);
	}

	void StartRandomTimer()
    {
        int level = (int)Time.time / 10;
        if (level > 10)
        {
            spawnTime = 2;
        }
        else
        {
            spawnTime = 2 + (10 - level);
        }
		spawnTimer.Duration =spawnTime;
		spawnTimer.Run();
	}
}
