using UnityEngine;
using System.Collections;

public class RedGridCheck : MonoBehaviour {
	string ColliderGameobjectName;
	// Use this for initialization
	private GameObject _gameController;
	private GameController  _gameControllerScript;
	void Start () {
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider other) {
		ColliderGameobjectName = other.gameObject.name;
		string SelectName = _gameController.GetComponent<GameController>().selectedUnit;
		if((ColliderGameobjectName == "Assassin1"&&_gameController.GetComponent<GameController>().Assassin1IsCover)
			||(ColliderGameobjectName == "Assassin2"&&_gameController.GetComponent<GameController>().Assassin2IsCover))
		{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
		}
		else if((ColliderGameobjectName == "EAssassin1"&&_gameController.GetComponent<GameController>().EAssassin1IsCover)
			||(ColliderGameobjectName == "EAssassin2"&&_gameController.GetComponent<GameController>().EAssassin2IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
		}
		else if((ColliderGameobjectName == "Soldier1"&&_gameController.GetComponent<GameController>().Soldier1IsCover)
			||(ColliderGameobjectName == "Soldier2"&&_gameController.GetComponent<GameController>().Soldier2IsCover)
			||(ColliderGameobjectName == "Soldier3"&&_gameController.GetComponent<GameController>().Soldier3IsCover)
			||(ColliderGameobjectName == "Soldier4"&&_gameController.GetComponent<GameController>().Soldier4IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "ESoldier1"&&_gameController.GetComponent<GameController>().ESoldier1IsCover)
			||(ColliderGameobjectName == "ESoldier2"&&_gameController.GetComponent<GameController>().ESoldier2IsCover)
			||(ColliderGameobjectName == "ESoldier3"&&_gameController.GetComponent<GameController>().ESoldier3IsCover)
			||(ColliderGameobjectName == "ESoldier4"&&_gameController.GetComponent<GameController>().ESoldier4IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
		}
		else if((ColliderGameobjectName == "Archer1"&&_gameController.GetComponent<GameController>().Archer1IsCover)
			||(ColliderGameobjectName == "Archer2"&&_gameController.GetComponent<GameController>().Archer2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "EArcher1"&&_gameController.GetComponent<GameController>().EArcher1IsCover)
			||(ColliderGameobjectName == "EArcher2"&&_gameController.GetComponent<GameController>().EArcher2IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
		}
		else if((ColliderGameobjectName == "Summoner1"&& _gameController.GetComponent<GameController>().SummnonerIsCover)
			||(ColliderGameobjectName == "Summoner1"&& GameObject.Find("myinceasecard1")/*.GetComponent<InceaseCard>().KingWithoutfearUsed*/))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")

			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "ESummoner1"&& _gameController.GetComponent<GameController>().ESummnonerIsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")

				{
					Destroy(this.gameObject);
				}
			}
		}
		else if((ColliderGameobjectName == "Hero1"&&_gameController.GetComponent<GameController>().HeroIsCover))
//			||(ColliderGameobjectName == "Hero1"&& GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed))
		{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
		}
		else if((ColliderGameobjectName == "EHero1"&&_gameController.GetComponent<GameController>().EHeroIsCover))
			//			||(ColliderGameobjectName == "Hero1"&& GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
		}
		else if((ColliderGameobjectName == "Hero1"&& GameObject.Find("myinceasecard6")))
		{
			if(SelectName == "EArcher1" && _gameControllerScript.EArcher1IsCover)
			{
				Destroy(this.gameObject);
			}
			else if(SelectName == "EArcher2" && _gameControllerScript.EArcher2IsCover)
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Warrior1"&&_gameController.GetComponent<GameController>().Warrior1IsCover)
			||(ColliderGameobjectName == "Warrior2"&&_gameController.GetComponent<GameController>().Warrior2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "EWarrior1"&&_gameController.GetComponent<GameController>().EWarrior1IsCover)
			||(ColliderGameobjectName == "EWarrior2"&&_gameController.GetComponent<GameController>().EWarrior2IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Priest1"&&_gameController.GetComponent<GameController>().Priest1IsCover)
			||(ColliderGameobjectName == "Priest2"&&_gameController.GetComponent<GameController>().Priest2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")

			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "EPriest1"&&_gameController.GetComponent<GameController>().EPriest1IsCover)
			||(ColliderGameobjectName == "EPriest2"&&_gameController.GetComponent<GameController>().EPriest2IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")

				{
					Destroy(this.gameObject);
				}
			}
		}
		else if((ColliderGameobjectName == "Knight1"&&_gameController.GetComponent<GameController>().Knight1IsCover)
			||(ColliderGameobjectName == "Knight2"&&_gameController.GetComponent<GameController>().Knight2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
				||SelectName == "Knight1"||SelectName == "Knight2"
				||SelectName == "Archer1"||SelectName == "Archer2"
				||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
				||SelectName == "EKnight1"||SelectName == "EKnight2"
				||SelectName == "EArcher1"||SelectName == "EArcher2")

			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "EKnight1"&&_gameController.GetComponent<GameController>().EKnight1IsCover)
			||(ColliderGameobjectName == "EKnight2"&&_gameController.GetComponent<GameController>().EKnight2IsCover))
		{
			if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")
				{
					Destroy(this.gameObject);
				}
			}
			else
			{
				if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "Knight1"||SelectName == "Knight2"
					||SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4"
					||SelectName == "EKnight1"||SelectName == "EKnight2"
					||SelectName == "EArcher1"||SelectName == "EArcher2")

				{
					Destroy(this.gameObject);
				}
			}
		}
		else if(ColliderGameobjectName == "Knight1"||ColliderGameobjectName == "Knight2")
		{
			if(!_gameControllerScript.PioneersUsedTurnOn && !_gameControllerScript.SunderUsedTurnOn )
			{
				if(SelectName == "Archer1"||SelectName == "Archer2"
					||SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
					||SelectName == "EArcher1"||SelectName == "EArcher2"
					||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4")
				{
					Destroy(this.gameObject);
				}
			}

		}
		else if(ColliderGameobjectName == "EKnight1"||ColliderGameobjectName == "EKnight2")
		{
			if(!_gameControllerScript.PioneersUsedTurnOn && !_gameControllerScript.SunderUsedTurnOn )
			{
				if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
				{
					if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
						||SelectName == "EArcher1"||SelectName == "EArcher2"
						||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4")
					{
						Destroy(this.gameObject);
					}
				}
				else
				{
					if(SelectName == "Archer1"||SelectName == "Archer2"
						||SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"
						||SelectName == "EArcher1"||SelectName == "EArcher2"
						||SelectName == "ESoldier1"||SelectName == "ESoldier2"||SelectName == "ESoldier3"||SelectName =="ESoldier4")
					{
						Destroy(this.gameObject);
					}
				}
			}

		}
		else if(GameObject.Find(ColliderGameobjectName).tag == GameObject.Find(SelectName).tag)
		{
			Destroy(this.gameObject);
		}
	}
}
