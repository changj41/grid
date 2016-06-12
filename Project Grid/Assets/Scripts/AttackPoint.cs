using UnityEngine;
using System.Collections;

public class AttackPoint : MonoBehaviour {

	private GameObject _gameController;
	private GameController  _gameControllerScript;
	public GameObject EAssassin1;
	public GameObject EAssassin2;
	public GameObject Assassin1;
	public GameObject Assassin2;
	// Use this for initialization
	void Start () {
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript  =  _gameController.GetComponent<GameController>();
		EAssassin1 = GameObject.Find("EAssassin1");
		EAssassin2 = GameObject.Find("EAssassin2");
		Assassin1 = GameObject.Find("Assassin1");
		Assassin2 = GameObject.Find("Assassin2");
	}
		
	void OnTriggerEnter(Collider other) 
	{
		print(other.gameObject+"   hit");
		_gameControllerScript.AttackedGridName = other.gameObject.name;
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Priest1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Priest2" )
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
				{
					if(other.gameObject.name == "EAssassin1")
					{
						_gameControllerScript.EAssassin1IsCover = false;
						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
						EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
						EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);

					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest2" )
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Soldier1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Soldier2"
			||_gameController.GetComponent<GameController>().PreSelectedUnit == "Soldier3" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Soldier4")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				other.gameObject.SetActive(false);
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier2"
			||_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier3" || _gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier4")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Warrior1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Warrior2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
				{
					if(other.gameObject.name == "EAssassin1")
					{
						_gameControllerScript.EAssassin1IsCover = false;
						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
						EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
						EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Summoner1" )
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if(GameObject.Find("myinceasecard1"))
				{
					if((other.gameObject.name == "EAssassin1"&& _gameControllerScript.EAssassin1IsCover == true && !GameObject.Find("myinceasecard1").GetComponent<InceaseCard>().KingWithoutfearUsed) 
						|| (other.gameObject.name == "EAssassin2"&& _gameControllerScript.EAssassin2IsCover == true && !GameObject.Find("myinceasecard1").GetComponent<InceaseCard>().KingWithoutfearUsed))
					{
						if(other.gameObject.name == "EAssassin1")
						{
							_gameControllerScript.EAssassin1IsCover = false;
							GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
							EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "EAssassin2")
						{
							_gameControllerScript.EAssassin2IsCover = false;
							GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
							EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
				else
				{
					if((other.gameObject.name == "EAssassin1"&& _gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&& _gameControllerScript.EAssassin2IsCover == true))
					{
						if(other.gameObject.name == "EAssassin1")
						{
							_gameControllerScript.EAssassin1IsCover = false;
							GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
							EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "EAssassin2")
						{
							_gameControllerScript.EAssassin2IsCover = false;
							GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
							EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESummoner1" )
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Archer2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				other.gameObject.SetActive(false);
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if((GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed && !_gameControllerScript.EArcher1IsCover)
					||(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed && !_gameControllerScript.EArcher2IsCover))
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
					if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1") _gameControllerScript.EArcher1IsCover = false;
					if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2") _gameControllerScript.EArcher2IsCover = false;
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Assassin1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Assassin2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
				{
					if(other.gameObject.name == "EAssassin1")
					{
						_gameControllerScript.EAssassin1IsCover = false;
						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
						EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
						EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Hero1")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if(GameObject.Find("myinceasecard6"))
				{
					if((other.gameObject.name == "EAssassin1"&& _gameControllerScript.EAssassin1IsCover == true && !GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed) 
						|| (other.gameObject.name == "EAssassin2"&& _gameControllerScript.EAssassin2IsCover == true && !GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed))
					{
						if(other.gameObject.name == "EAssassin1")
						{
							_gameControllerScript.EAssassin1IsCover = false;
							GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
							EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "EAssassin2")
						{
							_gameControllerScript.EAssassin2IsCover = false;
							GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
							EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
				else
				{
					if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
					{
						if(other.gameObject.name == "EAssassin1")
						{
							_gameControllerScript.EAssassin1IsCover = false;
							GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
							EAssassin1.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "EAssassin2")
						{
							_gameControllerScript.EAssassin2IsCover = false;
							GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
							EAssassin2.GetComponent<EAssassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EHero1")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Knight1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Knight2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				other.gameObject.SetActive(false);
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && !GameObject.Find("myinceasecard2").GetComponent<InceaseCard>().TheItalianJobUsed)
				{
					GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().Play();
				}
				else if(GameObject.Find("myinceasecard5") && other.name == "Hero1" && !GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed)
				{
					GameObject.Find("myinceasecard5").GetComponent<InceaseCard>().ChainReactionUsed = true;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard5").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
					other.gameObject.SetActive(false);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					Destroy(this.gameObject);
				}
				else
				{
					if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
					{
						if(other.gameObject.name == "Assassin1")
						{
							_gameControllerScript.Assassin1IsCover = false;
							GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
							Assassin1.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						else if(other.gameObject.name == "Assassin2")
						{
							_gameControllerScript.Assassin2IsCover = false;
							GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
							Assassin2.GetComponent<Assassin>().Speicialsee(other.gameObject.name);
						}
						GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
					}
				}
			}
		}
	}
}
