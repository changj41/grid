using UnityEngine;
using System.Collections;

public class WhenSeeClick : MonoBehaviour {

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
		switch(_gameController.GetComponent<GameController>().selectedUnit)
		{
		case "Archer1":
			Archer1.GetComponent<Archer>().see();
			break;
		case "Archer2":
			Archer2.GetComponent<Archer>().see();
			break;
		case "Knight1":
			Knight1.GetComponent<Knight>().see();
			break;
		case "Knight2":
			Knight2.GetComponent<Knight>().see();
			break;
		case "Soldier1":
			Soldier1.GetComponent<Soldier>().see();
			break;
		case "Soldier2":
			Soldier2.GetComponent<Soldier>().see();
			break;
		case "Soldier3":
			Soldier3.GetComponent<Soldier>().see();
			break;
		case "Soldier4":
			Soldier4.GetComponent<Soldier>().see();
			break;
		case "Assassin1":
			Assassin1.GetComponent<Assassin>().see();
			break;
		case "Assassin2":
			Assassin2.GetComponent<Assassin>().see();
			break;
		case "Warrior1":
			Warrior1.GetComponent<warrior>().see();
			break;
		case "Warrior2":
			Warrior2.GetComponent<warrior>().see();
			break;
		case "Summoner1":
			Summoner1.GetComponent<Summoner>().see();
			break;
		case "Hero1":
			Hero1.GetComponent<Hero>().see();
			break;
		case "Priest1":
			Priest1.GetComponent<Priest>().see();
			break;
		case "Priest2":
			Priest2.GetComponent<Priest>().see();
			break;
//			//另一方
		case "EArcher1":
			EArcher1.GetComponent<EArcher>().see();
			break;
		case "EArcher2":
			EArcher2.GetComponent<EArcher>().see();
			break;
		case "EKnight1":
			EKnight1.GetComponent<EKnight>().see();
			break;
		case "EKnight2":
			EKnight2.GetComponent<EKnight>().see();
			break;
		case "ESoldier1":
			ESoldier1.GetComponent<ESoldier>().see();
			break;
		case "ESoldier2":
			ESoldier2.GetComponent<ESoldier>().see();
			break;
		case "ESoldier3":
			ESoldier3.GetComponent<ESoldier>().see();
			break;
		case "ESoldier4":
			ESoldier4.GetComponent<ESoldier>().see();
			break;
		case "EAssassin1":
			EAssassin1.GetComponent<EAssassin>().see();
			break;
		case "EAssassin2":
			EAssassin2.GetComponent<EAssassin>().see();
			break;
		case "EWarrior1":
			EWarrior1.GetComponent<Ewarrior>().see();
			break;
		case "EWarrior2":
			EWarrior2.GetComponent<Ewarrior>().see();
			break;
		case "ESummoner1":
			ESummoner1.GetComponent<ESummoner>().see();
			break;
		case "EHero1":
			EHero1.GetComponent<EHero>().see();
			break;
		case "EPriest1":
			EPriest1.GetComponent<EPriest>().see();
			break;
		case "EPriest2":
			EPriest2.GetComponent<EPriest>().see();
			break;
		}
	}
}
