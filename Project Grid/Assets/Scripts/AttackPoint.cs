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
		_gameControllerScript.AttackedGriNamedTag = other.tag+"";
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
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
					WhoDead(_gameControllerScript.AttackedGridName);
				}
			}
			else if(other.gameObject.tag == GameObject.Find(_gameControllerScript.PreSelectedUnit).tag)
			{
				Vector3 tmp = other.transform.position;
				print(tmp);
				other.transform.position = GameObject.Find(_gameControllerScript.PreSelectedUnit).transform.position;
				GameObject.Find(_gameControllerScript.PreSelectedUnit).transform.position = tmp;
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EPriest2" )
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
				WhoDead(_gameControllerScript.AttackedGridName);
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier2"
			||_gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier3" || _gameController.GetComponent<GameController>().PreSelectedUnit == "ESoldier4")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
					WhoDead(_gameControllerScript.AttackedGridName);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EWarrior2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "ESummoner1" )
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Archer1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Archer2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if(GameObject.Find("myinceasecard20"))
				{
					if(GameObject.Find("myinceasecard20").GetComponent<InceaseCard>().BlindfireSelect)
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
							WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
							Destroy(this.gameObject);
						}
						else if(other.gameObject.name == "ESummoner1")
						{
							
							GameObject.Find("ESummoner1").GetComponentInChildren<TextMesh>().text = "ESummoner1";
							GameObject.Find("ESummoner1").GetComponent<ESummoner>().see();
							GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
							WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
							Destroy(this.gameObject);
						}
						else if(other.gameObject.name == "EKnight1")
						{
							
							GameObject.Find("EKnight1").GetComponentInChildren<TextMesh>().text = "EKnight1";
							GameObject.Find("EKnight1").GetComponent<EKnight>().see();
							GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
							WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
							Destroy(this.gameObject);
						}
						else if(other.gameObject.name == "EKnight2")
						{
							
							GameObject.Find("EKnight2").GetComponentInChildren<TextMesh>().text = "EKnight2";
							GameObject.Find("EKnight2").GetComponent<EKnight>().see();
							GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
							WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
							Destroy(this.gameObject);
						}
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
				else
				{
					other.gameObject.SetActive(false);
					WhoDead(_gameControllerScript.AttackedGridName);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
					Destroy(this.gameObject);
				}
				else
				{
					other.gameObject.SetActive(false);
					WhoDead(_gameControllerScript.AttackedGridName);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EAssassin2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
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
					if(GameObject.Find("myinceasecard6").GetComponent<InceaseCard>().TheForceOfHeroesUsed)
					{
						if((other.gameObject.name == "EAssassin1"&& _gameControllerScript.EAssassin1IsCover == true ) 
							|| (other.gameObject.name == "EAssassin2"&& _gameControllerScript.EAssassin2IsCover == true))
						{
							if(other.gameObject.name == "EAssassin1")
							{
								_gameControllerScript.EAssassin1IsCover = false;
								GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
								other.gameObject.SetActive(false);
								WhoDead(_gameControllerScript.AttackedGridName);
							}
							else if(other.gameObject.name == "EAssassin2")
							{
								_gameControllerScript.EAssassin2IsCover = false;
								GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
								other.gameObject.SetActive(false);
								WhoDead(_gameControllerScript.AttackedGridName);
							}
							Destroy(this.gameObject);
						}
						else
						{
							other.gameObject.SetActive(false);
							WhoDead(_gameControllerScript.AttackedGridName);
						}
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EHero1")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Knight1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Knight2")
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				other.gameObject.SetActive(false);
				WhoDead(_gameControllerScript.AttackedGridName);
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "EKnight2")
		{
			if(other.gameObject.tag=="Character")
			{
				if(GameObject.Find("myinceasecard2") && other.name == "Summoner1" && _gameControllerScript.SummnonerIsCover)
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
					WhoDead(_gameControllerScript.AttackedGridName);
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
					WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
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
						WhoDead(_gameController.GetComponent<GameController>().PreSelectedUnit);
						Destroy(this.gameObject);
					}
					else
					{
						other.gameObject.SetActive(false);
						WhoDead(_gameControllerScript.AttackedGridName);
					}
				}
			}
		}
	}

	void WhoDead(string AttackedName)
	{
		if(AttackedName == "Knight1")
		{
			_gameControllerScript.Knight1IsDead = true;
		}
		if(AttackedName == "Knight2")
		{
			_gameControllerScript.Knight2IsDead = true;
		}
		if(AttackedName == "Soldier1")
		{
			_gameControllerScript.Soldier1IsDead = true;
		}
		if(AttackedName == "Soldier2")
		{
			_gameControllerScript.Soldier2IsDead = true;
		}
		if(AttackedName == "Soldier3")
		{
			_gameControllerScript.Soldier3IsDead = true;
		}
		if(AttackedName == "Soldier4")
		{
			_gameControllerScript.Soldier4IsDead = true;
		}
		if(AttackedName == "Assassin1")
		{
			_gameControllerScript.Assassin1IsDead = true;
		}
		if(AttackedName == "Assassin2")
		{
			_gameControllerScript.Assassin2IsDead = true;
		}
		if(AttackedName == "Archer1")
		{
			_gameControllerScript.Archer1IsDead = true;
		}
		if(AttackedName == "Archer2")
		{
			_gameControllerScript.Archer2IsDead = true;
		}
		if(AttackedName == "Warrior1")
		{
			_gameControllerScript.Warrior1IsDead = true;
			if(GameObject.Find("myinceasecard7"))
			{
				if(!GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackUsed)
				{
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().enabled = true;
					GameObject.Find("myinceasecard7").GetComponent<BoxCollider>().enabled = true;
					GameObject.Find("myinceasecard7").GetComponent<TweenAlpha>().Play();
				}
				if(_gameControllerScript.Warrior1IsDead == true && _gameControllerScript.Warrior2IsDead == true)
				{
					GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackSelect = false;
					GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackUsed = true;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard7").GetComponent<BoxCollider>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				}
			}
		}
		if(AttackedName == "Warrior2")
		{
			_gameControllerScript.Warrior2IsDead = true;
			if(GameObject.Find("myinceasecard7"))
			{
				if(!GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackUsed)
				{
					GameObject.Find("myinceasecard7").GetComponent<BoxCollider>().enabled = true;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().enabled = true;
					GameObject.Find("myinceasecard7").GetComponent<TweenAlpha>().Play();
				}
				if(_gameControllerScript.Warrior1IsDead == true && _gameControllerScript.Warrior2IsDead == true)
				{
					GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackSelect = false;
					GameObject.Find("myinceasecard7").GetComponent<InceaseCard>().TheSoulPursueAndAttackUsed = true;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().ResetDefaultColor();
					GameObject.Find("myinceasecard7").GetComponent<BoxCollider>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<TweenAlpha>().enabled = false;
					GameObject.Find("myinceasecard7").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				}
			}
		}
		if(AttackedName == "Summoner1")
		{
			_gameControllerScript.SummnonerIsDead = true;
		}
		if(AttackedName == "Hero1")
		{
			_gameControllerScript.HeroIsDead = true;
		}
		if(AttackedName == "Priest1")
		{
			_gameControllerScript.Priest1IsDead = true;
		}
		if(AttackedName == "Priest2")
		{
			_gameControllerScript.Priest2IsDead = true;
		}
		if(AttackedName == "EKnight1")
		{
			_gameControllerScript.EKnight1IsDead = true;
		}
		if(AttackedName == "EKnight2")
		{
			_gameControllerScript.EKnight2IsDead = true;
		}
		if(AttackedName == "ESoldier1")
		{
			_gameControllerScript.ESoldier1IsDead = true;
		}
		if(AttackedName == "ESoldier2")
		{
			_gameControllerScript.ESoldier2IsDead = true;
		}
		if(AttackedName == "ESoldier3")
		{
			_gameControllerScript.ESoldier3IsDead = true;
		}
		if(AttackedName == "ESoldier4")
		{
			_gameControllerScript.ESoldier4IsDead = true;
		}
		if(AttackedName == "EAssassin1")
		{
			_gameControllerScript.EAssassin1IsDead = true;
		}
		if(AttackedName == "EAssassin2")
		{
			_gameControllerScript.EAssassin2IsDead = true;
		}
		if(AttackedName == "EArcher1")
		{
			_gameControllerScript.EArcher1IsDead = true;
		}
		if(AttackedName == "EArcher2")
		{
			_gameControllerScript.EArcher2IsDead = true;
		}
		if(AttackedName == "EWarrior1")
		{
			_gameControllerScript.EWarrior1IsDead = true;
		}
		if(AttackedName == "EWarrior2")
		{
			_gameControllerScript.EWarrior2IsDead = true;
		}
		if(AttackedName == "ESummoner1")
		{
			_gameControllerScript.ESummnonerIsDead = true;
		}
		if(AttackedName == "EHero1")
		{
			_gameControllerScript.EHeroIsDead = true;
		}
		if(AttackedName == "EPriest1")
		{
			_gameControllerScript.EPriest1IsDead = true;
		}
		if(AttackedName == "EPriest2")
		{
			_gameControllerScript.EPriest2IsDead = true;
		}
	}
}
