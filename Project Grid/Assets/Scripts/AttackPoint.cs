using UnityEngine;
using System.Collections;

public class AttackPoint : MonoBehaviour {

	private GameObject _gameController;
	private GameController  _gameControllerScript;
	// Use this for initialization
	void Start () {
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript  =  _gameController.GetComponent<GameController>();
	}

	void OnTriggerEnter(Collider other) {
		print(other.gameObject);
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
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
				}
				else
				{
					other.gameObject.SetActive(false);
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
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
				}
				else
				{
					other.gameObject.SetActive(false);
				}
			}
		}
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Summoner1" )
		{
			if(other.gameObject.tag=="EmenyCharacter")
			{
				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
				{
					if(other.gameObject.name == "EAssassin1")
					{
						_gameControllerScript.EAssassin1IsCover = false;
						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
					}
					else if(other.gameObject.name == "EAssassin2")
					{
						_gameControllerScript.EAssassin2IsCover = false;
						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
					}
					GameObject.Find(_gameController.GetComponent<GameController>().PreSelectedUnit).SetActive(false);
				}
				else
				{
					other.gameObject.SetActive(false);
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
	}
}
