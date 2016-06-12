using UnityEngine;
using System.Collections;

public class InceaseCard : MonoBehaviour {

	public bool MagicWatchSelect = false;
	public bool MagicWatchUsed = false;
	public bool KingWithoutfearUsed = false;
	public bool TheItalianJobSelect = false;
	public bool TheItalianJobUsed = false;
	public bool BigDecreeSelect = false;
	public bool BigDecreeUsed = false;
	public int BigDecreeCount = 2;
	public bool ChainReactionUsed = false;
	public bool TheForceOfHeroesUsed = false;
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
		if(CardName == "王者無懼" && !KingWithoutfearUsed)
		{
			print("王者無懼UsE");
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "偷天換日" && !TheItalianJobSelect && _gameController.GetComponent<GameController>().AttackedGridName == "Summoner1")
		{
			print("偷天換日use");
			TheItalianJobSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "大號令" && !BigDecreeUsed && _gameController.GetComponent<GameController>().PlayerSide % 2 == 0)
		{
			print("大號令use");
			BigDecreeSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "魔力觀測" && !MagicWatchUsed)
		{
			print("魔力觀測use");
			MagicWatchSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
		if(CardName == "連鎖反應" && !ChainReactionUsed )
		{
			print("連鎖反應use");
			MagicWatchSelect = true;
			this.gameObject.GetComponent<TweenAlpha>().enabled = false;
			this.gameObject.GetComponent<UIButton>().ResetDefaultColor();
			this.gameObject.GetComponent<UIButton>().enabled = false;
		}
	}
//	IEnumerator waitTheItalianJobSelect ()
//	{
//		
//	}
}