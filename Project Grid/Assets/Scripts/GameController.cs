using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  	private InputManager _inputManager;
  	private GameObject _camera;
	ScreenInput input;

  	private bool turnBeginPhase;
  	private bool characterSelectPhase;
  	private bool movementPhase;
  	private bool attackPhase;

  	public bool pieceSelected;
	public string selectedUnit;
	public string PreSelectedUnit;
//	己方
	public bool Soldier1IsCover;
	public bool Soldier2IsCover;
	public bool Soldier3IsCover;
	public bool Soldier4IsCover;
	public bool Assassin1IsCover;
	public bool Assassin2IsCover;
	public bool Knight1IsCover;
	public bool Knight2IsCover;
	public bool Archer1IsCover;
	public bool Archer2IsCover;
	public bool SummnonerIsCover;
	public bool HeroIsCover;
	public bool Warrior1IsCover;
	public bool Warrior2IsCover;
	public bool Priest1IsCover;
	public bool Priest2IsCover;
//敵人
	public bool ESoldier1IsCover;
	public bool ESoldier2IsCover;
	public bool ESoldier3IsCover;
	public bool ESoldier4IsCover;
	public bool EAssassin1IsCover;
	public bool EAssassin2IsCover;
	public bool EKnight1IsCover;
	public bool EKnight2IsCover;
	public bool EArcher1IsCover;
	public bool EArcher2IsCover;
	public bool ESummnonerIsCover;
	public bool EHeroIsCover;
	public bool EWarrior1IsCover;
	public bool EWarrior2IsCover;
	public bool EPriest1IsCover;
	public bool EPriest2IsCover;
	public string AttackedGridName;
	public string AttackedGriNamedTag;
//	死亡
	public bool Soldier1IsDead;
	public bool Soldier2IsDead;
	public bool Soldier3IsDead;
	public bool Soldier4IsDead;
	public bool Assassin1IsDead;
	public bool Assassin2IsDead;
	public bool Knight1IsDead;
	public bool Knight2IsDead;
	public bool Archer1IsDead;
	public bool Archer2IsDead;
	public bool SummnonerIsDead;
	public bool HeroIsDead;
	public bool Warrior1IsDead;
	public bool Warrior2IsDead;
	public bool Priest1IsDead;
	public bool Priest2IsDead;
//	敵方死亡
	public bool ESoldier1IsDead;
	public bool ESoldier2IsDead;
	public bool ESoldier3IsDead;
	public bool ESoldier4IsDead;
	public bool EAssassin1IsDead;
	public bool EAssassin2IsDead;
	public bool EKnight1IsDead;
	public bool EKnight2IsDead;
	public bool EArcher1IsDead;
	public bool EArcher2IsDead;
	public bool ESummnonerIsDead;
	public bool EHeroIsDead;
	public bool EWarrior1IsDead;
	public bool EWarrior2IsDead;
	public bool EPriest1IsDead;
	public bool EPriest2IsDead;
	public int PlayerSide;
	public string SacrificeHitSelectName;
	public string TwoKnivesBatterName;
	public bool MindControlTurnOn;
	public bool PerceptionProphecySelectTrunOn;
	public bool CommanderSelectTurnOn;
	public bool TheSoulPursueAndAttackSelectTurnOn;
	public string CommanderSelectName1;
	public string CommanderSelectName2;
	public bool PioneersUsedTurnOn;
	public bool SunderUsedTurnOn;
	public bool intuitionSelectTurnOn;
	public GameObject panel;
  	//Temp
  	private GameObject summoner;
  	private GameObject hero;
	public string TheTwiceStepSoldierName;
	public bool SideEnd;

  	void Start ()
  	{
		MindControlTurnOn = false;
		PerceptionProphecySelectTrunOn = false;
		intuitionSelectTurnOn = false;
		PlayerSide = 0;
    	_inputManager = new InputManager();
		_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    	pieceSelected = false;
    	turnBeginPhase = false;
    	characterSelectPhase = false;
    	movementPhase = false;

    	//Temp
    	summoner = GameObject.Find("Summoner");
    	hero = GameObject.Find("Hero");
		LoadPositionSet();
		if(GameObject.Find("myinceasecard1"))
		{
			GameObject.Find("myinceasecard1").GetComponent<InceaseCard>().KingWithoutfearUsed = true;
			GameObject.Find("myinceasecard1").GetComponent<UIButton>().defaultColor = new Color(225/255f,200/255f,150/255f,255/255f);
		}
		if(GameObject.Find("myinceasecard4"))
		{
			GameObject.Find("myinceasecard4").GetComponent<UIButton>().enabled = false;
		}
		if(GameObject.Find("myinceasecard6"))
		{
			GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed = true;
			GameObject.Find("myinceasecard6").GetComponent<UIButton>().defaultColor = new Color(225/255f,200/255f,150/255f,255/255f);
		}
		if(GameObject.Find("myinceasecard7"))
		{
			GameObject.Find("myinceasecard7").GetComponent<UIButton>().enabled = false;
		}
		if(GameObject.Find("myinceasecard12"))
		{
			GameObject.Find("myinceasecard12").GetComponent<InceaseCard>().SoulLinkUsed = true;
			GameObject.Find("myinceasecard12").GetComponent<UIButton>().defaultColor = new Color(225/255f,200/255f,150/255f,255/255f);
		}
		if(GameObject.Find("myinceasecard15"))
		{
			GameObject.Find("myinceasecard15").GetComponent<InceaseCard>().PioneersUsed = true;
			PioneersUsedTurnOn = true;
			GameObject.Find("myinceasecard15").GetComponent<UIButton>().defaultColor = new Color(225/255f,200/255f,150/255f,255/255f);
		}
	}
	
	float timer_f;
	int timer_i;
	void Update ()
  	{
		timer_f = Time.time;
		timer_i = Mathf.FloorToInt(timer_f);
		GameObject.Find("Second").GetComponent<UILabel>().text = timer_i+"";
		if(_inputManager != null)
		{
    		input = _inputManager.GetInput();
		}
    	if(input != null)
    	{
      		Ray ray = new Ray(_camera.transform.position, input.inputPoint - _camera.transform.position);
      		RaycastHit[] hits = Physics.RaycastAll(ray, Constants.Board.raycastLength);
    	}
	}
	void LoadPositionSet ()
	{
		string name;
		for(int i = 1 ; i <= 16 ; i++)
		{
			
			name = PlayerPrefs.GetString("UI1000_Title_1_Icon_BackGround_"+ i + "PageA");
			print(name);
			LoadCharacterDecide("UI1000_Title_1_Icon_BackGround_"+i,name);
		}
	}
	int a = 1,b = 1,c = 1,d = 1,e = 1,f = 1,g = 1,h = 1;
	void LoadCharacterDecide(string boxname,string CharacterName)
	{
		if(boxname == "UI1000_Title_1_Icon_BackGround_1")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,7f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,7f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,7f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,7f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,7f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,7f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,7f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,7f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_2")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,6f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,6f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,6f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,6f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,6f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,6f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,6f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,6f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_3")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,5f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,5f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,5f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,5f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,5f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,5f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,5f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,5f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_4")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,4f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,4f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,4f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,4f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,4f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,4f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,4f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,4f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_5")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,3f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,3f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,3f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,3f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,3f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,3f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,3f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,3f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_6")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,2f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,2f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,2f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,2f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,2f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,2f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,2f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,2f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_7")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,1f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,1f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,1f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,1f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,1f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,1f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,1f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,1f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_8")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,0f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,0f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,0f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,0f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,0f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,0f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,0f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,0f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_9")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,7f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,7f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,7f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,7f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,7f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,7f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,7f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,7f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_10")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,6f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,6f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,6f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,6f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,6f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,6f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,6f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,6f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_11")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,5f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,5f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,5f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,5f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,5f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,5f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,5f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,5f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_12")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,4f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,4f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,4f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,4f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,4f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,4f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,4f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,4f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_13")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,3f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,3f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,3f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,3f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,3f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,3f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,3f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,3f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_14")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,2f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,2f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,2f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,2f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,2f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,2f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,2f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,2f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_15")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,1f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,1f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,1f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,1f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,1f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,1f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,1f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,1f);
				h++;
			}
		}
		else if(boxname == "UI1000_Title_1_Icon_BackGround_16")
		{
			if(CharacterName == "UI_1000_Type_Summoner")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,0f);
				a++;
			}
			else if(CharacterName == "UI_1000_Type_Hero")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,0f);
				b++;
			}
			else if(CharacterName == "UI_1000_Type_Worrier")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,0f);
				c++;
			}
			else if(CharacterName == "UI_1000_Type_Pastor")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,0f);
				d++;
			}
			else if(CharacterName == "UI_1000_Type_Knight")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,0f);
				e++;
			}
			else if(CharacterName == "UI_1000_Type_Assassin")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,0f);
				f++;
			}
			else if(CharacterName == "UI_1000_Type_Archer")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,0f);
				g++;
			}
			else if(CharacterName == "UI_1000_Type_Soldier")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,0f);
				h++;
			}
		}
	}
}

