using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class warrior : MonoBehaviour
{

  	private Rigidbody _rigidbody;
  	private warriorCharacterClass _warriorClass;
  	private GameObject _greenPrefab;
  	private InputManager _inputManager;
  	private GameObject _camera;
	private GameObject _redPrefab;
  	private GameObject _gameController;
  	private bool showingMovementRange;
	private GameController  _gameControllerScript;
  	private bool revealed;
  	private int clickCount;
	public GameObject panel;

  	public string unitName;

  	// Use this for initialization
  	void Start()
  	{
    	_rigidbody = GetComponent<Rigidbody>();
		_warriorClass = new warriorCharacterClass();
		_greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
    	_inputManager = new InputManager();
    	_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
    	showingMovementRange = false;
    	revealed = false;
    	clickCount = 0;

		_gameControllerScript.Warrior1IsCover = true;
		_gameControllerScript.Warrior2IsCover = true;
		//Temp
		unitName = this.gameObject.name;
		GetComponentInChildren<TextMesh>().text = this.gameObject.name+"\n(cover)";
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
			panel.SetActive(true);
			_gameController.GetComponent<GameController>().pieceSelected = true;
			_gameController.GetComponent<GameController>().selectedUnit = unitName;
			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
			if(_gameControllerScript.Warrior1IsCover && this.gameObject.name == "Warrior1" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior1")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(_gameControllerScript.Warrior2IsCover && this.gameObject.name == "Warrior2" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior2")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(!_gameControllerScript.Warrior1IsCover && this.gameObject.name == "Warrior1" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior1")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
			else if(!_gameControllerScript.Warrior2IsCover && this.gameObject.name == "Warrior2" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior2")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
		}
  	}

  	private void clearMovementIndicators()
  	{
    	GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
    	for(int i = 0; i < movementTiles.Length; i++)
    	{
      		Destroy(movementTiles[i]);
    	}

		panel.transform.Find("see").gameObject.SetActive(true);
		panel.SetActive(false);
  	}

  	private void moveCharacter(Vector3 newPosition)
  	{
    	Vector3 currentPosition = this.transform.position;
    	this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		if(this.gameObject.name == "Warrior1")
		{
			if(_gameControllerScript.Warrior1IsCover)
			{
				_gameControllerScript.Warrior1IsCover = false;
			}
		}
		if(this.gameObject.name == "Warrior2")
		{
			if(_gameControllerScript.Warrior2IsCover)
			{
				_gameControllerScript.Warrior2IsCover = false;
			}
		}
  	}

  	private void showMovementRange()
  	{
		List<Vector3> possibleMoves = _warriorClass.showMovementRange(_rigidbody.position);
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
//									iTween.ColorTo(moveRangeTile,Color.red,0.2f);
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
		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit)
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
				{
					if(other.gameObject.name == "EAssassin1")
					{
						_gameControllerScript.EAssassin1IsCover = false;
						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
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
	public void attack()
	{
		if(this.gameObject.name == "Warrior1" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior1" &&showingMovementRange == false)
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.Warrior1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Warrior2"  && _gameController.GetComponent<GameController>().selectedUnit == "Warrior2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Warrior2IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
	}
	public void see()
	{
		if(_gameControllerScript.Warrior1IsCover && this.gameObject.name == "Warrior1" && _gameController.GetComponent<GameController>().selectedUnit == "Warrior1")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Warrior1IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(_gameControllerScript.Warrior2IsCover && this.gameObject.name == "Warrior2"  && _gameController.GetComponent<GameController>().selectedUnit == "Warrior2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Warrior2IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);

			StartCoroutine(waitParticle());
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
	}
	public void cannel()
	{
		if(this.gameObject.name == "Warrior1" && _gameControllerScript.Warrior1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Warrior1")
		{

			GetComponentInChildren<TextMesh>().text = "Warrior1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Warrior2"  && _gameControllerScript.Warrior2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Warrior2")
		{
			GetComponentInChildren<TextMesh>().text = "Warrior2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "Warrior1" && !_gameControllerScript.Warrior1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "Warrior1")
		{

			GetComponentInChildren<TextMesh>().text = "Warrior1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Warrior2"  &&!_gameControllerScript.Warrior2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Warrior2")
		{
			
			GetComponentInChildren<TextMesh>().text = "Warrior2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
		clickCount = 0;
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("human_warrior_Rig").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
}
