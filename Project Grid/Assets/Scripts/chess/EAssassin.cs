using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EAssassin : MonoBehaviour
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
	public Vector3 newpos;
	Vector3 i;
	public Animator ani;
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;
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
		_gameControllerScript.EAssassin1IsCover = true;
		_gameControllerScript.EAssassin2IsCover = true;
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
//		if(_gameControllerScript.PlayerSide % 2 == 1)
//		{
			if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected)
			{
				panel.SetActive(true);
				_gameController.GetComponent<GameController>().pieceSelected = true;
				_gameController.GetComponent<GameController>().selectedUnit = unitName;
				_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
				if(_gameControllerScript.EAssassin1IsCover && this.gameObject.name == "EAssassin1" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin1")
				{
					panel.transform.Find("OK").gameObject.SetActive(false);
					GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
				}
				else if(_gameControllerScript.EAssassin2IsCover && this.gameObject.name == "EAssassin2" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2")
				{
					panel.transform.Find("OK").gameObject.SetActive(false);
					GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
				}
				else if(!_gameControllerScript.EAssassin1IsCover && this.gameObject.name == "EAssassin1" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin1")
				{
					panel.transform.Find("see").gameObject.SetActive(false);
				}
				else if(!_gameControllerScript.EAssassin2IsCover && this.gameObject.name == "EAssassin2" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2")
				{
					panel.transform.Find("see").gameObject.SetActive(false);
				}
			}
		if(GameObject.Find("myinceasecard4"))
		{
			if(GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect && _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
			{
				see();
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed = true;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().ResetDefaultColor();
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				GameObject.Find("Hero1").GetComponent<Hero>().see();
				print(GameObject.Find("myinceasecard4").GetComponent<UILabel>().color);
			}
		}
//		}
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
		Model = this.transform.FindChild("Orc_Assassin").gameObject;
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
		if(this.gameObject.name == "EAssassin1")
		{
			if(_gameControllerScript.EAssassin1IsCover)
			{
				_gameControllerScript.EAssassin1IsCover = false;
			}
		}
		if(this.gameObject.name == "EAssassin2")
		{
			if(_gameControllerScript.EAssassin2IsCover)
			{
				_gameControllerScript.EAssassin2IsCover = false;
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
//									iTween.ColorTo(moveRangeTile,new Color(255/255f,0/255f,0/255f,50/255f),5f);
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
		if(this.gameObject.name == "EAssassin1" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin1" &&showingMovementRange == false)
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.EAssassin1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "EAssassin2"  && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.EAssassin2IsCover)
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
//		if(_gameControllerScript.EAssassin1IsCover && this.gameObject.name == "EAssassin1" && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin1")
//		{
			GetComponentInChildren<TextMesh>().text = unitName;
		if(this.name == "EAssassin1")
		{
			_gameControllerScript.EAssassin1IsCover = false;
		}
		else if(this.name == "EAssassin2")
		{
			_gameControllerScript.EAssassin2IsCover = false;
		}
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
//		}
//		else if(_gameControllerScript.EAssassin2IsCover && this.gameObject.name == "EAssassin2"  && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2")
//		{
//			GetComponentInChildren<TextMesh>().text = unitName;
//			_gameControllerScript.EAssassin2IsCover = false;
//			panel.SetActive(false);
//			_gameController.GetComponent<GameController>().selectedUnit = "";
//			_gameController.GetComponent<GameController>().pieceSelected = false;
//			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
//			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
//
//			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
//
//			StartCoroutine(waitParticle());
//		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
	}
	public void cannel()
	{
		if(this.gameObject.name == "EAssassin1" && _gameControllerScript.EAssassin1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin1")
		{

			GetComponentInChildren<TextMesh>().text = "EAssassin1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EAssassin2"  && _gameControllerScript.EAssassin2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2")
		{
			GetComponentInChildren<TextMesh>().text = "EAssassin2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "EAssassin1" && !_gameControllerScript.EAssassin1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "EAssassin1")
		{

			GetComponentInChildren<TextMesh>().text = "EAssassin1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EAssassin2"  &&!_gameControllerScript.EAssassin2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "EAssassin2")
		{
			GetComponentInChildren<TextMesh>().text = "EAssassin2";
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

		if(ColliderName == "EAssassin1" )
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.EAssassin1IsCover = false;
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		else if(ColliderName == "EAssassin2")
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.EAssassin2IsCover = false;
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
		this.transform.Find("Orc_Assassin").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waitAttackThenWalk()
	{
		AttackShot.GetComponent<triggerProjectile_EAssassin>().shoot();
		yield return new WaitForSeconds(0.8f);
		if(!GameObject.Find("myinceasecard2") || (GameObject.Find("myinceasecard2") && !GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().isActiveAndEnabled))
		{
			Iswalk = false;
			yield return new WaitForSeconds(1f);
			Iswalk = true;
			iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
		}
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
			ani.SetTrigger("Attack");
			StartCoroutine(waitAttackThenWalk());
		}
	}
	void checkPostion()
	{
		Iswalk = false;
		this.transform.position = newpos;
		ani.SetFloat("Speed",0);
//		_gameControllerScript.PlayerSide++;
	}
	public void TheItalianJobStep2()
	{
		AttackShot.GetComponent<triggerProjectile_EAssassin>().shoot();
		StartCoroutine(ForStep2());
	}
	IEnumerator ForStep2()
	{
		ani.SetTrigger("Attack");
		yield return new WaitForSeconds(1.2f);
		Iswalk = true;
		iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
	}
}
