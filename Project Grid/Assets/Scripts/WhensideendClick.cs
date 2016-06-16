using UnityEngine;
using System.Collections;

public class WhensideendClick : MonoBehaviour {

	private GameObject _gameController;

	public GameObject Archer1;
	public GameObject Archer2;
	public GameObject Knight1;
	public GameObject Knight2;
	public GameObject Soldier1;
	public GameObject Soldier2;
	public GameObject Soldier3;
	public GameObject Soldier4;
	public GameObject Assassin1;
	public GameObject Assassin2;
	public GameObject Warrior1;
	public GameObject Warrior2;
	public GameObject Summoner1;
	public GameObject Hero1;
	public GameObject Priest1;
	public GameObject Priest2;
	//敵人
	public GameObject EArcher1;
	public GameObject EArcher2;
	public GameObject EKnight1;
	public GameObject EKnight2;
	public GameObject ESoldier1;
	public GameObject ESoldier2;
	public GameObject ESoldier3;
	public GameObject ESoldier4;
	public GameObject EAssassin1;
	public GameObject EAssassin2;
	public GameObject EWarrior1;
	public GameObject EWarrior2;
	public GameObject ESummoner1;
	public GameObject EHero1;
	public GameObject EPriest1;
	public GameObject EPriest2;
	// Use this for initialization
	void Start(){
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
	}
	void OnClick(){
		_gameController.GetComponent<GameController>().SideEnd = false;
		_gameController.GetComponent<GameController>().PlayerSide++;
		_gameController.GetComponent<GameController>().selectedUnit = "";
		_gameController.GetComponent<GameController>().pieceSelected = false;
		_gameController.GetComponent<GameController>().TheTwiceStepSoldierName = "";
		_gameController.GetComponent<GameController>().TwoKnivesBatterName = "";
		if(GameObject.Find("myinceasecard4"))
		{
			if(GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed)
			{
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
				GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
		for(int i = 1 ; i<5 ;i++)
		{
			if(GameObject.Find("Soldier"+i))
			{
				GameObject.Find("Soldier"+i).GetComponent<Soldier>().twicestep = 0;
				GameObject.Find("Soldier"+i).GetComponent<Soldier>().twicestepTurnOn = false;
			}
		}
		for(int i = 1 ; i<3 ;i++)
		{
			if(GameObject.Find("Warrior"+i))
			{
				GameObject.Find("Warrior"+i).GetComponent<warrior>().twiceAttackCount = 0;
				GameObject.Find("Warrior"+i).GetComponent<warrior>().twiceAttackTrunOn = false;
				GameObject.Find("Warrior"+i).GetComponent<warrior>().SacrificeHitCount = 0;
				GameObject.Find("Warrior"+i).GetComponent<warrior>().SacrificeHitTrunOn = false;
			}
		}
		if(GameObject.Find("myinceasecard10"))
		{
			if(GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlCount>0)
			{
				GameObject.Find("myinceasecard10").GetComponent<InceaseCard>().MindControlSelect = false;
				GameObject.Find("myinceasecard10").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard10").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
		if(GameObject.Find("myinceasecard11"))
		{
			if(GameObject.Find("myinceasecard11").GetComponent<InceaseCard>().PerceptionProphecyCount>0)
			{
				_gameController.GetComponent<GameController>().MindControlTurnOn = false;
				GameObject.Find("myinceasecard11").GetComponent<InceaseCard>().PerceptionProphecySelect = false;
				GameObject.Find("myinceasecard11").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard11").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
		if(GameObject.Find("myinceasecard14"))
		{
			if(GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().CommanderCount>0)
			{
				_gameController.GetComponent<GameController>().CommanderSelectTurnOn = false;
				GameObject.Find("myinceasecard14").GetComponent<InceaseCard>().CommanderSelect = false;
				GameObject.Find("myinceasecard14").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard14").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,255/255f);
			}
		}
		if(_gameController.GetComponent<GameController>().SacrificeHitSelectName!="")
		{
			GameObject.Find(_gameController.GetComponent<GameController>().SacrificeHitSelectName).SetActive(false);
			_gameController.GetComponent<GameController>().SacrificeHitSelectName = "";
		}
		if(GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit))
		{
			switch(_gameController.GetComponent<GameController>().PreSelectedUnit)
			{
			case "Archer1":
				if(_gameController.GetComponent<GameController>().Archer1IsCover)
					Archer1.GetComponentInChildren<TextMesh>().text = "Archer1\n(cover)";
				else
					Archer1.GetComponentInChildren<TextMesh>().text = "Archer1";
				break;
			case "Archer2":
				if(_gameController.GetComponent<GameController>().Archer1IsCover)
					Archer2.GetComponentInChildren<TextMesh>().text = "Archer2\n(cover)";
				else
					Archer2.GetComponentInChildren<TextMesh>().text = "Archer2";
				break;
			case "Knight1":
				if(_gameController.GetComponent<GameController>().Knight1IsCover)
					Knight1.GetComponentInChildren<TextMesh>().text = "Knight1\n(cover)";
				else
					Knight1.GetComponentInChildren<TextMesh>().text = "Knight1";
				break;
			case "Knight2":
				if(_gameController.GetComponent<GameController>().Knight2IsCover)
					Knight2.GetComponentInChildren<TextMesh>().text = "Knight2\n(cover)";
				else
					Knight2.GetComponentInChildren<TextMesh>().text = "Knight2";
				break;
			case "Soldier1":
				if(_gameController.GetComponent<GameController>().Soldier1IsCover)
					Soldier1.GetComponentInChildren<TextMesh>().text = "Soldier1\n(cover)";
				else
					Soldier1.GetComponentInChildren<TextMesh>().text = "Soldier1";
				break;
			case "Soldier2":
				if(_gameController.GetComponent<GameController>().Soldier2IsCover)
					Soldier2.GetComponentInChildren<TextMesh>().text = "Soldier2\n(cover)";
				else
					Soldier2.GetComponentInChildren<TextMesh>().text = "Soldier2";
				break;
			case "Soldier3":
				if(_gameController.GetComponent<GameController>().Soldier3IsCover)
					Soldier3.GetComponentInChildren<TextMesh>().text = "Soldier3\n(cover)";
				else
					Soldier3.GetComponentInChildren<TextMesh>().text = "Soldier3";
				break;
			case "Soldier4":
				if(_gameController.GetComponent<GameController>().Soldier4IsCover)
					Soldier4.GetComponentInChildren<TextMesh>().text = "Soldier4\n(cover)";
				else
					Soldier4.GetComponentInChildren<TextMesh>().text = "Soldier4";
				break;
			case "Assassin1":
				if(_gameController.GetComponent<GameController>().Assassin1IsCover)
					Assassin1.GetComponentInChildren<TextMesh>().text = "Assassin1\n(cover)";
				else
					Assassin1.GetComponentInChildren<TextMesh>().text = "Assassin1";
				break;
			case "Assassin2":
				if(_gameController.GetComponent<GameController>().Assassin2IsCover)
					Assassin2.GetComponentInChildren<TextMesh>().text = "Assassin2\n(cover)";
				else
					Assassin2.GetComponentInChildren<TextMesh>().text = "Assassin2";
				break;
			case "Warrior1":
				if(_gameController.GetComponent<GameController>().Warrior1IsCover)
					Warrior1.GetComponentInChildren<TextMesh>().text = "Warrior1\n(cover)";
				else
					Warrior1.GetComponentInChildren<TextMesh>().text = "Warrior1";
				break;
			case "Warrior2":
				if(_gameController.GetComponent<GameController>().Warrior2IsCover)
					Warrior2.GetComponentInChildren<TextMesh>().text = "Warrior2\n(cover)";
				else
					Warrior2.GetComponentInChildren<TextMesh>().text = "Warrior2";
				break;
			case "Summoner1":
				if(_gameController.GetComponent<GameController>().SummnonerIsCover)
					Summoner1.GetComponentInChildren<TextMesh>().text = "Summoner1\n(cover)";
				else
					Summoner1.GetComponentInChildren<TextMesh>().text = "Summoner1";
				break;
			case "Hero1":
				if(_gameController.GetComponent<GameController>().HeroIsCover)
					Hero1.GetComponentInChildren<TextMesh>().text = "Hero1\n(cover)";
				else
					Hero1.GetComponentInChildren<TextMesh>().text = "Hero1";
				break;
			case "Priest1":
				if(_gameController.GetComponent<GameController>().Priest1IsCover)
					Priest1.GetComponentInChildren<TextMesh>().text = "Priest1\n(cover)";
				else
					Priest1.GetComponentInChildren<TextMesh>().text = "Priest1";
				break;
			case "Priest2":
				if(_gameController.GetComponent<GameController>().Priest2IsCover)
					Priest2.GetComponentInChildren<TextMesh>().text = "Priest2\n(cover)";
				else
					Priest2.GetComponentInChildren<TextMesh>().text = "Priest2";
				break;
				//			//另一方
			case "EArcher1":
				if(_gameController.GetComponent<GameController>().EArcher1IsCover)
					EArcher1.GetComponentInChildren<TextMesh>().text = "EArcher1\n(cover)";
				else
					EArcher1.GetComponentInChildren<TextMesh>().text = "EArcher1";
				break;
			case "EArcher2":
				if(_gameController.GetComponent<GameController>().EArcher2IsCover)
					EArcher2.GetComponentInChildren<TextMesh>().text = "EArcher2\n(cover)";
				else
					EArcher2.GetComponentInChildren<TextMesh>().text = "EArcher2";
				break;
			case "EKnight1":
				if(_gameController.GetComponent<GameController>().EKnight1IsCover)
					EKnight1.GetComponentInChildren<TextMesh>().text = "EKnight1\n(cover)";
				else
					EKnight1.GetComponentInChildren<TextMesh>().text = "EKnight1";
				break;
			case "EKnight2":
				if(_gameController.GetComponent<GameController>().EKnight2IsCover)
					EKnight2.GetComponentInChildren<TextMesh>().text = "EKnight2\n(cover)";
				else
					EKnight2.GetComponentInChildren<TextMesh>().text = "EKnight2";
				break;
			case "ESoldier1":
				if(_gameController.GetComponent<GameController>().ESoldier1IsCover)
					ESoldier1.GetComponentInChildren<TextMesh>().text = "ESoldier1\n(cover)";
				else
					ESoldier1.GetComponentInChildren<TextMesh>().text = "ESoldier1";
				break;
			case "ESoldier2":
				if(_gameController.GetComponent<GameController>().ESoldier2IsCover)
					ESoldier2.GetComponentInChildren<TextMesh>().text = "ESoldier2\n(cover)";
				else
					ESoldier2.GetComponentInChildren<TextMesh>().text = "ESoldier2";
				break;
			case "ESoldier3":
				if(_gameController.GetComponent<GameController>().ESoldier3IsCover)
					ESoldier3.GetComponentInChildren<TextMesh>().text = "ESoldier3\n(cover)";
				else
					ESoldier3.GetComponentInChildren<TextMesh>().text = "ESoldier3";
				break;
			case "ESoldier4":
				if(_gameController.GetComponent<GameController>().ESoldier4IsCover)
					ESoldier4.GetComponentInChildren<TextMesh>().text = "ESoldier4\n(cover)";
				else
					ESoldier4.GetComponentInChildren<TextMesh>().text = "ESoldier4";
				break;
			case "EAssassin1":
				if(_gameController.GetComponent<GameController>().EAssassin1IsCover)
					EAssassin1.GetComponentInChildren<TextMesh>().text = "EAssassin1\n(cover)";
				else
					EAssassin1.GetComponentInChildren<TextMesh>().text = "EAssassin1";
				break;
			case "EAssassin2":
				if(_gameController.GetComponent<GameController>().EAssassin2IsCover)
					EAssassin2.GetComponentInChildren<TextMesh>().text = "EAssassin2\n(cover)";
				else
					EAssassin2.GetComponentInChildren<TextMesh>().text = "EAssassin2";
				break;
			case "EWarrior1":
				if(_gameController.GetComponent<GameController>().EWarrior1IsCover)
					EWarrior1.GetComponentInChildren<TextMesh>().text = "EWarrior1\n(cover)";
				else
					EWarrior1.GetComponentInChildren<TextMesh>().text = "EWarrior1";
				break;
			case "EWarrior2":
				if(_gameController.GetComponent<GameController>().EWarrior2IsCover)
					EWarrior2.GetComponentInChildren<TextMesh>().text = "EWarrior2\n(cover)";
				else
					EWarrior2.GetComponentInChildren<TextMesh>().text = "EWarrior2";
				break;
			case "ESummoner1":
				if(_gameController.GetComponent<GameController>().ESummnonerIsCover)
					ESummoner1.GetComponentInChildren<TextMesh>().text = "ESummoner1\n(cover)";
				else
					ESummoner1.GetComponentInChildren<TextMesh>().text = "ESummoner1";
				break;
			case "EHero1":
				if(_gameController.GetComponent<GameController>().EHeroIsCover)
					EHero1.GetComponentInChildren<TextMesh>().text = "EHero1\n(cover)";
				else
					EHero1.GetComponentInChildren<TextMesh>().text = "EHero1";
				break;
			case "EPriest1":
				if(_gameController.GetComponent<GameController>().EPriest1IsCover)
					EPriest1.GetComponentInChildren<TextMesh>().text = "EPriest1\n(cover)";
				else
					EPriest1.GetComponentInChildren<TextMesh>().text = "EPriest1";
				break;
			case "EPriest2":
				if(_gameController.GetComponent<GameController>().EPriest2IsCover)
					EPriest2.GetComponentInChildren<TextMesh>().text = "EPriest2\n(cover)";
				else
					EPriest2.GetComponentInChildren<TextMesh>().text = "EPriest2";
				break;
			}
		}
	}
}
