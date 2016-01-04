using UnityEngine;
using System.Collections;

public class RedGridCheck : MonoBehaviour {
	public string ColliderGameobjectName;
	// Use this for initialization
	private GameObject _gameController;
	private GameController  _gameControllerScript;
	void Start () {
		_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log(other.gameObject.tag);
		ColliderGameobjectName = other.gameObject.name;
		string SelectName = _gameController.GetComponent<GameController>().selectedUnit;
		if((ColliderGameobjectName == "Assassin1"&&_gameController.GetComponent<GameController>().Assassin1IsCover)||(ColliderGameobjectName == "Assassin2"&&_gameController.GetComponent<GameController>().Assassin2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Soldier1"&&_gameController.GetComponent<GameController>().Soldier1IsCover)||(ColliderGameobjectName == "Soldier2"&&_gameController.GetComponent<GameController>().Soldier2IsCover)||(ColliderGameobjectName == "Soldier3"&&_gameController.GetComponent<GameController>().Soldier3IsCover)||(ColliderGameobjectName == "Soldier4"&&_gameController.GetComponent<GameController>().Soldier4IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Archer1"&&_gameController.GetComponent<GameController>().Archer1IsCover)||(ColliderGameobjectName == "Archer2"&&_gameController.GetComponent<GameController>().Archer2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if(ColliderGameobjectName == "Summoner"&&_gameController.GetComponent<GameController>().SummnonerIsCover)
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if(ColliderGameobjectName == "Hero"&&_gameController.GetComponent<GameController>().HeroIsCover)
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Warrior1"&&_gameController.GetComponent<GameController>().Warrior1IsCover)||(ColliderGameobjectName == "Warrior2"&&_gameController.GetComponent<GameController>().Warrior2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Priest1"&&_gameController.GetComponent<GameController>().Priest1IsCover)||(ColliderGameobjectName == "Priest2"&&_gameController.GetComponent<GameController>().Priest2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if((ColliderGameobjectName == "Knight1"&&_gameController.GetComponent<GameController>().Knight1IsCover)||(ColliderGameobjectName == "Knight2"&&_gameController.GetComponent<GameController>().Knight2IsCover))
		{
			if(SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4"||SelectName == "Knight1"||SelectName == "Knight2"||SelectName == "Archer1"||SelectName == "Archer2")
			{
				Destroy(this.gameObject);
			}
		}
		else if(ColliderGameobjectName == "Knight1"||ColliderGameobjectName == "Knight2")
		{
			if(SelectName == "Archer1"||SelectName == "Archer2"||SelectName == "Soldier1"||SelectName == "Soldier2"||SelectName == "Soldier3"||SelectName =="Soldier4")
			{
				Destroy(this.gameObject);
			}
		}
		/*else if(other==null){
			//if(other.gameObject.tag == "Character")
			Destroy(this.gameObject);
		}*/
		/*else if(other.gameObject.tag != "Character" && other.gameObject.tag =="MovementRangeIndicator")
		{
			if(other.gameObject.tag != "Character")
			{
				Destroy(other.gameObject);
			}
		}*/
	}
}
