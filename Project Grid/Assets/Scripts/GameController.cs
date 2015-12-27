using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  	private InputManager _inputManager;
  	private GameObject _camera;

  	private bool turnBeginPhase;
  	private bool characterSelectPhase;
  	private bool movementPhase;
  	private bool attackPhase;

  	public bool pieceSelected;
	public string selectedUnit;
	public string PreSelectedUnit;

	public bool Soldier1IsCover;
	public bool Soldier2IsCover;
	public bool Soldier3IsCover;
	public bool Soldier4IsCover;
	public bool Assassin1IsCover;
	public bool Assassin2IsCover;
	public bool Knight1IsCover;
	public bool Knight2IsCover;
	public bool Archer1IsCover;
	public bool Archer2IsCover;
	public bool SummnonerIsCover;
	public bool HeroIsCover;
	public bool Warrior1IsCover;
	public bool Warrior2IsCover;
	public bool Priest1IsCover;
	public bool Priest2IsCover;


  	//Temp
  	private GameObject summoner;
  	private GameObject hero;

  	void Start ()
  	{
    	_inputManager = new InputManager();
		_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    	pieceSelected = false;
    	turnBeginPhase = false;
    	characterSelectPhase = false;
    	movementPhase = false;

    	//Temp
    	summoner = GameObject.Find("Summoner");
    	hero = GameObject.Find("Hero");
	}
	

	void Update ()
  	{
    	ScreenInput input = _inputManager.GetInput();
    	if(input != null)
    	{
      		Ray ray = new Ray(_camera.transform.position, input.inputPoint - _camera.transform.position);
      		RaycastHit[] hits = Physics.RaycastAll(ray, Constants.Board.raycastLength);
    	}
	}
}
