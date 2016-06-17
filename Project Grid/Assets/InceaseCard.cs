using UnityEngine;
using System.Collections;

public class InceaseCard : MonoBehaviour {

	public bool MagicWatchSelect = false;
	public bool MagicWatchUsed = false;
	public bool KingWithoutfearUsed = false;
	public bool TheItalianJobSelect = false;
	public bool TheItalianJobUsed = false;
	public bool BigDecreeSelect = false;
	public bool BigDecreeUsed = false;
	public int BigDecreeCount = 2;
	public bool ChainReactionUsed = false;
	public bool TheForceOfHeroesUsed = false;
	public bool TheSoulPursueAndAttackSelect = false;
	public bool TheSoulPursueAndAttackUsed = false;
	public string TheSoulPursueAndAttacSelectName;
	public bool TwoKnivesBatterSelect = false;
	public bool TwoKnivesBatterUsed = false;
	public bool SacrificeHitSelect = false;
	public bool SacrificeHitUsed = false;
	public bool MindControlSelect = false;
	public bool MindControlUse = false;
	public int MindControlSelectStep = 0;
	public int MindControlCount = 0;
	public bool PerceptionProphecySelect = false;
	public bool PerceptionProphecyUse = false;
	public int PerceptionProphecyCount;
	public bool SoulLinkUsed;
	public bool CommanderSelect;
	public bool CommanderUsed;
	public int CommanderCount;
	public bool PioneersUsed;
	public bool SunderSelect;
	public bool SunderUsed;
	public bool BlindfireSelect;
	public bool BlindfireUsed;
	public bool intuitionSelect;
	public int intuitionCount;
	// Use this for initialization
	private GameObject _gameController;
	void Awake(){
//		SelectHeroImage = this.transform.parent.Find("hero0").GetComponent<UISprite>();
//		SelectHeroName = this.transform.parent.Find("hero_name").GetComponent<UILabel>();
	}

	void Start(){
		PerceptionProphecyCount = 2;
		MindControlCount = 2;
		CommanderCount = 2;
		intuitionCount =2;
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
	}

	void OnClick(){
		print(this.name);
		string CardName = this.transform.GetComponent<UILabel>().text;
		if(CardName == "偷天換日" && !TheItalianJobSelect && _gameController.GetComponent<GameController>().AttackedGridName == "Summoner1")
		{
			print("偷天換日use");
			TheItalianJobSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "大號令" && !BigDecreeUsed && _gameController.GetComponent<GameController>().PlayerSide % 2 == 0 && _gameController.GetComponent<GameController>().selectedUnit == "" && BigDecreeSelect == false)
		{
			print("大號令use");
			BigDecreeSelect = true;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			GameObject.Find("myinceasecard3").GetComponent<UIButton>().defaultColor = new Color(225/255f,200/255f,150/255f,255/255f);
		}
		if(CardName == "魔力觀測" && !MagicWatchUsed && _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
		{
			print("魔力觀測use");
			MagicWatchSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(225/255f,255/255f,255/255f,80/255f);
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "連鎖反應" && !ChainReactionUsed )
		{
			print("連鎖反應use");
			MagicWatchSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "亡靈追擊" && !TheSoulPursueAndAttackUsed &&  _gameController.GetComponent<GameController>().PlayerSide % 2 == 0)
		{
			print("亡靈追擊USE");
			TheSoulPursueAndAttackSelect = true;
			_gameController.GetComponent<GameController>().TheSoulPursueAndAttackSelectTurnOn = true;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
		}
		if(CardName == "二刀連擊" && !TwoKnivesBatterUsed)
		{
			_gameController.GetComponent<GameController>().TwoKnivesBatterName= _gameController.GetComponent<GameController>().PreSelectedUnit;
			GameObject.Find("myinceasecard8").GetComponent<InceaseCard>().TwoKnivesBatterUsed = true;
			GameObject.Find("myinceasecard8").GetComponent<TweenAlpha>().enabled = false;
			GameObject.Find("myinceasecard8").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
			GameObject.Find("myinceasecard8").GetComponent<BoxCollider>().enabled = false;
			if(_gameController.GetComponent<GameController>().TwoKnivesBatterName =="Warrior1")
			{
				_gameController.GetComponent<GameController>().SideEnd = false;
				GameObject.Find("Warrior1").GetComponent<warrior>().twiceAttackCount = 1;
				GameObject.Find("Warrior1").GetComponent<warrior>().twiceAttackTrunOn = true;
			}
			if(_gameController.GetComponent<GameController>().TwoKnivesBatterName =="Warrior2")
			{
				_gameController.GetComponent<GameController>().SideEnd = false;
				GameObject.Find("Warrior2").GetComponent<warrior>().twiceAttackCount = 1;
				GameObject.Find("Warrior2").GetComponent<warrior>().twiceAttackTrunOn = true;
			}
			print("二刀連擊USE");
			TwoKnivesBatterSelect = true;
		}
		if(CardName == "犧牲打擊" && !SacrificeHitUsed)
		{
			
			print("犧牲打擊");
			SacrificeHitSelect = true;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
		}
		if(CardName == "破甲" && !SunderSelect)
		{

			print("破甲");
			_gameController.GetComponent<GameController>().SunderUsedTurnOn = true;
			SunderSelect = true;
			GameObject.Find("myinceasecard19").GetComponent<UIButton>().defaultColor = new Color(255/255f,0/255f,0/255f,255/255f);
		}
		if(CardName == "盲射" && !BlindfireUsed)
		{

			print("盲射");
			BlindfireSelect = true;
			GameObject.Find("myinceasecard20").GetComponent<UIButton>().defaultColor = new Color(255/255f,0/255f,0/255f,255/255f);
		}
	}
}