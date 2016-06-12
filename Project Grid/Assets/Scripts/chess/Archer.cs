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
	public Vector3 newpos;
	public Animator ani;
	string ClickTile;
	Vector3 i;
	Vector3 hitpos;

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
								ClickTile = hits[i].transform.gameObject.name;
								hitpos = hits[i].transform.position;
								if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer1" && _gameControllerScript.Archer1IsCover)
								{
									this.gameObject.GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
									StartCoroutine(waitParticle());
								}
								else if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer2" && _gameControllerScript.Archer2IsCover)
								{
									this.gameObject.GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
									StartCoroutine(waitParticle());
//									StartCoroutine(waittimetomove(hits[i].transform.position));

								}
								else if((_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer1" && !_gameControllerScript.Archer1IsCover) 
									||(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer2" && !_gameControllerScript.Archer2IsCover))
								{
										StartCoroutine(waittimetomove(hits[i].transform.position));
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
		if(_gameControllerScript.PlayerSide%2 == 0)
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
			}
			if(GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeSelect && GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount > 0)
			{
				GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount--;
				if(GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount <= 0)
				{
					GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeSelect = false;
					GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeUsed = true;
					GameObject.Find("myinceasecard3").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard3").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard3").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard3").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				}
				this.gameObject.GetComponent<Archer>().see();
			}
		}
		if(GameObject.Find("myinceasecard2"))
		{
			if(GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobSelect)
			{
				GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobSelect = false;
				GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed = true;
				GameObject.Find("myinceasecard2").GetComponent<UIButton>().ResetDefaultColor();
				GameObject.Find("myinceasecard2").GetComponent<UIButton>().enabled = false;
				GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard2").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				Vector3 tmp = this.transform.position;
				this.transform.position = GameObject.Find("Summoner1").transform.position;
				GameObject.Find("Summoner1").transform.position = tmp;
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier2"
					||_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier3" || _gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier4")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<ESoldier>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight2")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<EKnight>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin2")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<EAssassin>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<EArcher>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior2")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<Ewarrior>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESummoner1")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<ESummoner>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EHero1")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<EHero>().TheItalianJobStep2();
				}
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest2")
				{
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).GetComponent<EPriest>().TheItalianJobStep2();
				}
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
		newpos= new Vector3(newPosition.x, currentPosition.y, newPosition.z);
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

								if(hit.collider.name != tempname /*&& hit.collider.tag != this.gameObject.tag*/)
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
		if(ClickTile == "Red(Clone)")
		{
			StartCoroutine(waittimetomove(hitpos));
		}
	}
	IEnumerator waittimetomove(Vector3 pos){
		GameObject Model;
		Model = this.transform.FindChild("human_archer_Rig").gameObject;
		Vector3 currentPosition = this.transform.position;
		//down
		if(pos.x < currentPosition.x)
		{
			i = new Vector3(0,270,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//up
		else if(pos.x > currentPosition.x)
		{
			i = new Vector3(0,90,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//right
		else if(pos.z < currentPosition.z)
		{
			i = new Vector3(0,180,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//left
		else if(pos.z > currentPosition.z)
		{
			i = new Vector3(0,0,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		newpos = pos;
		if(ClickTile == "Red(Clone)")
		{
			yield return new WaitForSeconds(1.0f);
			ani.SetTrigger("Attack");
		}
		yield return new WaitForSeconds(2.0f);
		moveCharacter(pos);
	}

}
