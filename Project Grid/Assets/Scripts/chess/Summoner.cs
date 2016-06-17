using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Summoner : MonoBehaviour
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
	public GameObject panel;
  	public string unitName;
	public Vector3 newpos;
	Vector3 i;
	public Animator ani;
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;

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
		_gameControllerScript.SummnonerIsCover = true;
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
        		if(clickCount >= 0)
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
		if(_gameControllerScript.PlayerSide%2 == 0&!_gameControllerScript.SideEnd)
		{
			if(_gameControllerScript.TheTwiceStepSoldierName == "" && _gameControllerScript.SacrificeHitSelectName =="" && _gameControllerScript.TwoKnivesBatterName == "" &&!_gameControllerScript.MindControlTurnOn &&!_gameControllerScript.CommanderSelectTurnOn &&!_gameControllerScript.intuitionSelectTurnOn)
			{
				if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected)
				{
					if(GameObject.Find("myinceasecard3"))
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeSelect = false;
						GameObject.Find("myinceasecard3").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
					}
					panel.SetActive(true);
					_gameController.GetComponent<GameController>().pieceSelected = true;
					_gameController.GetComponent<GameController>().selectedUnit = unitName;
					_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
					if(_gameControllerScript.SummnonerIsCover)
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					else if(!_gameControllerScript.SummnonerIsCover)
					{
						panel.transform.Find("see").gameObject.SetActive(false);
					}
				}
			}
			if(GameObject.Find("myinceasecard10"))
			{
				if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect && GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep == 2)
				{
					this.gameObject.GetComponent<MeshRenderer>().enabled = true;
					this.transform.FindChild("Character").GetComponent<MeshRenderer>().enabled = true;
					this.transform.FindChild("human_wizard_Rig").gameObject.SetActive(false);
					if(!_gameControllerScript.SummnonerIsCover && this.name == "Summoner1")
					{
						_gameControllerScript.SummnonerIsCover = true;
						this.GetComponentInChildren<TextMesh>().text = "Summoner\n(cover)";
						GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					}
				}
				else if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect && GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep == 1)
				{
					Vector3 tmp = this.transform.position;
					if(_gameControllerScript.PreSelectedUnit == "Priest1" && _gameControllerScript.SummnonerIsCover && this.name == "Summoner1")
					{
						this.transform.position = GameObject.Find("Priest1").transform.position;
						GameObject.Find("Priest1").transform.position = tmp;
						GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
						GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
						_gameControllerScript.MindControlTurnOn = false;
						GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
						_gameControllerScript.SideEnd = true;
					}
					else if(_gameControllerScript.PreSelectedUnit == "Priest2" && _gameControllerScript.SummnonerIsCover && this.name == "Summoner1")
					{
						this.transform.position = GameObject.Find("Priest2").transform.position;
						GameObject.Find("Priest2").transform.position = tmp;
						GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
						GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
						_gameControllerScript.MindControlTurnOn = false;
						GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
						_gameControllerScript.SideEnd = true;
					}
					if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlCount == 0)
						GameObject.Find("myinceasecard10").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,80/255f);
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
		Model = this.transform.FindChild("human_wizard_Rig").gameObject;
		Vector3 currentPosition = this.transform.position;
		newpos= new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		//down
		if(newPosition.x < currentPosition.x && newPosition.z == currentPosition.z)
		{
			walkarround = "down";
			i = new Vector3(0,270,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//up
		else if(newPosition.x > currentPosition.x && newPosition.z == currentPosition.z)
		{
			walkarround = "up";
			i = new Vector3(0,90,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//right
		else if(newPosition.z < currentPosition.z && newPosition.x == currentPosition.x)
		{
			walkarround = "right";
			i = new Vector3(0,180,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//left
		else if(newPosition.z > currentPosition.z && newPosition.x == currentPosition.x)
		{
			walkarround = "left";
			i = new Vector3(0,0,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//rightup
		else if(newPosition.z < currentPosition.z && newPosition.x > currentPosition.x)
		{
			walkarround = "rightup";
			i = new Vector3(0,135,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//leftup
		else if(newPosition.z > currentPosition.z && newPosition.x > currentPosition.x)
		{
			walkarround = "leftup";
			i = new Vector3(0,45,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//rightdown
		else if(newPosition.z < currentPosition.z && newPosition.x < currentPosition.x)
		{
			walkarround = "rightdown";
			i = new Vector3(0,-135,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//leftdown
		else if(newPosition.z > currentPosition.z && newPosition.x < currentPosition.x)
		{
			walkarround = "leftdown";
			i = new Vector3(0,-45,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}

		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		if(this.gameObject.name == "Summnoner1")
		{
			if(_gameControllerScript.SummnonerIsCover)
			{
				_gameControllerScript.SummnonerIsCover = false;
			}
		}
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
//		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit){
//			if(other.gameObject.tag=="EmenyCharacter")
//			{
//				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
//				{
//					if(other.gameObject.name == "EAssassin1")
//					{
//						_gameControllerScript.EAssassin1IsCover = false;
//						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
//					}
//					else if(other.gameObject.name == "EAssassin2")
//					{
//						_gameControllerScript.EAssassin2IsCover = false;
//						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
//					}
//					Destroy(this.gameObject);
//				}
//				else
//				{
//					Destroy(other.gameObject);
//				}
//			}
//		}
	}
	public void attack()
	{
		if(_gameController.GetComponent<GameController>().selectedUnit == "Summoner1")
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.SummnonerIsCover)
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
		if(_gameControllerScript.SummnonerIsCover)
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.SummnonerIsCover = false;
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
		if(GameObject.Find("myinceasecard2"))
		{
			GameObject.Find("myinceasecard2").GetComponent<UIButton>().ResetDefaultColor();
			GameObject.Find("myinceasecard2").GetComponent<UIButton>().enabled = false;
			GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().enabled = false;
			GameObject.Find("myinceasecard2").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
		}
	}
	public void cannel()
	{
		if(_gameControllerScript.SummnonerIsCover && _gameController.GetComponent<GameController>().selectedUnit == "Summoner1")
		{

			GetComponentInChildren<TextMesh>().text = "Summnoner\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(!_gameControllerScript.SummnonerIsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Summoner1")
		{
			GetComponentInChildren<TextMesh>().text = "Summnoner1";
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
		this.transform.Find("human_wizard_Rig").gameObject.SetActive(true);
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
			if(walkarround == "rightup") AttackPos = new Vector3(newpos.x-1f,newpos.y,newpos.z+1f);
			if(walkarround == "leftup") AttackPos = new Vector3(newpos.x-1f,newpos.y,newpos.z-1f);
			if(walkarround == "rightdown") AttackPos = new Vector3(newpos.x+1f,newpos.y,newpos.z+1f);
			if(walkarround == "leftdown") AttackPos = new Vector3(newpos.x+1f,newpos.y,newpos.z-1f);
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
