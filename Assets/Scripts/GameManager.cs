using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private Camera _cam;
    private IAstarAI[] _ais;

	[SerializeField] private GameObject _obstaclePrefab;
	
	[SerializeField] private GameObject _tilePrefab;

	[SerializeField] private GameObject _playerPrefab;

	[SerializeField] private GameObject _enemyPrefab;

	public GameObject[] enemyArray;
	
	private Grid _Grid;


	

	public void Start()
	{

		enemyFind();
		SpawnObstacles();
		SpawnPlayer();
		SpawnEnemies();

		//Setting the _cam to main camera
		_cam = Camera.main;
		//Loading the path finding
		_ais = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();
		//Creating a new grid
		_Grid = new Grid(30, 30, _tilePrefab);
		//Updating the scan
		AstarPath.active.Scan();


		if(enemyArray.Length == 0)
         {
            enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
         }
		
    }


	private void SpawnObstacles()
	{
		for(int i = 0; i < 20; i++ ){

		Instantiate(_obstaclePrefab, RandomSpawnLocation(), Quaternion.identity);
			

		}
	}

	public void SpawnPlayer()
	{
				
		Instantiate(_playerPrefab, RandomSpawnLocation(), Quaternion.identity);
	}


	public void SpawnEnemies()
	{
		for(int i = 0; i < 2; i++ ){

		Instantiate(_enemyPrefab, RandomSpawnLocation(), Quaternion.identity);
			

		}
	}

	


	void enemyFind()
    {

       foreach (GameObject _enemyPrefab in enemyArray)
       {
         _enemyPrefab.GetComponent<AIDestinationSetter>().target = GameObject.Find("Player(Clone)").transform;

       }
      UpdatePathfinding();

    }


	private Vector3 RandomSpawnLocation(){

		Vector3 randomPos = new Vector3(Random.Range(-14, 14), Random.Range(-14, 14));
            return randomPos;
	}

	private void UpdatePathfinding()
    {
		for (int i = 0; i < _ais.Length; i++)
		{
			if (_ais[i] != null) _ais[i].SearchPath();
		}
	}

}
