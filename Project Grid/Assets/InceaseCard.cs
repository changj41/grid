using UnityEngine;
using System.Collections;

public class InceaseCard : MonoBehaviour {

	public bool MagicWatchSelect = false;
	public bool MagicWatchUsed = false;
	// Use this for initialization
	private GameObject _gameController;
	void Awake(){
//		SelectHeroImage = this.transform.parent.Find("hero0").GetComponent<UISprite>();
//		SelectHeroName = this.transform.parent.Find("hero_name").GetComponent<UILabel>();
	}

	void Start(){
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
	}

	void OnClick(){
		string CardName = this.transform.GetComponent<UILabel>().text;
		if(CardName == "魔力觀測" && !MagicWatchUsed)
		{
			print("魔力觀測use");
			MagicWatchSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
			this.gameObject.GetComponent<UIButton>().UpdateColor(true);
		}
	}

}