﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soldier : MonoBehaviour
{

	private Rigidbody _rigidbody;
	private SoldierCharacterClass _SoldierClass;
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
	public Vector3 newpos;
	Vector3 i;
	public Animator ani;
	public bool Iswalk;
	string ClickTile;
	bool walkafterattack = false;
	Vector3 AttackPos;
	string walkarround;
	public int twicestep;
	public bool twicestepTurnOn;


  	public string unitName;

  	// Use this for initialization
  	void Start()
  	{
    	_rigidbody = GetComponent<Rigidbody>();
		_SoldierClass = new SoldierCharacterClass();
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
		_gameControllerScript.Soldier1IsCover = true;
		_gameControllerScript.Soldier2IsCover = true;
		_gameControllerScript.Soldier3IsCover = true;
		_gameControllerScript.Soldier4IsCover = true;
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
		if(_gameControllerScript.PlayerSide%2 == 0 && !_gameControllerScript.SideEnd &&_gameControllerScript.PlayerSide !=0)
		{
			if(_gameControllerScript.TheTwiceStepSoldierName == ""  && _gameControllerScript.SacrificeHitSelectName =="" && _gameControllerScript.TwoKnivesBatterName == "" && !_gameControllerScript.MindControlTurnOn && !_gameControllerScript.CommanderSelectTurnOn &&!_gameControllerScript.intuitionSelectTurnOn)
			{
				if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected)
				{
					panel.SetActive(true);
					_gameController.GetComponent<GameController>().pieceSelected = true;
					_gameController.GetComponent<GameController>().selectedUnit = unitName;
					_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
					if(_gameControllerScript.Soldier1IsCover && this.gameObject.name == "Soldier1" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					else if(_gameControllerScript.Soldier2IsCover && this.gameObject.name == "Soldier2" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					else if(_gameControllerScript.Soldier3IsCover && this.gameObject.name == "Soldier3" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					else if(_gameControllerScript.Soldier4IsCover && this.gameObject.name == "Soldier4" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
					}
					if(!_gameControllerScript.Soldier1IsCover && this.gameObject.name == "Soldier1" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
					else if(!_gameControllerScript.Soldier2IsCover && this.gameObject.name == "Soldier2" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
					else if(!_gameControllerScript.Soldier3IsCover && this.gameObject.name == "Soldier3" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
					else if(!_gameControllerScript.Soldier4IsCover && this.gameObject.name == "Soldier4" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
				}
			}
			if(_gameControllerScript.TheTwiceStepSoldierName != "")
			{
				if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected && this.name == _gameControllerScript.TheTwiceStepSoldierName)
				{
					panel.SetActive(true);
					_gameController.GetComponent<GameController>().pieceSelected = true;
					_gameController.GetComponent<GameController>().selectedUnit = unitName;
					_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
					if(_gameControllerScript.Soldier1IsCover && this.gameObject.name == "Soldier1" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
						if(!_gameControllerScript.Soldier1IsCover) panel.transform.Find("see").gameObject.SetActive(false);
					}
					else if(_gameControllerScript.Soldier2IsCover && this.gameObject.name == "Soldier2" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
						if(!_gameControllerScript.Soldier2IsCover) panel.transform.Find("see").gameObject.SetActive(false);
					}
					else if(_gameControllerScript.Soldier3IsCover && this.gameObject.name == "Soldier3" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
						if(!_gameControllerScript.Soldier3IsCover) panel.transform.Find("see").gameObject.SetActive(false);
					}
					else if(_gameControllerScript.Soldier4IsCover && this.gameObject.name == "Soldier4" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
					{
						panel.transform.Find("OK").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
						if(!_gameControllerScript.Soldier4IsCover) panel.transform.Find("see").gameObject.SetActive(false);
					}
					if(!_gameControllerScript.Soldier1IsCover && this.gameObject.name == "Soldier1" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name ;
					}
					else if(!_gameControllerScript.Soldier2IsCover && this.gameObject.name == "Soldier2" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name ;
					}
					else if(!_gameControllerScript.Soldier3IsCover && this.gameObject.name == "Soldier3" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
					else if(!_gameControllerScript.Soldier4IsCover && this.gameObject.name == "Soldier4" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
					{
						panel.transform.Find("see").gameObject.SetActive(false);
						GetComponentInChildren<TextMesh>().text = this.gameObject.name;
					}
				}
			}
			if(GameObject.Find("myinceasecard3"))
			{
				if(GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeSelect && GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount > 0)
				{
					if(_gameControllerScript.Soldier1IsCover && this.name == "Soldier1") 
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount--;
						this.gameObject.GetComponent<Soldier>().see();
					}
					if(_gameControllerScript.Soldier2IsCover && this.name == "Soldier2") 
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount--;
						this.gameObject.GetComponent<Soldier>().see();
					}
					if(_gameControllerScript.Soldier3IsCover && this.name == "Soldier3") 
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount--;
						this.gameObject.GetComponent<Soldier>().see();
					}
					if(_gameControllerScript.Soldier4IsCover && this.name == "Soldier4")
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount--;
						this.gameObject.GetComponent<Soldier>().see();
					}
					if(GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeCount <= 0)
					{
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeSelect = false;
						GameObject.Find("myinceasecard3").GetComponent<InceaseCard>().BigDecreeUsed = true;
						GameObject.Find("myinceasecard3").GetComponent<UIButton>().ResetDefaultColor();
						GameObject.Find("myinceasecard3").GetComponent<UIButton>().enabled = false;
						GameObject.Find("myinceasecard3").GetComponent<TweenAlpha>().enabled = false;
						GameObject.Find("myinceasecard3").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
						_gameControllerScript.SideEnd = true;
					}
				}
			}
		}
		if(_gameControllerScript.PlayerSide%2 == 0 && _gameControllerScript.TheSoulPursueAndAttackSelectTurnOn && GameObject.Find("myinceasecard7"))
		{
			print("123");
			GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackSelect = false;
			_gameControllerScript.TheSoulPursueAndAttackSelectTurnOn = false;
			GameObject.Find("myinceasecard7").GetComponent<UIButton>().ResetDefaultColor();
			GameObject.Find("myinceasecard7").GetComponent<TweenAlpha>().enabled = false;
			GameObject.Find("myinceasecard7").GetComponent<BoxCollider>().enabled = false;
			_gameControllerScript.TheTwiceStepSoldierName = this.name;
			this.twicestep = 2;
			twicestepTurnOn = true;
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
				if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Ewarrior1"||_gameController.GetComponent<GameController>().PreSelectedUnit == "Ewarrior2")
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
				this.gameObject.GetComponent<MeshRenderer>().enabled = true;
				this.transform.FindChild("Character").GetComponent<MeshRenderer>().enabled = true;
				this.transform.FindChild("Human_MasterRig").gameObject.SetActive(false);
				if(!_gameControllerScript.Soldier1IsCover && this.name == "Soldier1")
				{
					_gameControllerScript.Soldier1IsCover = true;
					this.GetComponentInChildren<TextMesh>().text = "Soldier1\n(cover)";
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				}
				else if(!_gameControllerScript.Soldier2IsCover && this.name == "Soldier2")
				{
					_gameControllerScript.Soldier2IsCover = true;
					this.GetComponentInChildren<TextMesh>().text = "Soldier2\n(cover)";
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				}
				else if(!_gameControllerScript.Soldier3IsCover && this.name == "Soldier3")
				{
					_gameControllerScript.Soldier3IsCover = true;
					this.GetComponentInChildren<TextMesh>().text = "Soldier3\n(cover)";
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				}
				else if(!_gameControllerScript.Soldier4IsCover && this.name == "Soldier4")
				{
					_gameControllerScript.Soldier4IsCover = true;
					this.GetComponentInChildren<TextMesh>().text = "Soldier4\n(cover)";
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
				}
			}
			else if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect && GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep == 1)
			{
				Vector3 tmp = this.transform.position;
				if(_gameControllerScript.PreSelectedUnit == "Priest1" && _gameControllerScript.Soldier1IsCover && this.name == "Soldier1")
				{
					this.transform.position = GameObject.Find("Priest1").transform.position;
					GameObject.Find("Priest1").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest1" && _gameControllerScript.Soldier2IsCover && this.name == "Soldier2")
				{
					this.transform.position = GameObject.Find("Priest1").transform.position;
					GameObject.Find("Priest1").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest1" && _gameControllerScript.Soldier3IsCover && this.name == "Soldier3")
				{
					this.transform.position = GameObject.Find("Priest1").transform.position;
					GameObject.Find("Priest1").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest1" && _gameControllerScript.Soldier4IsCover && this.name == "Soldier4")
				{
					this.transform.position = GameObject.Find("Priest1").transform.position;
					GameObject.Find("Priest1").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest2" && _gameControllerScript.Soldier1IsCover && this.name == "Soldier1")
				{
					this.transform.position = GameObject.Find("Priest2").transform.position;
					GameObject.Find("Priest2").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest2" && _gameControllerScript.Soldier2IsCover && this.name == "Soldier2")
				{
					this.transform.position = GameObject.Find("Priest2").transform.position;
					GameObject.Find("Priest2").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest2" && _gameControllerScript.Soldier3IsCover && this.name == "Soldier3")
				{
					this.transform.position = GameObject.Find("Priest2").transform.position;
					GameObject.Find("Priest2").transform.position = tmp;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelectStep--;
					GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
					_gameControllerScript.MindControlTurnOn = false;
					GameObject.Find("myinceasecard10").GetComponent<UIButton>().ResetDefaultColor();
					_gameControllerScript.SideEnd = true;
				}
				else if(_gameControllerScript.PreSelectedUnit == "Priest2" && _gameControllerScript.Soldier4IsCover && this.name == "Soldier4")
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
		if(GameObject.Find("myinceasecard14") && _gameControllerScript.CommanderSelectTurnOn)
		{
			if(_gameControllerScript.Soldier1IsCover && this.name == "Soldier1")
			{
				if(_gameControllerScript.CommanderSelectName1 =="")
				{
					_gameControllerScript.CommanderSelectName1 = this.gameObject.name;
				}
				else if(_gameControllerScript.CommanderSelectName2 =="")
				{
					_gameControllerScript.CommanderSelectName2 = this.gameObject.name;
				}
				_gameControllerScript.CommanderSelectTurnOn = false;
				_gameControllerScript.SideEnd = true;
				if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().MindControlCount != 0)
				GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,255/255f);
			}
			else if(_gameControllerScript.Soldier2IsCover && this.name == "Soldier2")
			{
				if(_gameControllerScript.CommanderSelectName1 =="")
				{
					_gameControllerScript.CommanderSelectName1 = this.gameObject.name;
				}
				else if(_gameControllerScript.CommanderSelectName2 =="")
				{
					_gameControllerScript.CommanderSelectName2 = this.gameObject.name;
				}
				_gameControllerScript.CommanderSelectTurnOn = false;
				_gameControllerScript.SideEnd = true;
				if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().MindControlCount != 0)
					GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,255/255f);
			}
			else if(_gameControllerScript.Soldier3IsCover && this.name == "Soldier3")
			{
				if(_gameControllerScript.CommanderSelectName1 =="")
				{
					_gameControllerScript.CommanderSelectName1 = this.gameObject.name;
				}
				else if(_gameControllerScript.CommanderSelectName2 =="")
				{
					_gameControllerScript.CommanderSelectName2 = this.gameObject.name;
				}
				_gameControllerScript.CommanderSelectTurnOn = false;
				_gameControllerScript.SideEnd = true;
				if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().MindControlCount != 0)
					GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,255/255f);
			}
			else if(_gameControllerScript.Soldier4IsCover && this.name == "Soldier4")
			{
				if(_gameControllerScript.CommanderSelectName1 =="")
				{
					_gameControllerScript.CommanderSelectName1 = this.gameObject.name;
				}
				else if(_gameControllerScript.CommanderSelectName2 =="")
				{
					_gameControllerScript.CommanderSelectName2 = this.gameObject.name;
				}
				_gameControllerScript.CommanderSelectTurnOn = false;
				_gameControllerScript.SideEnd = true;
				if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().MindControlCount != 0)
					GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,255/255f);
			}
			if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().MindControlCount == 0)
			{
				GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,80/255f);
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
		Model = this.transform.FindChild("Human_MasterRig").gameObject;
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
		if(this.gameObject.name == "Soldier1")
		{
			if(_gameControllerScript.Soldier1IsCover)
			{
				_gameControllerScript.Soldier1IsCover = false;
			}
		}
		if(this.gameObject.name == "Soldier2")
		{
			if(_gameControllerScript.Soldier2IsCover)
			{
				_gameControllerScript.Soldier2IsCover = false;
			}
		}
		if(this.gameObject.name == "Soldier3")
		{
			if(_gameControllerScript.Soldier3IsCover)
			{
				_gameControllerScript.Soldier3IsCover = false;
			}
		}
		if(this.gameObject.name == "Soldier4")
		{
			if(_gameControllerScript.Soldier4IsCover)
			{
				_gameControllerScript.Soldier4IsCover = false;
			}
		}
  	}

	private void showMovementRange()
  	{
		if((_gameControllerScript.CommanderSelectName1 != "" && _gameControllerScript.CommanderSelectName1 == this.name)||(_gameControllerScript.CommanderSelectName2 != "" && _gameControllerScript.CommanderSelectName2 == this.name))
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
		else
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

  	}
//	void OnTriggerEnter(Collider other) 
//	{
//		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit)
//		{
//			if(other.gameObject.tag=="EmenyCharacter")
//			{
//				Destroy(other.gameObject);
//			}
//		}
//	}
	public void attack()
	{
		//			showingMovementRange = true;
		//			_gameController.GetComponent<GameController>().pieceSelected = true;
		//			_gameController.GetComponent<GameController>().selectedUnit = unitName;
		//			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
		//			showMovementRange();
		//			GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
		if(this.gameObject.name == "Soldier1" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1" &&showingMovementRange == false)
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.Soldier1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Soldier2"  && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Soldier2IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Soldier3" && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3" &&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Soldier3IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "Soldier4"  && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.Soldier4IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}

		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
	}
	public void see()
	{
		GetComponentInChildren<TextMesh>().text = unitName;
		if(_gameControllerScript.Soldier1IsCover && this.gameObject.name == "Soldier1")
		{
			_gameControllerScript.Soldier1IsCover = false;
		}
		if(_gameControllerScript.Soldier2IsCover && this.gameObject.name == "Soldier2")
		{
			_gameControllerScript.Soldier2IsCover = false;
		}
		if(_gameControllerScript.Soldier3IsCover && this.gameObject.name == "Soldier3")
		{
			_gameControllerScript.Soldier3IsCover = false;
		}
		if(_gameControllerScript.Soldier4IsCover && this.gameObject.name == "Soldier4")
		{
			_gameControllerScript.Soldier4IsCover = false;
		}
		panel.SetActive(false);
		_gameController.GetComponent<GameController>().selectedUnit = "";
		_gameController.GetComponent<GameController>().pieceSelected = false;
		this.gameObject.GetComponent<MeshRenderer>().enabled = false;
		this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
		StartCoroutine(waitParticle());
		if(twicestep>0)
		{
			twicestep--;
		}
		if(twicestep<=0 && twicestepTurnOn)
		{
			_gameControllerScript.SideEnd = true;
			twicestepTurnOn = false;
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
		if(!GameObject.Find("myinceasecard3") && !twicestepTurnOn)
		{
			_gameControllerScript.SideEnd = true;
		}
//		_gameControllerScript.SideEnd = true;
	}
	public void cannel()
	{
		if(this.gameObject.name == "Soldier1" && _gameControllerScript.Soldier1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
		{

			GetComponentInChildren<TextMesh>().text = "Soldier1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Soldier2"  && _gameControllerScript.Soldier2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
		{
			GetComponentInChildren<TextMesh>().text = "Soldier2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Soldier3" && _gameControllerScript.Soldier3IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
		{

			GetComponentInChildren<TextMesh>().text = "Soldier3\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Soldier4"  && _gameControllerScript.Soldier4IsCover && _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
		{
			GetComponentInChildren<TextMesh>().text = "Soldier4\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "Soldier1" && !_gameControllerScript.Soldier1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "Soldier1")
		{

			GetComponentInChildren<TextMesh>().text = "Soldier1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Soldier2"  &&!_gameControllerScript.Soldier2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Soldier2")
		{
			GetComponentInChildren<TextMesh>().text = "Soldier2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "Soldier3" && !_gameControllerScript.Soldier3IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "Soldier3")
		{

			GetComponentInChildren<TextMesh>().text = "Soldier3";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "Soldier4"  &&!_gameControllerScript.Soldier4IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "Soldier4")
		{
			GetComponentInChildren<TextMesh>().text = "Soldier4";
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
		this.transform.Find("Human_MasterRig").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
	IEnumerator waitAttackThenWalk()
	{
		Iswalk = false;
		yield return new WaitForSeconds(2f);
		Iswalk = true;
		iTween.MoveTo(this.transform.gameObject,iTween.Hash("position",newpos,"speed",4f,"easetype","linear","oncomplete","checkPostion","oncompletetarget",this.gameObject));
//		yield return new WaitForSeconds(1f);
//		ani.SetFloat("Speed",0,0.1f,Time.deltaTime);
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
		if(_gameControllerScript.TheTwiceStepSoldierName == this.name)
		{
			if(twicestep>0)
			{
				twicestep--;
			}
			if(twicestep<=0 && twicestepTurnOn)
			{
				_gameControllerScript.SideEnd = true;
				twicestepTurnOn = false;
			}
		}
		else
		{
			_gameControllerScript.SideEnd = true;
		}
	}
}
