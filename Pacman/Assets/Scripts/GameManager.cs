using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private Camera _cam;
    private IAstarAI[] _ais;
	[SerializeField] private GameObject _snakeFood;
	[SerializeField] private GameObject _tilePrefab;
	[SerializeField] private GameObject _snakeHead;
	private GridManager _GridManager;
	public void Start()
	{
		//Setting the _cam to main camera
		_cam = Camera.main;
		//Loading the path finding
		_ais = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();
		//Creating a new grid
		_GridManager = new GridManager(20, 20, _tilePrefab);
		//Spawning the snake head
		Instantiate(_snakeHead, _GridManager.getSpawnLocation(), Quaternion.identity);
		//Updating the scan
		AstarPath.active.Scan();
	}

	public void OnGUI()
	{
		//If we get a double click
		if (_cam != null && 
			Event.current.type == EventType.MouseDown && 
			Event.current.clickCount == 2 &&
			GameObject.Find("SnakeFood(Clone)") == null)
		{
			//Spawn the food in the location of the mouse click (in the relevant tile)
			//And get the snake to walk towards the food to consume it
			UpdateFoodPosition();
		}
	}

	private void UpdateFoodPosition()
	{
		Vector3 newPosition = Vector3.zero;
		newPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
		newPosition.x = Mathf.Round(newPosition.x);
		newPosition.y = Mathf.Round(newPosition.y);

		newPosition.z = 0;

		//If the tile exists and it is not an obstacle
		if (_GridManager.isTileAvailable(newPosition))
        {
			//Spawn the food in that location
			GameObject food = Instantiate(_snakeFood, newPosition, Quaternion.identity);
			//Linking the food target with the seeker (SnakeHead)
			GameObject.Find("SnakeHead(Clone)").GetComponent<AIDestinationSetter>().target = food.transform;
			//Update Pathfinding
			UpdatePathfinding();
			StartCoroutine(DestroyFoodTimer(food,6f));
			//Start a timer to destroy the food after x seconds
		}

	}

	private IEnumerator DestroyFoodTimer(GameObject food, float time)
    {
		yield return new WaitForSeconds(time);
		if (food)
        {
			Destroy(food);
        }
    }


	private void UpdatePathfinding()
    {
		for (int i = 0; i < _ais.Length; i++)
		{
			if (_ais[i] != null) _ais[i].SearchPath();
		}
	}

}
