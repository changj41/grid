﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ESummoner : MonoBehaviour
{

  	private Rigidbody _rigidbody;
  	private SummonerCharacterClass _summonerClass;
  	private GameObject _greenPrefab;
	private GameObject _redPrefab;
  	private InputManager _inputManager;
 	private GameObject _camera;
 	private GameObject _gameController;
	private GameController  _gameControllerScript;
  	private bool showingMovementRange;
  	private bool revealed;
  	private int clickCount;

  	public string unitName;

	// Initialization of the unit
	void Start ()
  	{
	    _rigidbody = GetComponent<Rigidbody>();
	    _summonerClass = new SummonerCharacterClass();
	    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
	    _inputManager = new InputManager();
	    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
	    _gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;
		_gameControllerScript.ESummnonerIsCover = true;
	    //Temp
		unitName = this.gameObject.name;
		GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(cover)";
	}
		
	// Update is called once per frame
	void Update()
  	{
    	if(_gameController.GetComponent<GameController>().selectedUnit != unitName)
    	{
      		showingMovementRange = false;
    	}
    	if(showingMovementRange && _gameController.GetComponent<GameController>().selectedUnit == unitName)
    	{
      		ScreenInput input = _inputManager.GetInput();
      		if(input != null)
      		{
        		if(clickCount >= 1)
        		{
          			clickCount = 0;
          			Ray ray = new Ray(_camera.transform.position, input.inputPoint - _camera.transform.position);
          			RaycastHit[] hits = Physics.RaycastAll(ray, Constants.Board.raycastLength);

          			for(int i = 0; i < hits.Length; i++)
          			{
            			if(hits[i].rigidbody != null)
            			{
              				if(hits[i].transform.gameObject.tag == Constants.Tags.MovementRangeIndicator)
              				{
				                showingMovementRange = false;
				                _gameController.GetComponent<GameController>().pieceSelected = false;
				                _gameController.GetComponent<GameController>().selectedUnit = null;
				                clearMovementIndicators();
				                revealed = true;
				                moveCharacter(hits[i].transform.position);
              				}
            			}
          			}
        		}
        		else
        		{
          			clickCount++;
        		}
      		}
    	}
	}

  	void OnMouseDown()
  	{
		if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected)
		{
			if(_gameControllerScript.ESummnonerIsCover)
			{
				GetComponentInChildren<TextMesh>().text = unitName;
				_gameControllerScript.ESummnonerIsCover = false;
			}
			else
			{
				showingMovementRange = true;
				_gameController.GetComponent<GameController>().pieceSelected = true;
				_gameController.GetComponent<GameController>().selectedUnit = unitName;
				_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
				showMovementRange();
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
			}
		}
		else if(showingMovementRange && _gameController.GetComponent<GameController>().pieceSelected)
		{
			showingMovementRange = false;
			_gameController.GetComponent<GameController>().pieceSelected = false;
			_gameController.GetComponent<GameController>().selectedUnit = null;
			clearMovementIndicators();
			clickCount = 0;
			GetComponentInChildren<TextMesh>().text = this.gameObject.name ;
		}
	}

	private void clearMovementIndicators()
  	{
	    GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
	    for(int i = 0; i < movementTiles.Length; i++)
	    {
			Destroy(movementTiles[i]);
	    }
		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
  	}

	private void moveCharacter(Vector3 newPosition)
	{
		Vector3 currentPosition = this.transform.position;
	    this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
	}

  	private void showMovementRange()
  	{
	    List<Vector3> possibleMoves = _summonerClass.showMovementRange(_rigidbody.position);
	    Quaternion initQuat = Quaternion.Euler(new Vector3(90, 0, 0));
	    for(int i = 0; i < possibleMoves.Count; i++)
    	{
      		if(possibleMoves[i] != _rigidbody.position)
      		{
        		if(possibleMoves[i].x >= 0 && possibleMoves[i].x < Constants.Board.boardX)
        		{
          			if(possibleMoves[i].z >= 0 && possibleMoves[i].z < Constants.Board.boardZ)
          			{
			            Vector3 tileCoordinate = new Vector3(possibleMoves[i].x, 0.1f, possibleMoves[i].z);
			            Vector3 tileToCharDirection = tileCoordinate - this.transform.position;
			            Ray ray = new Ray(this.transform.position, tileToCharDirection);
			            RaycastHit[] check = Physics.RaycastAll(ray, tileToCharDirection.magnitude);
						RaycastHit hit;
						if(check.Length == 0)
						{
							GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
						}
						if(Physics.Raycast(ray, out hit))
						{
							if(check.Length == 1)
							{
								if(hit.collider.tag != this.gameObject.tag && hit.collider.transform.position.x == tileCoordinate.x && hit.collider.transform.position.z == tileCoordinate.z)
								{
									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
//									iTween.ColorTo(moveRangeTile,new Color(255/255f,0/255f,0/255f,50/255f),5f);
								}
							}
						}
          			}
        		}
      		}
    	}
  	}

	void OnTriggerEnter(Collider other) 
	{
		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit){
			if(other.gameObject.tag=="Character")
			{
				if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
				{
					if(other.gameObject.name == "Assassin1")
					{
						_gameControllerScript.Assassin1IsCover = false;
						GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
					}
					else if(other.gameObject.name == "Assassin2")
					{
						_gameControllerScript.Assassin2IsCover = false;
						GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
					}
					Destroy(this.gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
		}
	}
}
