using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Knight : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private KnightCharacterClass _KnightClass;
	private GameObject _greenPrefab;
	private GameObject _redPrefab;
	private InputManager _inputManager;
	private GameObject _camera;
	private GameObject _gameController;
	private bool showingMovementRange;
  	private bool revealed;
  	private int clickCount;
	private GameController  _gameControllerScript;

  	public string unitName;

  	// Use this for initialization
  	void Start()
  	{
    	_rigidbody = GetComponent<Rigidbody>();
		_KnightClass = new KnightCharacterClass();
    	_greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
    	_inputManager = new InputManager();
    	_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
   		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;
		GetComponentInChildren<TextMesh>().text = "Knight\n(cover)";
		_gameControllerScript.Knight1IsCover = true;
    	//Temp
		unitName = this.gameObject.name;
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
			if(_gameControllerScript.Knight1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = unitName;
				_gameControllerScript.Knight1IsCover = false;
			}
			else
			{	
				showingMovementRange = true;
				_gameController.GetComponent<GameController>().pieceSelected = true;
				_gameController.GetComponent<GameController>().selectedUnit = null;
				_gameController.GetComponent<GameController>().selectedUnit = unitName;
				_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
				showMovementRange();
				GetComponentInChildren<TextMesh>().text = "Knight1\n(select)";
	    	}
		}
		else if(showingMovementRange && _gameController.GetComponent<GameController>().pieceSelected)
		{
			Debug.Log("123");
	      	showingMovementRange = false;
	      	_gameController.GetComponent<GameController>().pieceSelected = false;
			_gameController.GetComponent<GameController>().selectedUnit = null;
	      	clearMovementIndicators();
	      	clickCount = 0;
			GetComponentInChildren<TextMesh>().text = "Knight";
				
		}
  	}

	private void clearMovementIndicators()
	{
		GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
	    for(int i = 0; i < movementTiles.Length; i++)
	    {
	      Destroy(movementTiles[i]);
	    }
		GetComponentInChildren<TextMesh>().text = "Knight";
	}
	private void moveCharacter(Vector3 newPosition)
	{
	    Vector3 currentPosition = this.transform.position;
	    this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
	}

	private void showMovementRange()
	{
		List<Vector3> possibleMoves = _KnightClass.showMovementRange(_rigidbody.position);
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
			            if(check.Length == 0)
	            		{
							GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
			            }
						if(check.Length == 1)
						{
							GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
//							iTween.ColorTo(moveRangeTile,Color.red,0.2f);
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
				Debug.Log(other.gameObject.name);
				Destroy(other.gameObject);
			}
		}
	}
}
