using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Archer : MonoBehaviour
{

  	private Rigidbody _rigidbody;
  	private ArcherCharacterClass _ArcherClass;
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
	public GameObject panel;

  	// Use this for initialization
	void Start()
	{
    	_rigidbody = GetComponent<Rigidbody>();
		_ArcherClass = new ArcherCharacterClass();
	    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
	    _inputManager = new InputManager();
	    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
	    _gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;

		_gameControllerScript.Archer1IsCover = true;
		_gameControllerScript.Archer2IsCover = true;
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
								if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer1")
								{
									if(_gameControllerScript.Archer1IsCover)
									{
										this.gameObject.GetComponent<MeshRenderer>().enabled = false;
										this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
										this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
										StartCoroutine(waitParticle());
										StartCoroutine(waittimetomove(hits[i].transform.position));
									}
								}
								else if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer2")
								{
									if(_gameControllerScript.Archer2IsCover)
									{
										this.gameObject.GetComponent<MeshRenderer>().enabled = false;
										this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
										this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
										StartCoroutine(waitParticle());
										StartCoroutine(waittimetomove(hits[i].transform.position));
									}
								}
								else{
				                	moveCharacter(hits[i].transform.position);
								}
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
			if(this.gameObject.name == "Archer1" &&_gameControllerScript.Archer1IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Archer1")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(this.gameObject.name == "Archer2" &&_gameControllerScript.Archer2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Archer2")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			if(this.gameObject.name == "Archer1" && !_gameControllerScript.Archer1IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Archer1")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
			else if(this.gameObject.name == "Archer2" && !_gameControllerScript.Archer2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Archer2")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
//			}
//			if(!_gameControllerScript.Archer1IsCover||!_gameControllerScript.Archer2IsCover)
//			{
//				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
//			}
//			else if(attackbool)
//			{
//				clearMovementIndicators();
//			}
//			if(_gameControllerScript.Archer1IsCover && this.gameObject.name == "Archer1")
//			{
//				GetComponentInChildren<TextMesh>().text = unitName;
//				_gameControllerScript.Archer1IsCover = false;
//			}
//			else if(_gameControllerScript.Archer2IsCover && this.gameObject.name == "Archer2")
//			{
//				GetComponentInChildren<TextMesh>().text = unitName;
//				_gameControllerScript.Archer2IsCover = false;
//			}
//			else
//			{
//				showingMovementRange = true;
//				_gameController.GetComponent<GameController>().pieceSelected = true;
//				_gameController.GetComponent<GameController>().selectedUnit = unitName;
//				_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
//				showMovementRange();
//				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
//			}
		}
//		else if(showingMovementRange && _gameController.GetComponent<GameController>().pieceSelected)
//		{
//			showingMovementRange = false;
//			_gameController.GetComponent<GameController>().pieceSelected = false;
//			_gameController.GetComponent<GameController>().selectedUnit = null;
//			clearMovementIndicators();
//			clickCount = 0;
//			GetComponentInChildren<TextMesh>().text = this.gameObject.name;
//		}
  	}

	private void clearMovementIndicators()
  	{
		GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
		for(int i = 0; i < movementTiles.Length; i++)
    	{
      		Destroy(movementTiles[i]);
    	}
//		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		panel.transform.Find("see").gameObject.SetActive(true);
		panel.SetActive(false);

  	}

  	private void moveCharacter(Vector3 newPosition)
  	{
    	Vector3 currentPosition = this.transform.position;
    	this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		if(this.gameObject.name == "Archer1"){
			if(_gameControllerScript.Archer1IsCover){
				_gameControllerScript.Archer1IsCover = false;
			}
		}
		if(this.gameObject.name == "Archer2"){
			if(_gameControllerScript.Archer2IsCover){
				_gameControllerScript.Archer2IsCover = false;
			}
		}
  	}

  	private void showMovementRange()
  	{
		List<Vector3> possibleMoves = _ArcherClass.showMovementRange(_rigidbody.position);
    	Quaternion initQuat = Quaternion.Euler(new Vector3(90, 0, 0));
		string tempname = "";
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
						if(_gameController.GetComponent<GameController>().selectedUnit == "Archer1")
						{
							if(!_gameControllerScript.Archer1IsCover)
							{
								if(check.Length == 0)
								{
									GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
							}
						}
						else if(_gameController.GetComponent<GameController>().selectedUnit == "Archer2")
						{
							if(!_gameControllerScript.Archer2IsCover)
							{
								if(check.Length == 0)
								{
									GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
							}
						}
						if(Physics.Raycast(ray, out hit))
						{
							if(check.Length == 2 )
							{	
								
								print("++"+tempname+"++");

								if(hit.collider.name != tempname && hit.collider.tag != this.gameObject.tag)
								{
									print(hit.collider.name);
									tempname = hit.collider.name;
									print(tileCoordinate);
									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
//								if(hit.collider.tag != this.gameObject.tag && hit.collider.transform.position.x == tileCoordinate.x && hit.collider.transform.position.z == tileCoordinate.z)
//								{
//									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
//									moveRangeTile.transform.SetParent(this.transform);
//								}
							}
						}
          			}
        		}
      		}
    	}
	}

	private void showUnit(bool show)
	{
		if(!revealed)
		{
			if(show)
			{
				GetComponentInChildren<TextMesh>().text = unitName;
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
			}
		}
  	}
	void OnTriggerEnter(Collider other) 
	{
		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit)
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				Destroy(other.gameObject);
			}
//			if(other.gameObject.tag=="Character")
//			{
//				if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
//				{
//					if(other.gameObject.name == "Assassin1")
//					{
//						_gameControllerScript.Assassin1IsCover = false;
//						GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
//					}
//					else if(other.gameObject.name == "Assassin2")
//					{
//						_gameControllerScript.Assassin2IsCover = false;
//						GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
//					}
//					Destroy(this.gameObject);
//				}
//				else{
//					Destroy(other.gameObject);
//				}
//			}
		}
	}
	public void attack()
	{
		print("attack  " + this.gameObject.name);
//			showingMovementRange = true;
//			_gameController.GetComponent<GameController>().pieceSelected = true;
//			_gameController.GetComponent<GameController>().selectedUnit = unitName;
//			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
//			showMovementRange();
//			GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
		if(this.gameObject.name == "Archer1" && _gameController.GetComponent<GameController>().selectedUnit == "Archer1" &&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Archer1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Archer2"  && _gameController.GetComponent<GameController>().selectedUnit == "Archer2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Archer2IsCover)
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
		if(_gameControllerScript.Archer1IsCover && this.gameObject.name == "Archer1" && _gameController.GetComponent<GameController>().selectedUnit == "Archer1")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Archer1IsCover = false;
			//panel.transform.Find("see").gameObject.SetActive(true);
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
//			this.transform.Find("human_archer_Rig").gameObject.SetActive(true);
//			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);

		}
		else if(_gameControllerScript.Archer2IsCover && this.gameObject.name == "Archer2"  && _gameController.GetComponent<GameController>().selectedUnit == "Archer2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Archer2IsCover = false;
//			panel.transform.Find("see").gameObject.SetActive(true);
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
	}
	public void cannel()
	{
		print(this.gameObject.gameObject);
		if(this.gameObject.name == "Archer1" && _gameControllerScript.Archer1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Archer1")
		{
			GetComponentInChildren<TextMesh>().text = "Archer1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Archer2"  && _gameControllerScript.Archer2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Archer2")
		{
			GetComponentInChildren<TextMesh>().text = "Archer2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "Archer1" && !_gameControllerScript.Archer1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "Archer1")
		{

			GetComponentInChildren<TextMesh>().text = "Archer1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Archer2"  &&!_gameControllerScript.Archer2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Archer2")
		{
			GetComponentInChildren<TextMesh>().text = "Archer2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("human_archer_Rig").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waittimetomove(Vector3 pos){
		yield return new WaitForSeconds(2.5f);
		moveCharacter(pos);
	}
}
