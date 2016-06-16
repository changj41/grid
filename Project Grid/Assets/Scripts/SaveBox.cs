using UnityEngine;
using System.Collections;

public class SaveBox : MonoBehaviour {

	public GameObject[] SaveBoxGameObject;
	public string[] names;
	public GameObject item;
	public DragDropItem items;
	public int size;

	void Start(){
		SaveBoxGameObject = new GameObject[size];
		for(int i=1;i<=size;i++)
		{
			SaveBoxGameObject[i-1] = GameObject.Find("UI1000_Title_1_Icon_BackGround_"+i);
		}
	}
		
	public  void pickup(){
		int index = Random.Range(0,names.Length);
		print(index);
		string name = names[index];
		bool isfind = false;
		for(int i = 0 ; i<SaveBoxGameObject.Length;i++)
		{
			if(SaveBoxGameObject[i].transform.childCount>0)//判斷目前格子有無物品
			{
				//有的話 判斷目前物品名字
				items = SaveBoxGameObject[i].GetComponentInChildren<DragDropItem>();
				print(items.name);
				if(items.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName == name)
				{
					isfind = true;
					items.addcount(1);
					break;
				}
			}
		}
		if(isfind == false)
		{
			for(int i = 0 ; i<SaveBoxGameObject.Length; i++)
			{
				if(SaveBoxGameObject[i].transform.childCount == 0)
				{
					GameObject go = NGUITools.AddChild(SaveBoxGameObject[i],item);
					go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName = name;
					go.transform.rotation = Quaternion.Euler(0,0,-45);
					go.transform.localPosition = Vector3.zero;
					if(name == "UI_1000_Type_Summoner")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);						
					}
					else if(name == "UI_1000_Type_Hero")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Worrior")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(83/255f,232/255f,255/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Pastor")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(87/255f,240/255f,85/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Knight")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,239/255f,156/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Assassin")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,195/255f,53/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Archer")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,255/255f,10/255f,255/255f);
					}
					else if(name == "UI_1000_Type_Soldier")
					{
						go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(187/255f,255/255f,69/255f,255/255f);
					}
					break;
				}
			}
		}
	}
}

