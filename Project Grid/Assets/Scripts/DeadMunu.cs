using UnityEngine;
using System.Collections;

public class DeadMunu : MonoBehaviour {

	public GameObject DeadMenu;
	GameController _GamecontrolScript;
	string SummonerLabel;
	string HeroLabel;
	string KnightLabel;
	string WarriorLabel;
	string AssassinLabel;
	string PriestLabel;
	string ArcherLabel;
	string SoldierLabel;
	// Use this for initialization
	void Start () {
		_GamecontrolScript = GameObject.FindGameObjectWithTag(Constants.Tags.GameController).GetComponent<GameController>();
	}
	
	// Update is called once per frame
	public void CloseClick()
	{
		transform.FindChild("Summoner/SummonerLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Hero/HeroLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Knight/KnightLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Warrior/WarriorLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Assassin/AssassinLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Priest/PriestLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Archer/ArcherLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("Soldier/SoldierLabel").GetComponent<UILabel>().text = 0+"";
		this.gameObject.SetActive(false);
	}

	public void DeadButtonClick()
	{
		if(DeadMenu.activeSelf)
		{
			CloseClick();
		}
		else
		{
			DeadMenu.SetActive(true);
			if(_GamecontrolScript.SummnonerIsDead)
			{
				transform.FindChild("Summoner/SummonerLabel").GetComponent<UILabel>().text = 1+"";
			}
			if(_GamecontrolScript.HeroIsDead)
			{
				transform.FindChild("Hero/HeroLabel").GetComponent<UILabel>().text = 1+"";
			}
			if(_GamecontrolScript.Knight1IsDead || _GamecontrolScript.Knight2IsDead)
			{
				if(_GamecontrolScript.Knight1IsDead && _GamecontrolScript.Knight2IsDead)
				{
					transform.FindChild("Knight/KnightLabel").GetComponent<UILabel>().text = 2+"";
				}
				else if(_GamecontrolScript.Knight1IsDead || _GamecontrolScript.Knight2IsDead)
				{
					transform.FindChild("Knight/KnightLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
			if(_GamecontrolScript.Warrior1IsDead || _GamecontrolScript.Warrior2IsDead)
			{
				if(_GamecontrolScript.Warrior1IsDead && _GamecontrolScript.Warrior2IsDead)
				{
					transform.FindChild("Warrior/WarriorLabel").GetComponent<UILabel>().text = 2+"";
				}
				else if(_GamecontrolScript.Warrior1IsDead || _GamecontrolScript.Warrior2IsDead)
				{
					transform.FindChild("Warrior/WarriorLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
			if(_GamecontrolScript.Assassin1IsDead || _GamecontrolScript.Assassin2IsDead)
			{
				if(_GamecontrolScript.Assassin1IsDead && _GamecontrolScript.Assassin2IsDead)
				{
					transform.FindChild("Assassin/AssassinLabel").GetComponent<UILabel>().text = 2+"";
				}
				else if(_GamecontrolScript.Assassin1IsDead || _GamecontrolScript.Assassin2IsDead)
				{
					transform.FindChild("Assassin/AssassinLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
			if(_GamecontrolScript.Priest1IsDead || _GamecontrolScript.Priest2IsDead)
			{
				if(_GamecontrolScript.Priest1IsDead && _GamecontrolScript.Priest2IsDead)
				{
					transform.FindChild("Priest/PriestLabel").GetComponent<UILabel>().text = 2+"";
				}
				else if(_GamecontrolScript.Assassin1IsDead || _GamecontrolScript.Assassin1IsDead)
				{
					transform.FindChild("Priest/PriestLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
			if(_GamecontrolScript.Archer1IsDead || _GamecontrolScript.Archer2IsDead)
			{
				if(_GamecontrolScript.Archer1IsDead && _GamecontrolScript.Archer2IsDead)
				{
					transform.FindChild("Archer/ArcherLabel").GetComponent<UILabel>().text = 2+"";
				}
				else if(_GamecontrolScript.Assassin1IsDead || _GamecontrolScript.Assassin1IsDead)
				{
					transform.FindChild("Archer/ArcherLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
			if(_GamecontrolScript.Soldier1IsDead || _GamecontrolScript.Soldier2IsDead || _GamecontrolScript.Soldier3IsDead || _GamecontrolScript.Soldier4IsDead)
			{
				if(_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier2IsDead && _GamecontrolScript.Soldier3IsDead && _GamecontrolScript.Soldier4IsDead)
				{
					transform.FindChild("Soldier/SoldierLabel").GetComponent<UILabel>().text = 4+"";
				}
				else if((_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier2IsDead && _GamecontrolScript.Soldier3IsDead)
					||(_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier2IsDead && _GamecontrolScript.Soldier4IsDead)
					||(_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier3IsDead && _GamecontrolScript.Soldier4IsDead)
					||(_GamecontrolScript.Soldier2IsDead && _GamecontrolScript.Soldier3IsDead && _GamecontrolScript.Soldier4IsDead))
				{
					transform.FindChild("Soldier/SoldierLabel").GetComponent<UILabel>().text = 3+"";
				}
				else if((_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier2IsDead)
					||(_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier3IsDead)
					||(_GamecontrolScript.Soldier1IsDead && _GamecontrolScript.Soldier4IsDead)
					||(_GamecontrolScript.Soldier2IsDead && _GamecontrolScript.Soldier3IsDead)
					||(_GamecontrolScript.Soldier2IsDead&& _GamecontrolScript.Soldier4IsDead)
					||(_GamecontrolScript.Soldier3IsDead&& _GamecontrolScript.Soldier4IsDead))
				{
					transform.FindChild("Soldier/SoldierLabel").GetComponent<UILabel>().text = 2+"";
				}
				else 
				{
					transform.FindChild("Soldier/SoldierLabel").GetComponent<UILabel>().text = 1+"";
				}
			}
		}
	}
}
