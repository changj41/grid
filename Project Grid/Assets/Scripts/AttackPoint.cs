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
		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Priest1" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Priest2" ){
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
					Destroy(this.gameObject);
				}
				else
				{
					Destroy(other.gameObject);
				}
			}
		}
	}
}
