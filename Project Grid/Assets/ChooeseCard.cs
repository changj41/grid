using UnityEngine;
using System.Collections;

public class ChooeseCard : MonoBehaviour {

	public GameObject CardBox1;
	public GameObject CardBox2;
	public GameObject CardBox3;
	public GameObject OccupationIcon;
	public GameObject UI1000;
	public GameObject UI1002;
	public GameObject item;
	public GameUI _gameui;
	GameObject go;
	void Start () {
		 
	}
	void OnClick()
	{
		if(this.name == "UI1002_Summoner_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard1 = "偷天換日";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard2 = "偷天換日";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard3 = "偷天換日";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Summoner_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard1 = "大號令";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard2 = "大號令";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard3 = "大號令";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Summoner_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard1 = "王者無懼";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard2 = "王者無懼";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.SummonerCardCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "SummonerIcon";
				_gameui.SummonerCardCount++;
				_gameui.SelectInceaseCard3 = "王者無懼";
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Hero_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard1 = "英雄之力";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard2 = "英雄之力";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard3 = "英雄之力";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Hero_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard1 = "連鎖反應";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard2 = "連鎖反應";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard3 = "連鎖反應";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Hero_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard1 = "魔力觀測";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard2 = "魔力觀測";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.HeroCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "HeroIcon";
				_gameui.SelectInceaseCard3 = "魔力觀測";
				_gameui.HeroCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Knight_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard1 = "先鋒者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard2 = "先鋒者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard3 = "先鋒者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Knight_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard1 = "守護者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard2 = "守護者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard3 = "守護者";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Knight_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard1 = "指揮官";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard2 = "指揮官";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.KnightCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "KnightIcon";
				_gameui.SelectInceaseCard3 = "指揮官";
				_gameui.KnightCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Warrior_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard1 = "二刀連擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard2 = "二刀連擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard3 = "二刀連擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Warrior_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard1 = "亡靈追擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard2 = "亡靈追擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard3 = "亡靈追擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Warrior_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard1 = "犧牲打擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard2 = "犧牲打擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.WarriorCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "WarriorIcon";
				_gameui.SelectInceaseCard3 = "犧牲打擊";
				_gameui.WarriorCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Assassin_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard1 = "偽裝";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard2 = "偽裝";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard3 = "偽裝";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Assassin_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard1 = "分身";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard2 = "分身";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard3 = "分身";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Assassin_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard1 = "模仿";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard2 = "模仿";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.AssassinCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "AssassinIcon";
				_gameui.SelectInceaseCard3 = "模仿";
				_gameui.AssassinCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Priest_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard1 = "感知預言";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard2 = "感知預言";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard3 = "感知預言";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Priest_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard1 = "精神控制";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard2 = "精神控制";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard3 = "精神控制";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Priest_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard1 = "靈魂連接";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard2 = "靈魂連接";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.PriestCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "PriestIcon";
				_gameui.SelectInceaseCard3 = "靈魂連接";
				_gameui.PriestCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Archer_Card_1")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard1 = "盲射";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard2 = "盲射";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard3 = "盲射";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Archer_Card_2")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard1 = "直覺";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard2 = "直覺";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard3 = "直覺";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
		else if(this.name == "UI1002_Archer_Card_3")
		{
			if(CardBox1.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox1.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard1 = "破甲";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox2.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox2.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard2 = "破甲";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
			else if(CardBox3.transform.childCount == 0 && _gameui.ArcherCount !=1)
			{
				go = Instantiate(item);
				go.transform.parent  = CardBox3.transform;
				go.transform.localPosition = Vector3.zero;
				go.transform.localScale = Vector3.one;
				go.GetComponent<UISprite>().spriteName = "ArcherIcon";
				_gameui.SelectInceaseCard3 = "破甲";
				_gameui.ArcherCount++;
				UI1000.SetActive(true);
				UI1002.SetActive(false);
			}
		}
	}
}
