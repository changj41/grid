﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hero : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private HeroCharacterClass _heroClass;
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
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;
	public GameObject ThisHero;
	public GameObject AttackShot;

	// Use this for initialization
	void Start()
	{
    	_rigidbody = GetComponent<Rigidbody>();
    	_heroClass = new HeroCharacterClass();
    	_greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
    	_inputManager = new InputManager();
    	_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    	_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
    	showingMovementRange = false;
    	revealed = false;
    	clickCount = 0;
		_gameControllerScript.HeroIsCover = true;
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
  	}

  	void OnMouseDown()
  	{
		if(_gameControllerScript.PlayerSide%2 == 0 && !_gameControllerScript.SideEnd && _gameControllerScript.PlayerSide !=0)
		{
			if(_gameControllerScript.TheTwiceStepSoldierName == "" && _gameControllerScript.SacrificeHitSelectName =="" && _gameControllerScript.TwoKnivesBatterName == ""&&!_gameControllerScript.MindControlTurnOn &&!_gameControllerScript.CommanderSelectTurnOn &&!_gameControllerScript.intuitionSelectTurnOn)
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
					if(GameObject.Find("myinceasecard4"))
					{
						if(!GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed)
						{
							GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().Play();
						}
					}
					if(_gameControllerScript.HeroIsCover)
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					else if(!_gameControllerScript.HeroIsCover)
					{
						panel.transform.Find("see").gameObject.SetActive(false);
					}
				}
			}
		}
		if(GameObject.Find("myinceasecard2"))
		{
			if(GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobSelect)
			{
				GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobSelect = false;
				GameObject.Find("myinceasecard2").GetComponent<UIButton>().ResetDefaultColor();
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
		if(GameObject.Find("myinceasecard10"))
		{
			if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect && GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep == 2)
			{
				if(!_gameControllerScript.HeroIsCover)
				{
					print("1");
					_gameControllerScript.HeroIsCover = true;
					this.GetComponentInChildren<TextMesh>().text = "Hero\n(cover)";
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				}
			}
			else if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect && GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep == 1)
			{
				print("2");
				GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
				_gameControllerScript.MindControlTurnOn = false;
				GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
				Vector3 tmp = this.transform.position;
				if(_gameControllerScript.PreSelectedUnit == "Priest1")
				{
					this.transform.position = GameObject.Find("Priest1").transform.position;
					GameObject.Find("Priest1").transform.position = tmp;
				}
				_gameControllerScript.SideEnd = true;
				if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlCount == 0)
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().defaultColor = new Color(225/255f,0/255f,0/255f,255/255f);
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
		newpos = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		if(ClickTile == "Red(Clone)")
		{
			StartCoroutine(waitAttackThenWalk());
		}
		else if(ClickTile == "Green(Clone)")
		{
			this.transform.position = newpos;
		}

		if(this.gameObject.name == "Hero1")
		{
			if(_gameControllerScript.HeroIsCover)
			{
				_gameControllerScript.HeroIsCover = false;
			}
		}

  	}

 	private void showMovementRange()
  	{
    	List<Vector3> possibleMoves = _heroClass.showMovementRange(_rigidbody.position);
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
		if(_gameController.GetComponent<GameController>().selectedUnit == "Hero1")
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.HeroIsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name;
			}
		}
	}
	public void see()
	{
		if(_gameControllerScript.HeroIsCover)
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.HeroIsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
//			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
//			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
			if(GameObject.Find("myinceasecard4"))
			{
				if(!GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed)
				{
					GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
					GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
				}
			}
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
		_gameControllerScript.SideEnd = true;
	}
	public void cannel()
	{
		if(_gameControllerScript.HeroIsCover && _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
		{

			GetComponentInChildren<TextMesh>().text = "Hero\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(!_gameControllerScript.HeroIsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
		{
			GetComponentInChildren<TextMesh>().text = "Hero1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
		clickCount = 0;
		if(GameObject.Find("myinceasecard4"))
		{
			if(!GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed)
			{
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
				GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
//		this.transform.Find("human_wizard_Rig").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waitAttackThenWalk()
	{
		AttackShot.GetComponent<triggerProjectile_Hero>().shoot();
		yield return new WaitForSeconds(2.0f);
		this.transform.position = newpos;
		if(GameObject.Find("myinceasecard4"))
		{
			if(!GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed)
			{
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
				GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
		_gameControllerScript.SideEnd = true;
	}
}
