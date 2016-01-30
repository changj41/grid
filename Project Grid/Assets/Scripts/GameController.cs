using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  	private InputManager _inputManager;
  	private GameObject _camera;

  	private bool turnBeginPhase;
  	private bool characterSelectPhase;
  	private bool movementPhase;
  	private bool attackPhase;

  	public bool pieceSelected;
	public string selectedUnit;
	public string PreSelectedUnit;

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


  	//Temp
  	private GameObject summoner;
  	private GameObject hero;

  	void Start ()
  	{
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
	}
	

	void Update ()
  	{
    	ScreenInput input = _inputManager.GetInput();
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
			
			name = PlayerPrefs.GetString("UiRight2_3_"+ i + "PageA");
			print(name);
			LoadCharacterDecide("UiRight2_3_"+i,name);
		}
	}
	int a = 1,b = 1,c = 1,d = 1,e = 1,f = 1,g = 1,h = 1;
	void LoadCharacterDecide(string boxname,string CharacterName)
	{
		if(boxname == "UiRight2_3_1")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				print("Summoner"+a);
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,7f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,7f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,7f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,7f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,7f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,7f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,7f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,7f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_2")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,6f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,6f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,6f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,6f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,6f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,6f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,6f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,6f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_3")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,5f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,5f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,5f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,5f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,5f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,5f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,5f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,5f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_4")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,4f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,4f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,4f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,4f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,4f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,4f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,4f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,4f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_5")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,3f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,3f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,3f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,3f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,3f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,3f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,3f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,3f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_6")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,2f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,2f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,2f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,2f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,2f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,2f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,2f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,2f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_7")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,1f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,1f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,1f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,1f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,1f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,1f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,1f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,1f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_8")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(1f,0.2f,0f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(1f,0.2f,0f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(1f,0.2f,0f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(1f,0.2f,0f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(1f,0.2f,0f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(1f,0.2f,0f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(1f,0.2f,0f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(1f,0.2f,0f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_9")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,7f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,7f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,7f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,7f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,7f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,7f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,7f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,7f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_10")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,6f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,6f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,6f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,6f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,6f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,6f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,6f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,6f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_11")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,5f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,5f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,5f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,5f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,5f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,5f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,5f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,5f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_12")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,4f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,4f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,4f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,4f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,4f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,4f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,4f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,4f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_13")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,3f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,3f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,3f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,3f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,3f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,3f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,3f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,3f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_14")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,2f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,2f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,2f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,2f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,2f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,2f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,2f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,2f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_15")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,1f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,1f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,1f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,1f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,1f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,1f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,1f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,1f);
				h++;
			}
		}
		else if(boxname == "UiRight2_3_16")
		{
			if(CharacterName == "World_RoseOfWinds")
			{
				GameObject.Find("Summoner"+a).transform.position = new Vector3(0f,0.2f,0f);
				a++;
			}
			else if(CharacterName == "crossed-swords")
			{
				GameObject.Find("Hero"+b).transform.position = new Vector3(0f,0.2f,0f);
				b++;
			}
			else if(CharacterName == "broadsword")
			{
				GameObject.Find("Warrior"+c).transform.position = new Vector3(0f,0.2f,0f);
				c++;
			}
			else if(CharacterName == "orb-wand")
			{
				GameObject.Find("Priest"+d).transform.position = new Vector3(0f,0.2f,0f);
				d++;
			}
			else if(CharacterName == "spear-feather")
			{
				GameObject.Find("Knight"+e).transform.position = new Vector3(0f,0.2f,0f);
				e++;
			}
			else if(CharacterName == "plain-dagger")
			{
				GameObject.Find("Assassin"+f).transform.position = new Vector3(0f,0.2f,0f);
				f++;
			}
			else if(CharacterName == "high-shot")
			{
				GameObject.Find("Archer"+g).transform.position = new Vector3(0f,0.2f,0f);
				g++;
			}
			else if(CharacterName == "round-shield")
			{
				GameObject.Find("Soldier"+h).transform.position = new Vector3(0f,0.2f,0f);
				h++;
			}
		}
	}
}

