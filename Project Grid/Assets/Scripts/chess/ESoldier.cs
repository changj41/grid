using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ESoldier : MonoBehaviour
{

	private Rigidbody _rigidbody;
	private SoldierCharacterClass _SoldierClass;
	private GameObject _greenPrefab;
	private GameObject _redPrefab;
  	private InputManager _inputManager;
  	private GameObject _camera;
  	private GameObject _gameController;
	private GameController  _gameControllerScript;
  	private bool showingMovementRange;
  	private bool revealed;
  	private int clickCount;
	public GameObject panel;
	Vector3 newpos;
	Vector3 i;
	public Animator ani;
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;


  	public string unitName;

  	// Use this for initialization
  	void Start()
  	{
    	_rigidbody = GetComponent<Rigidbody>();
		_SoldierClass = new SoldierCharacterClass();
		_greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
    	_inputManager = new InputManager();
    	_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    	_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
    	showingMovementRange = false;
    	revealed = false;
		clickCount = 0;
		_gameControllerScript.ESoldier1IsCover = true;
		_gameControllerScript.ESoldier2IsCover = true;
		_gameControllerScript.ESoldier3IsCover = true;
		_gameControllerScript.ESoldier4IsCover = true;
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
								ClickTile = hits[i].transform.gameObject.name;
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
		if(ani&&Iswalk)
		{
			ani.SetFloat("Speed",1,0.1f,Time.deltaTime);
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
			if(_gameControllerScript.ESoldier1IsCover && this.gameObject.name == "ESoldier1" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier1")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}			
			else if(_gameControllerScript.ESoldier2IsCover && this.gameObject.name == "ESoldier2"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}

			else if(_gameControllerScript.ESoldier3IsCover && this.gameObject.name == "ESoldier3" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier3")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(_gameControllerScript.ESoldier4IsCover && this.gameObject.name == "ESoldier4" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4")
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			if(!_gameControllerScript.ESoldier1IsCover && this.gameObject.name == "ESoldier1" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier1")
			{
				panel.transform.Find("see").gameObject.SetActive(false);			
			}			
			else if(!_gameControllerScript.ESoldier2IsCover && this.gameObject.name == "ESoldier2"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2")
			{
				panel.transform.Find("see").gameObject.SetActive(false);			
			}
			else if(!_gameControllerScript.ESoldier3IsCover && this.gameObject.name == "ESoldier3" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier3")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
			else if(!_gameControllerScript.ESoldier4IsCover && this.gameObject.name == "ESoldier4" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4")
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
		GameObject Model;
		Model = this.transform.FindChild("Orc_Warrior").gameObject;
		Vector3 currentPosition = this.transform.position;
		newpos= new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		//down
		if(newPosition.x < currentPosition.x)
		{
			walkarround = "down";
			i = new Vector3(0,270,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//up
		else if(newPosition.x > currentPosition.x)
		{
			walkarround = "up";
			i = new Vector3(0,90,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//right
		else if(newPosition.z < currentPosition.z)
		{
			walkarround = "right";
			i = new Vector3(0,180,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//left
		else if(newPosition.z > currentPosition.z)
		{
			walkarround = "left";
			i = new Vector3(0,0,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		if(this.gameObject.name == "ESoldier1")
		{
			if(_gameControllerScript.ESoldier1IsCover)
			{
				_gameControllerScript.ESoldier1IsCover = false;
			}
		}
		if(this.gameObject.name == "ESoldier2")
		{
			if(_gameControllerScript.ESoldier2IsCover)
			{
				_gameControllerScript.ESoldier2IsCover = false;
			}
		}
		if(this.gameObject.name == "ESoldier3")
		{
			if(_gameControllerScript.ESoldier3IsCover)
			{
				_gameControllerScript.ESoldier3IsCover = false;
			}
		}
		if(this.gameObject.name == "ESoldier4")
		{
			if(_gameControllerScript.ESoldier4IsCover)
			{
				_gameControllerScript.ESoldier4IsCover = false;
			}
		}
  	}

	private void showMovementRange()
  	{
		List<Vector3> possibleMoves = _SoldierClass.showMovementRange(_rigidbody.position);
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
		Debug.Log(other.gameObject.name);
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
		//			showingMovementRange = true;
		//			_gameController.GetComponent<GameController>().pieceSelected = true;
		//			_gameController.GetComponent<GameController>().selectedUnit = unitName;
		//			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
		//			showMovementRange();
		//			GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
		if(this.gameObject.name == "ESoldier1" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier1" &&showingMovementRange == false)
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.ESoldier1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "ESoldier2"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.ESoldier2IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "ESoldier3" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier3" &&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.ESoldier3IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "ESoldier4"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.ESoldier4IsCover)
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
		if(_gameControllerScript.ESoldier1IsCover && this.gameObject.name == "ESoldier1" && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier1")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.ESoldier1IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(_gameControllerScript.ESoldier2IsCover && this.gameObject.name == "ESoldier2"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.ESoldier2IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);

			StartCoroutine(waitParticle());
		}
		else if(_gameControllerScript.ESoldier3IsCover && this.gameObject.name == "ESoldier3"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier3")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.ESoldier3IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(_gameControllerScript.ESoldier4IsCover && this.gameObject.name == "ESoldier4"  && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.ESoldier4IsCover = false;
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
		if(this.gameObject.name == "ESoldier1" && _gameControllerScript.ESoldier1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier1")
		{

			GetComponentInChildren<TextMesh>().text = "ESoldier1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "ESoldier2"  && _gameControllerScript.ESoldier2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2")
		{
			GetComponentInChildren<TextMesh>().text = "ESoldier2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "ESoldier3" && _gameControllerScript.ESoldier3IsCover && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier3")
		{

			GetComponentInChildren<TextMesh>().text = "ESoldier3\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "ESoldier4"  && _gameControllerScript.ESoldier4IsCover && _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4")
		{
			GetComponentInChildren<TextMesh>().text = "ESoldier4\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "ESoldier1" && !_gameControllerScript.ESoldier1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "ESoldier1")
		{

			GetComponentInChildren<TextMesh>().text = "ESoldier1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "ESoldier2"  &&!_gameControllerScript.ESoldier2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "ESoldier2")
		{
			GetComponentInChildren<TextMesh>().text = "ESoldier2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "ESoldier3" && !_gameControllerScript.ESoldier3IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "ESoldier3")
		{

			GetComponentInChildren<TextMesh>().text = "ESoldier3";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "ESoldier4"  &&!_gameControllerScript.ESoldier4IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "ESoldier4")
		{
			GetComponentInChildren<TextMesh>().text = "ESoldier4";
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
		this.transform.Find("Orc_Warrior").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waitAttackThenWalk()
	{
		Iswalk = false;
		yield return new WaitForSeconds(2f);
		Iswalk = true;
		iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
	}

	void Move()
	{
		if(ClickTile == "Green(Clone)")
		{
			Iswalk = true;
			iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
			print("walk");
		}
		else if(ClickTile == "Red(Clone)" && !walkafterattack)
		{
			if(walkarround == "up") AttackPos = new Vector3(newpos.x-1f,newpos.y,newpos.z);//up
			if(walkarround == "down") AttackPos = new Vector3(newpos.x+1f,newpos.y,newpos.z);
			if(walkarround == "right") AttackPos = new Vector3(newpos.x,newpos.y,newpos.z+1f);//right
			if(walkarround == "left") AttackPos = new Vector3(newpos.x,newpos.y,newpos.z-1f);
			if(AttackPos != this.gameObject.transform.position)
			{
				Iswalk = true;
				walkafterattack = true;
				iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",AttackPos,"speed",4f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
			}
			else
			{
				walkafterattack = true;
				Move();
			}
		}
		else if(walkafterattack)
		{
			ani.SetTrigger("Attack");
			StartCoroutine(waitAttackThenWalk());
			//			iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
			walkafterattack = false;
			print("walkafter");
		}
	}
	void checkPostion()
	{
		Iswalk = false;
		this.transform.position = newpos;
		ani.SetFloat("Speed",0);
	}
}
