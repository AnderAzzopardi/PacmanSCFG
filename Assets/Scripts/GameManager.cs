using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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

	MainMenu menu;

	public GameObject heart1, heart2, heart3, gameOver;
	public static int health;

	

	public void Start()
	{

		
		SpawnObstacles();
		//SpawnPlayer();
		//SpawnEnemies();

		//Setting the _cam to main camera
		_cam = Camera.main;
		//Loading the path finding
		_ais = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();

		//Creating a new grid
		_Grid = new Grid(30, 30, _tilePrefab);

		health = 3;
		heart1.gameObject.SetActive (true);
		heart2.gameObject.SetActive (true);
		heart3.gameObject.SetActive (true);
	//	gameOver.gameObject.SetActive (false);

		

/*
		if(enemyArray.Length == 0)
         {
            enemyArray = GameObject.FindGameObjectsWithTag("Enemy");
         }
		enemyFind();

		*/
		//Updating the scan
		AstarPath.active.Scan();


    }

	void Update()
	{
		if (health > 3)
		health = 3;


		switch (health){
			case 3:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(true);
			heart3.gameObject.SetActive(true);
			break;

			case 2:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(true);
			heart3.gameObject.SetActive(false);
			break;

			case 1:
			heart1.gameObject.SetActive(true);
			heart2.gameObject.SetActive(false);
			heart3.gameObject.SetActive(false);
			break;

			case 0:
			heart1.gameObject.SetActive(false);
			heart2.gameObject.SetActive(false);
			heart3.gameObject.SetActive(false);
			SceneManager.LoadScene(0);
			
			break;
		}
	}



	private void SpawnObstacles()
	{
		for(int i = 0; i < 20; i++ ){

		Instantiate(_obstaclePrefab, RandomSpawnLocation(), Quaternion.identity);
			

		}
	}
/*
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

    }

*/
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



	  void MenuDifficult()
    {
      if(menu.easy == true)
      {
        foreach(GameObject _enemyPrefab in enemyArray)
        {
          _enemyPrefab.GetComponent<AIPath>().speed = 4;
        }
      }
      if(menu.medium == true)
      {
         foreach(GameObject _enemyPrefab in enemyArray)
        {
          _enemyPrefab.GetComponent<AIPath>().speed = 6;
        }
      }
      if(menu.hard == true)
      {
         foreach(GameObject _enemyPrefab in enemyArray)
        {
          _enemyPrefab.GetComponent<AIPath>().maxSpeed = 20;
        }
      }
    }


}
