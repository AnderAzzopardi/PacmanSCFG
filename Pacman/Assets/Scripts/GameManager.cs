using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private Camera _cam;
    private IAstarAI[] _ais;
	
	[SerializeField] private GameObject _tilePrefab;
	
	private GridManager _GridManager;
	public void Start()
	{
		//Setting the _cam to main camera
		_cam = Camera.main;
		//Loading the path finding
		_ais = FindObjectsOfType<MonoBehaviour>().OfType<IAstarAI>().ToArray();
		//Creating a new grid
		_GridManager = new GridManager(20, 20, _tilePrefab);
		//Updating the scan
		AstarPath.active.Scan();
	}



	private void UpdatePathfinding()
    {
		for (int i = 0; i < _ais.Length; i++)
		{
			if (_ais[i] != null) _ais[i].SearchPath();
		}
	}

}
