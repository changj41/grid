using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {

	public GameObject UI0000;
	public GameObject UI2000;
	DragDropItem dragdropitem;
	public  SaveBox savebox;
	public  DestrotDropUI destrotdropUI;
	public int SummonerLabel;
	public int HeroLabel;
	public int WarriorLabel;
	public int PrietsLabel;
	public int KnightLabel;
	public int AssassinLabel;
	public int ArcherLabel;
	public int SoldierLabel;
	public int StartSummonerLabel;
	public int StartHeroLabel;
	public int StartWarriorLabel;
	public int StartPrietsLabel;
	public int StartKnightLabel;
	public int StartAssassinLabel;
	public int StartArcherLabel;
	public int StartSoldierLabel;
	public GameObject LoadItem;
	GameObject go ;
	public GameObject item;

	// Use this for initialization
	public bool PageA;
	public bool PageB;
	void Start () {
		print(this.name);
		UI0000.SetActive(true);
//		PageA = true;
//		dragdropitem = GameObject.FindGameObjectWithTag("DropUI").GetComponent<DragDropItem>();
//		savebox = GameObject.Find("UIRight2_2").GetComponent<SaveBox>();
		StartSummonerLabel = SummonerLabel;
		StartHeroLabel = HeroLabel;
		StartWarriorLabel = WarriorLabel;
		StartPrietsLabel = PrietsLabel;
		StartKnightLabel = KnightLabel;
		StartAssassinLabel = AssassinLabel;
		StartArcherLabel = ArcherLabel;
		StartSoldierLabel = SoldierLabel;
		UIlabelTextSet();
//		for(int i=1;i<=savebox.size;i++)
//		{
//			if(PlayerPrefs.HasKey(savebox.SaveBoxGameObject[1].name+"PageA"))
//			{
//				print("do");
//				LoadEveryCountSet();
//				item = Instantiate(LoadItem);
//				item.transform.parent = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i).transform;
//				item.transform.localPosition = Vector3.zero;
//				item.transform.rotation = Quaternion.Euler(0,0,-45);
//				item.transform.localScale = new Vector3(1,1,1);
//				item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName = PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA");
//				LoadColor(PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA"));
//			}
//		}
	}
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
		{
			for(int i=1;i<=savebox.size;i++)
			{
				print(PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name,savebox.SaveBoxGameObject[i-1].transform.GetChild(0).GetChild(0).GetComponentInChildren<UISprite>().spriteName));
			}
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			PlayerPrefs.DeleteAll();
		}
		CheckCount();
	}

	public void UI1000left5BUttonClicked(){
		Debug.Log("!!!");
		int EmptyCheck = 0;
		for(int i=1;i<=savebox.size;i++)
		{
			if(savebox.SaveBoxGameObject[i-1].transform.childCount != 0 )
			{
				EmptyCheck++; 
				print(savebox.SaveBoxGameObject[i-1].name);
				print(savebox.SaveBoxGameObject[i-1].transform.GetChild(0).GetChild(0).GetComponentInChildren<UISprite>().spriteName);
			}
		}
		if(EmptyCheck == 16)
		{
			print("save");
			if(PageA)
			{
				for(int i=1;i<=savebox.size;i++)
				{
					PlayerPrefs.SetString(savebox.SaveBoxGameObject[i-1].name+"PageA",savebox.SaveBoxGameObject[i-1].transform.GetChild(0).GetChild(0).GetComponentInChildren<UISprite>().spriteName);
				}
			}
			if(PageB)
			{
				for(int i=1;i<=savebox.size;i++)
				{
					PlayerPrefs.SetString(savebox.SaveBoxGameObject[i-1].name+"PageB",savebox.SaveBoxGameObject[i-1].transform.GetChild(0).GetChild(0).GetComponentInChildren<UISprite>().spriteName);
				}
			}
		}
		else
		{
			print("have empty can't save");
		}
//		UI1000.SetActive(false);
//		UI2000.SetActive(true);
	}
	public void UI2000left1ButtonClicked(){
		Application.LoadLevel("Grid");
	}

	public void UI5000pic4ButtonClicked(){
		transform.FindChild("UI4000").gameObject.SetActive(true);
		transform.FindChild("UI5000").gameObject.SetActive(false);
	}
	public void UI0000_BackGround_2_Pic_1Clicked(){
		transform.FindChild("UI8000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
	}
	public void UI0000_BackGround_2_Pic_4Clicked(){
		transform.FindChild("UI7000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
	}
	public void UI0000_BackGround_1_Pic_3Clicked(){
		transform.FindChild("UI1000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
		dragdropitem = GameObject.FindGameObjectWithTag("DropUI").GetComponent<DragDropItem>();
		PageA = true;
		savebox = GameObject.Find("UIRight2_2").GetComponent<SaveBox>();
		print(savebox.size);
		StartCoroutine(WaitSaveBoxGameObjectCreate());
	}
	public void UI0000_BackGround_1_Pic_4Clicked(){
		transform.FindChild("UI5000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
	}
	public void UI0000_BackGround_1_Pic_2Clicked(){
		transform.FindChild("UI2000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
	}
	public void UI2000_Button_2Clicked(){
		transform.FindChild("UI2001").gameObject.SetActive(true);
		transform.FindChild("UI2000").gameObject.SetActive(false);
	}
	public void UI4000_Button_2Clicked(){
		transform.FindChild("UI4001").gameObject.SetActive(true);
		transform.FindChild("UI4000").gameObject.SetActive(false);
	}
	public void UI4001_Button_1Clicked(){
		transform.FindChild("UI4003").gameObject.SetActive(true);
		transform.FindChild("UI4001").gameObject.SetActive(false);
	}
	public void UI0000_BackGround_1_Pic_1Clicked(){
		transform.FindChild("UI4000").gameObject.SetActive(true);
		transform.FindChild("UI0000").gameObject.SetActive(false);
	}
	public void UI2000_Button_1Clicked(){
		transform.FindChild("UI0000").gameObject.SetActive(true);
		transform.FindChild("UI2000").gameObject.SetActive(false);
	}
	void CheckCount()
	{
		if(transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text == "0")
		{
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,127/255f);
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<DragDropItem>().interactable = false;
		}
		if(transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text == StartSummonerLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text == StartHeroLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text == StartWarriorLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text == StartPrietsLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text == StartKnightLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text == StartAssassinLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text == StartArcherLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<DragDropItem>().interactable = true;
		}
		if(transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text == StartSoldierLabel + "")
		{
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<DragDropItem>().interactable = true;
		}
	}

	public void CountSet(object name)
	{
		if(name.Equals("World_RoseOfWinds"))
		{
			SummonerLabel--;
			transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text = SummonerLabel + "";
		}
		else if(name.Equals("crossed-swords"))
		{
			HeroLabel--;
			transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text = HeroLabel + "";
		}
		else if(name.Equals("broadsword"))
		{
			WarriorLabel--;
			transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text = WarriorLabel + "";
		}
		else if(name.Equals("orb-wand"))
		{
			PrietsLabel--;
			transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text = PrietsLabel + "";
		}
		else if(name.Equals("spear-feather"))
		{
			KnightLabel--;
			transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text = KnightLabel + "";
		}
		else if(name.Equals("plain-dagger"))
		{
			AssassinLabel--;
			transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text = AssassinLabel + "";
		}
		else if(name.Equals("high-shot"))
		{
			ArcherLabel--;
			transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text = ArcherLabel + "";
		}
		else if(name.Equals("round-shield"))
		{
			SoldierLabel--;
			transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text = SoldierLabel + "";
		}
	}

	public void DestroySet(object name,string tag)
	{
		if(name.Equals("World_RoseOfWinds") && tag == "DropUIClone" && SummonerLabel < 1)
		{
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_1").GetComponent<DragDropItem>().interactable = true;
			SummonerLabel++;
			transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text = SummonerLabel + "";
		}
		else if(name.Equals("crossed-swords") && tag == "DropUIClone" && HeroLabel < 1)
		{
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_2").GetComponent<DragDropItem>().interactable = true;
			HeroLabel++;
			transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text = HeroLabel + "";
		}
		else if(name.Equals("broadsword") && tag == "DropUIClone" && WarriorLabel < 2)
		{
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_3").GetComponent<DragDropItem>().interactable = true;
			WarriorLabel++;
			transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text = WarriorLabel + "";
		}
		else if(name.Equals("orb-wand") && tag == "DropUIClone" && PrietsLabel < 2)
		{
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_4").GetComponent<DragDropItem>().interactable = true;
			PrietsLabel++;
			transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text = PrietsLabel + "";
		}
		else if(name.Equals("spear-feather") && tag == "DropUIClone" && KnightLabel < 2)
		{
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_5").GetComponent<DragDropItem>().interactable = true;
			KnightLabel++;
			transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text = KnightLabel + "";
		}
		else if(name.Equals("plain-dagger") && tag == "DropUIClone" && AssassinLabel < 2)
		{
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_6").GetComponent<DragDropItem>().interactable = true;
			AssassinLabel++;
			transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text = AssassinLabel + "";
		}
		else if(name.Equals("high-shot") && tag == "DropUIClone" && ArcherLabel < 2)
		{
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_7").GetComponent<DragDropItem>().interactable = true;
			ArcherLabel++;
			transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text = ArcherLabel + "";
		}
		else if(name.Equals("round-shield") && tag == "DropUIClone" && SoldierLabel < 4)
		{
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<UISprite>().color = new Color(255/255f,255/255f,255/255f,255/255f);
			transform.FindChild("UI1000/UIRight2_1_8").GetComponent<DragDropItem>().interactable = true;
			SoldierLabel++;
			transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text = SoldierLabel + "";
		}
	}
	public void PageABUttonClicked(){
		if(!PageA)
		{
			
			PageA = true;
			PageB = false;
			UIlabelTextSet();
			for(int i=1;i<=savebox.size;i++)
			{
				if(savebox.SaveBoxGameObject[i-1].transform.childCount.Equals(1))
				{
					LoadDefaultCount();
					destrotdropUI = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i + "/DropUI(Clone)").GetComponent<DestrotDropUI>();
					destrotdropUI.Destroythis(i);
				}
				if(PlayerPrefs.HasKey(savebox.SaveBoxGameObject[i-1].name+"PageA"))
				{
					LoadEveryCountSet();
					item = Instantiate(LoadItem);
					item.transform.parent = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i).transform;
					item.transform.localPosition = Vector3.zero;
					item.transform.rotation = Quaternion.Euler(0,0,-45);
					item.transform.localScale = new Vector3(1,1,1);
					item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName = PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA");
					LoadColor(PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA"));
				}
			}
		}
	}
	public void PageBBUttonClicked()
	{
		if(!PageB)
		{
			
			PageA = false;
			PageB = true;
			UIlabelTextSet();
			for(int i=1;i<=savebox.size;i++)
			{
				if(savebox.SaveBoxGameObject[i-1].transform.childCount.Equals(1))
				{
					LoadDefaultCount();
					destrotdropUI = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i + "/DropUI(Clone)").GetComponent<DestrotDropUI>();
					destrotdropUI.Destroythis(i);
				}

				if(PlayerPrefs.HasKey(savebox.SaveBoxGameObject[i-1].name+"PageB"))
				{	
					LoadEveryCountSet();
					item = Instantiate(LoadItem);
					item.transform.parent = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i).transform;
					item.transform.localPosition = Vector3.zero;
					item.transform.rotation = Quaternion.Euler(0,0,-45);
					item.transform.localScale = new Vector3(1,1,1);
					item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName = PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageB");
					LoadColor(PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageB"));
				}
			}
		}
	}
	public void UIlabelTextSet(){
		transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text = StartSummonerLabel+"";
		transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text = StartHeroLabel+"";
		transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text = StartWarriorLabel+"";
		transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text = StartPrietsLabel+"";
		transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text = StartKnightLabel+"";
		transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text = StartAssassinLabel+"";
		transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text = StartArcherLabel+"";
		transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text = StartSoldierLabel+"";
	}
	void LoadColor(string name){
		if(name == "World_RoseOfWinds")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);						
		}
		else if(name == "crossed-swords")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(23/255f,234/255f,255/255f,255/255f);
		}
		else if(name == "broadsword")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(83/255f,232/255f,255/255f,255/255f);
		}
		else if(name == "orb-wand")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(87/255f,240/255f,85/255f,255/255f);
		}
		else if(name == "spear-feather")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,239/255f,156/255f,255/255f);
		}
		else if(name == "plain-dagger")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,195/255f,53/255f,255/255f);
		}
		else if(name == "high-shot")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,255/255f,10/255f,255/255f);
		}
		else if(name == "round-shield")
		{
			item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(187/255f,255/255f,69/255f,255/255f);
		}
	}
	void LoadEveryCountSet(){
		SummonerLabel = 0;
		HeroLabel = 0;
		WarriorLabel = 0;
		PrietsLabel = 0;
		KnightLabel = 0;
		AssassinLabel = 0;
		ArcherLabel = 0;
		SoldierLabel = 0;
		transform.FindChild("UI1000/UIRight2_1_1/SummonerLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_2/HeroLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_3/WarriorLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_4/PrietsLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_5/KnightLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_6/AssassinLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_7/ArcherLabel").GetComponent<UILabel>().text = 0+"";
		transform.FindChild("UI1000/UIRight2_1_8/SoldierLabel").GetComponent<UILabel>().text = 0+"";
	}
	void LoadDefaultCount()
	{
		SummonerLabel = StartSummonerLabel;
		HeroLabel = StartHeroLabel;
		WarriorLabel = StartWarriorLabel;
		PrietsLabel = StartPrietsLabel;
		KnightLabel = StartKnightLabel;
		AssassinLabel = StartAssassinLabel;
		ArcherLabel = StartArcherLabel;
		SoldierLabel = StartSoldierLabel;
	}
	IEnumerator WaitSaveBoxGameObjectCreate()
	{
		yield return new WaitForSeconds(0.1f);
		if(PlayerPrefs.HasKey(savebox.SaveBoxGameObject[1].name+"PageA"))
		{
			for(int i=1;i<=savebox.size;i++)
			{
				LoadEveryCountSet();
				item = Instantiate(LoadItem);
				item.transform.parent = transform.FindChild("UI1000/UIRight2_2/UIRight2_2_" + i).transform;
				item.transform.localPosition = Vector3.zero;
				item.transform.rotation = Quaternion.Euler(0,0,-45);
				item.transform.localScale = new Vector3(1,1,1);
				item.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName = PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA");
				LoadColor(PlayerPrefs.GetString(savebox.SaveBoxGameObject[i-1].name+"PageA"));
			}
		}
	}
}
