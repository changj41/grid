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
			SaveBoxGameObject[i-1] = GameObject.Find("UIRight2_2_"+i);
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
				if(items.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName == name)
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
					go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().spriteName = name;
					go.transform.rotation = Quaternion.Euler(0,0,-45);
					go.transform.localPosition = Vector3.zero;
					if(name == "World_RoseOfWinds")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);						
					}
					else if(name == "crossed-swords")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);
					}
					else if(name == "broadsword")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(83/255f,232/255f,255/255f,255/255f);
					}
					else if(name == "orb-wand")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(87/255f,240/255f,85/255f,255/255f);
					}
					else if(name == "spear-feather")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,239/255f,156/255f,255/255f);
					}
					else if(name == "plain-dagger")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,195/255f,53/255f,255/255f);
					}
					else if(name == "high-shot")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(255/255f,255/255f,10/255f,255/255f);
					}
					else if(name == "round-shield")
					{
						go.transform.FindChild("UIRight2_1_1_1").GetComponent<UISprite>().color = new Color(187/255f,255/255f,69/255f,255/255f);
					}
					break;
				}
			}
		}
	}
}

