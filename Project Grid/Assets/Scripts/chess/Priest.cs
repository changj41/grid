using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Priest : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private PriestCharacterClass _PriestClass;
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

  	// Use this for initialization
  	void Start()
  	{
	    _rigidbody = GetComponent<Rigidbody>();
		_PriestClass = new PriestCharacterClass();
	    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
	    _inputManager = new InputManager();
	    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
	    _gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;
			_gameControllerScript.Priest1IsCover = true;

	    //Temp
		unitName = this.gameObject.name;
		GetComponentInChildren<TextMesh>().text = "Priest1\n(cover)";
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
			if(_gameControllerScript.Priest1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = unitName;
				_gameControllerScript.Priest1IsCover = false;
			}
			else{
				showingMovementRange = true;
				_gameController.GetComponent<GameController>().pieceSelected = true;
				_gameController.GetComponent<GameController>().selectedUnit = unitName;
				_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
				showMovementRange();
				GetComponentInChildren<TextMesh>().text = "Priest1\n(select)";
			}
		}
		else if(showingMovementRange && _gameController.GetComponent<GameController>().pieceSelected)
		{
			showingMovementRange = false;
			_gameController.GetComponent<GameController>().pieceSelected = false;
			_gameController.GetComponent<GameController>().selectedUnit = null;
			clearMovementIndicators();
			clickCount = 0;
			GetComponentInChildren<TextMesh>().text = "Priest1";
		}
  	}

  	private void clearMovementIndicators()
  	{
    	GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
    	for(int i = 0; i < movementTiles.Length; i++)
    	{
      		Destroy(movementTiles[i]);
    	}
		GetComponentInChildren<TextMesh>().text = "Priest1";
  	}

  	private void moveCharacter(Vector3 newPosition)
  	{
    	Vector3 currentPosition = this.transform.position;
    	this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
  	}

 	private void showMovementRange()
  	{
		List<Vector3> possibleMoves = _PriestClass.showMovementRange(_rigidbody.position);
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
						else if(check.Length == 1)
						{
							GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
//							iTween.ColorTo(moveRangeTile,Color.red,0.2f);
						}
						else
						{
							
						}
          			}
        		}
      		}
    	}
  	}

	void OnTriggerEnter(Collider other) {
		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit){
			if(other.gameObject.tag=="Character"){
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
				else{
					Destroy(other.gameObject);
				}
			}
		}
	}
}
