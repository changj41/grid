using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Assassin : MonoBehaviour
{

	private Rigidbody _rigidbody;
	private AssassinCharacterClass _AssassinClass;
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
	public GameObject EAssassin1;
	public GameObject EAssassin2;
	public Vector3 newpos;
	Vector3 i;
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;
	public GameObject ThisAssassin;
	public GameObject AttackShot;

  	// Use this for initialization
  	void Start()
  	{
	    _rigidbody = GetComponent<Rigidbody>();
		_AssassinClass = new AssassinCharacterClass();
	    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
	    _inputManager = new InputManager();
	    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
	    _gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;
		_gameControllerScript.Assassin1IsCover = true;
		_gameControllerScript.Assassin2IsCover = true;
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
				if(_gameControllerScript.Assassin1IsCover && this.gameObject.name == "Assassin1" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin1")
				{
					panel.transform.Find("OK").gameObject.SetActive(false);
					GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
				}
				else if(_gameControllerScript.Assassin2IsCover && this.gameObject.name == "Assassin2" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin2")
				{
					panel.transform.Find("OK").gameObject.SetActive(false);
					GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
				}
				else if(!_gameControllerScript.Assassin1IsCover && this.gameObject.name == "Assassin1" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin1")
				{
					panel.transform.Find("see").gameObject.SetActive(false);
				}
				else if(!_gameControllerScript.Assassin2IsCover && this.gameObject.name == "Assassin2" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin2")
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
				this.gameObject.GetComponent<Assassin>().see();
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
		GameObject Model;
		Model = this.transform.FindChild("PF_AssassinGirl").gameObject;
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
		if(this.gameObject.name == "Assassin1")
		{
			if(_gameControllerScript.Assassin1IsCover)
			{
				_gameControllerScript.Assassin1IsCover = false;
			}
		}
		if(this.gameObject.name == "Assassin2")
		{
			if(_gameControllerScript.Assassin2IsCover)
			{
				_gameControllerScript.Assassin2IsCover = false;
			}
		}
  	}

  	private void showMovementRange()
  	{
		List<Vector3> possibleMoves = _AssassinClass.showMovementRange(_rigidbody.position);
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
		
	public void attack()
	{
		if(this.gameObject.name == "Assassin1" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin1" &&showingMovementRange == false)
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.Assassin1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Assassin2"  && _gameController.GetComponent<GameController>().selectedUnit == "Assassin2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Assassin2IsCover)
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
		if(_gameControllerScript.Assassin1IsCover && this.gameObject.name == "Assassin1" && _gameController.GetComponent<GameController>().selectedUnit == "Assassin1")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Assassin1IsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(_gameControllerScript.Assassin2IsCover && this.gameObject.name == "Assassin2"  && _gameController.GetComponent<GameController>().selectedUnit == "Assassin2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Assassin2IsCover = false;
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
		if(this.gameObject.name == "Assassin1" && _gameControllerScript.Assassin1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Assassin1")
		{

			GetComponentInChildren<TextMesh>().text = "Assassin1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Assassin2"  && _gameControllerScript.Assassin2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Assassin2")
		{
			GetComponentInChildren<TextMesh>().text = "Assassin2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "Assassin1" && !_gameControllerScript.Assassin1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "Assassin1")
		{

			GetComponentInChildren<TextMesh>().text = "Assassin1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Assassin2"  &&!_gameControllerScript.Assassin2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Assassin2")
		{
			GetComponentInChildren<TextMesh>().text = "Assassin2";
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
	public void Speicialsee(string ColliderName)
	{

		if(ColliderName == "Assassin1" )
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Assassin1IsCover = false;
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(ColliderName == "Assassin2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.Assassin2IsCover = false;
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
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("PF_AssassinGirl").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waitAttackThenWalk()
	{
		ThisAssassin.GetComponent<Animation>().wrapMode= WrapMode.Once;
		ThisAssassin.GetComponent<Animation>().CrossFade("Attack01");
		AttackShot.GetComponent<triggerProjectile_Assassin>().shoot();
		yield return new WaitForSeconds(0.5f);
		ThisAssassin.GetComponent<Animation>().wrapMode = WrapMode.Loop;
		ThisAssassin.GetComponent<Animation>().CrossFade("Idle");
		Iswalk = false;
		yield return new WaitForSeconds(1f);
		Iswalk = true;
		ThisAssassin.GetComponent<Animation>().wrapMode= WrapMode.Loop;
		ThisAssassin.GetComponent<Animation>().CrossFade("Run");
		iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
	}

	void Move()
	{
		if(ClickTile == "Green(Clone)")
		{
			Iswalk = true;
			ThisAssassin.GetComponent<Animation>().wrapMode= WrapMode.Loop;
			ThisAssassin.GetComponent<Animation>().CrossFade("Run");
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
				print ("run");
				ThisAssassin.GetComponent<Animation>().wrapMode= WrapMode.Loop;
				ThisAssassin.GetComponent<Animation>().CrossFade("Run");
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
			StartCoroutine(waitAttackThenWalk());
//			iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
			walkafterattack = false;
			print("walkafter");
		}
	}
	void checkPostion()
	{
		ThisAssassin.GetComponent<Animation>().wrapMode = WrapMode.Loop;
		ThisAssassin.GetComponent<Animation>().CrossFade("Idle");
		Iswalk = false;
		this.transform.position = newpos;
	}
}


