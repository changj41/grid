using UnityEngine;
using System.Collections;

public class DragDropItem : UIDragDropItem{

	// Use this for initialization
	public UISprite sprite;
	public UILabel label;
	private int count = 1;
	public string name;
	public SaveBox savebox;
	public GameObject item;
	GameObject go;
	GameUI gameUI;

	public void addcount(int number = 1)
	{
		count+=number;
		label.text = count+"";
	}

	protected override void OnDragDropRelease (GameObject surface)
	{
		base.OnDragDropRelease(surface);
		print(surface.tag + " " + surface.name);
		print(this.name);
		name = this.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName;
		if(surface.tag == "SaveBox" && this.tag != "DropUIClone")
		{
			go = NGUITools.AddChild(surface,item);
			go.transform.GetComponent<DragDropItem>().item = Resources.Load<GameObject>(Constants.Path.DropUI);
			print(name);
			go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName = name;
			go.transform.rotation = Quaternion.Euler(0,0,-45);
			go.transform.localPosition = Vector3.zero;
			ColorSet();
			gameUI.CountSet(name);
		}
		else if(surface.tag == "SaveBox"&& this.tag == "DropUIClone")
		{
			this.transform.parent = surface.transform;
			this.transform.localPosition = Vector3.zero;
		}
		else if(surface.tag == "DropUIClone" && this.tag == "DropUIClone")
		{
			print(surface.tag+"   item");
			Transform parent  = surface.transform.parent;
			surface.transform.parent = this.transform.parent;
			surface.transform.localPosition = Vector3.zero;
			this.transform.parent = parent;
			this.transform.localPosition = Vector3.zero;
		}
		else if(surface.tag == "DropUIClone" && this.tag == "DropUI")
		{
			gameUI.CountSet(name);
			Destroy(surface);
			go = NGUITools.AddChild(GameObject.Find(surface.transform.parent.name),item);
			go.transform.GetComponent<DragDropItem>().item = Resources.Load<GameObject>(Constants.Path.DropUI);
			go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName = name;
			go.transform.rotation = Quaternion.Euler(0,0,-45);
			go.transform.localPosition = Vector3.zero;
			ColorSet();
			gameUI.DestroySet(surface.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().spriteName,surface.tag);
		}
//		else if (surface.tag == "UIRight2")
		else if (surface.tag != "SaveBox" || surface.tag != "DropUIClone")
		{		
			DestroyObject(this.gameObject);	
			gameUI.DestroySet(name,this.tag);
		}
	}
	void ColorSet()
	{
		if(name == "UI_1000_Type_Summoner")
		{
			go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(255/255f,236/255f,92/255f,255/255f);						
		}
		else if(name == "UI_1000_Type_Hero")
		{
			go.transform.FindChild("UI1000_Pic_Icon").GetComponent<UISprite>().color = new Color(23/255f,234/255f,255/255f,255/255f);
		}
		else if(name == "UI_1000_Type_Worror")
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
	}
	void Start () {
		gameUI = GameObject.FindGameObjectWithTag("UI").GetComponent<GameUI>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
