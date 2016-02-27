using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EArcher : MonoBehaviour
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

		_gameControllerScript.EArcher1IsCover = true;
		_gameControllerScript.EArcher2IsCover = true;
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
			panel.SetActive(true);
			_gameController.GetComponent<GameController>().pieceSelected = true;
			_gameController.GetComponent<GameController>().selectedUnit = unitName;
			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
			if(_gameControllerScript.EArcher1IsCover && this.gameObject.name == "EArcher1" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(!_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
			else if(!_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
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
		if(this.gameObject.name == "EArcher1"){
			if(_gameControllerScript.EArcher1IsCover){
				_gameControllerScript.EArcher1IsCover = false;
			}
		}
		if(this.gameObject.name == "EArcher2"){
			if(_gameControllerScript.EArcher2IsCover){
				_gameControllerScript.EArcher2IsCover = false;
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
						if(check.Length == 0)
						{
							GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
						}
						if(Physics.Raycast(ray, out hit))
						{
							if(check.Length == 2)
							{	
								if(hit.collider.name != tempname)
								{
									tempname = hit.collider.name;
									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
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
			if(other.gameObject.tag=="Character")
			{
				Destroy(other.gameObject);
			}
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
		if(this.gameObject.name == "EArcher1" && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1" &&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.EArcher1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "EArcher2"  && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.EArcher2IsCover)
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
		if(_gameControllerScript.EArcher1IsCover && this.gameObject.name == "EArcher1" && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.EArcher1IsCover = false;
			//panel.transform.Find("see").gameObject.SetActive(true);
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
			//			this.transform.Find("human_EArcher_Rig").gameObject.SetActive(true);
			//			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);

		}
		else if(_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2"  && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.EArcher2IsCover = false;
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
		if(this.gameObject.name == "EArcher1" && _gameControllerScript.EArcher1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EArcher2"  && _gameControllerScript.EArcher2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "EArcher1" && !_gameControllerScript.EArcher1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
		{

			GetComponentInChildren<TextMesh>().text = "EArcher1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EArcher2"  &&!_gameControllerScript.EArcher2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("Orc_Scout").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waittimetomove(Vector3 pos){
		yield return new WaitForSeconds(2.5f);
		moveCharacter(pos);
	}

}
