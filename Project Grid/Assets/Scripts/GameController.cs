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
