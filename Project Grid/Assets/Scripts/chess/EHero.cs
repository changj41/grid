using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EHero : MonoBehaviour
{
	private Rigidbody _rigidbody;
	private HeroCharacterClass _heroClass;
	private GameObject _greenPrefab;
	private GameObject _redPrefab;
	private InputManager _inputManager;
	private GameObject _camera;
	private GameObject _gameController;
	private GameController  _gameControllerScript;
	private bool showingMovementRange;
	private bool revealed;
	private int clickCount;
	public string unitName;
	public GameObject panel;
	public GameObject card;
	public GameObject Hero;
	// Use this for initialization
	void Start()
	{
    	_rigidbody = GetComponent<Rigidbody>();
    	_heroClass = new HeroCharacterClass();
    	_greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
    	_inputManager = new InputManager();
    	_camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    	_gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
    	showingMovementRange = false;
    	revealed = false;
    	clickCount = 0;
		_gameControllerScript.EHeroIsCover = true;
    	//Temp
		unitName = this.gameObject.name;
		GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(cover)";
  	}

  	// Update is called once per frame
  	void Update()
  	{
    	if(_gameController.GetComponent<GameController>().selectedUnit != unitName)
    	{
      		showingMovementRange = false;
    	}
    	if(showingMovementRange && _gameController.GetComponent<GameController>().selectedUnit == unitName)
    	{
      		ScreenInput input = _inputManager.GetInput();
      		if(input != null)
      		{
        		if(clickCount >= 1)
        		{
          			clickCount = 0;
          			Ray ray = new Ray(_camera.transform.position, input.inputPoint - _camera.transform.position);
          			RaycastHit[] hits = Physics.RaycastAll(ray, Constants.Board.raycastLength);

			        for(int i = 0; i < hits.Length; i++)
			        {
			            if(hits[i].rigidbody != null)
			            {
			            	if(hits[i].transform.gameObject.tag == Constants.Tags.MovementRangeIndicator)
			              	{
								showingMovementRange = false;
				                _gameController.GetComponent<GameController>().pieceSelected = false;
				                _gameController.GetComponent<GameController>().selectedUnit = null;
				                clearMovementIndicators();
				                revealed = true;
				                moveCharacter(hits[i].transform.position);
				            }
            			}
          			}
        		}
        		else
        		{
          		clickCount++;
        		}
      		}
    	}
  	}

  	void OnMouseDown()
  	{
		if(!showingMovementRange && !_gameController.GetComponent<GameController>().pieceSelected)
		{
			panel.SetActive(true);
			_gameController.GetComponent<GameController>().pieceSelected = true;
			_gameController.GetComponent<GameController>().selectedUnit = unitName;
			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;

			if(_gameControllerScript.EHeroIsCover)
			{
				panel.transform.Find("OK").gameObject.SetActive(false);
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(!_gameControllerScript.EHeroIsCover)
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
    	}
		if(card.GetComponent<InceaseCard>().MagicWatchSelect && _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
		{
			see();
			card.GetComponent<InceaseCard>().MagicWatchSelect = false;
			card.GetComponent<InceaseCard>().MagicWatchUsed = true;
			card.GetComponent<UIButton>().ResetDefaultColor();
			card.GetComponent<UIButton>().enabled = false;
			card.GetComponent<TweenAlpha>().enabled = false;
			Hero.GetComponent<Hero>().see();
		}
  	}

  	private void clearMovementIndicators()
  	{
    	GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
    	for(int i = 0; i < movementTiles.Length; i++)
    	{
      		Destroy(movementTiles[i]);
    	}
		panel.transform.Find("see").gameObject.SetActive(true);
		panel.SetActive(false);  	
  	}

  	private void moveCharacter(Vector3 newPosition)
  	{
    	Vector3 currentPosition = this.transform.position;
   		this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		if(this.gameObject.name == "EHero1")
		{
			if(_gameControllerScript.EHeroIsCover)
			{
				_gameControllerScript.EHeroIsCover = false;
			}
		}
  	}

 	private void showMovementRange()
  	{
    	List<Vector3> possibleMoves = _heroClass.showMovementRange(_rigidbody.position);
    	Quaternion initQuat = Quaternion.Euler(new Vector3(90, 0, 0));
   		for(int i = 0; i < possibleMoves.Count; i++)
    	{
      		if(possibleMoves[i] != _rigidbody.position)
      		{
        		if(possibleMoves[i].x >= 0 && possibleMoves[i].x < Constants.Board.boardX)
        		{
          			if(possibleMoves[i].z >= 0 && possibleMoves[i].z < Constants.Board.boardZ)
          			{
            			Vector3 tileCoordinate = new Vector3(possibleMoves[i].x, 0.1f, possibleMoves[i].z);
			            Vector3 tileToCharDirection = tileCoordinate - this.transform.position;
			            Ray ray = new Ray(this.transform.position, tileToCharDirection);
			            RaycastHit[] check = Physics.RaycastAll(ray, tileToCharDirection.magnitude);
						RaycastHit hit;
						if(check.Length == 0)
						{
							GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
							moveRangeTile.transform.SetParent(this.transform);
						}
						if(Physics.Raycast(ray, out hit))
						{
							if(check.Length == 1)
							{
								if(hit.collider.tag != this.gameObject.tag && hit.collider.transform.position.x == tileCoordinate.x && hit.collider.transform.position.z == tileCoordinate.z)
								{
									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
//									iTween.ColorTo(moveRangeTile,new Color(255/255f,0/255f,0/255f,50/255f),5f);
								}
							}
						}
          			}
        		}
      		}
    	}
  	}

	void OnTriggerEnter(Collider other) 
	{
		if(this.gameObject.name == _gameController.GetComponent<GameController>().PreSelectedUnit){
			if(other.gameObject.tag=="Character"){
				if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
				{
					if(other.gameObject.name == "Assassin1")
					{
						_gameControllerScript.Assassin1IsCover = false;
						GameObject.Find("Assassin1").GetComponentInChildren<TextMesh>().text = "Assassin1";
					}
					else if(other.gameObject.name == "Assassin2")
					{
						_gameControllerScript.Assassin2IsCover = false;
						GameObject.Find("Assassin2").GetComponentInChildren<TextMesh>().text = "Assassin2";
					}
					Destroy(this.gameObject);
				}
				else{
					Destroy(other.gameObject);
				}
			}
		}
	}
	public void attack()
	{
		if(_gameController.GetComponent<GameController>().selectedUnit == "EHero1")
		{
			showingMovementRange = true;

			showMovementRange();
			if(_gameControllerScript.EHeroIsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
	}
	public void see()
	{
		if(_gameControllerScript.EHeroIsCover)
		{
			GetComponentInChildren<TextMesh>().text = unitName;
			_gameControllerScript.EHeroIsCover = false;
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;

			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
	}
	public void cannel()
	{
		if(_gameControllerScript.EHeroIsCover && _gameController.GetComponent<GameController>().selectedUnit == "EHero1")
		{

			GetComponentInChildren<TextMesh>().text = "EHero\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(!_gameControllerScript.EHeroIsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "EHero1")
		{
			GetComponentInChildren<TextMesh>().text = "EHero1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		if(!panel.transform.Find("OK").gameObject.activeSelf)
		{
			panel.transform.Find("OK").gameObject.SetActive(true);
		}
		clickCount = 0;
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("Orc_Shaman").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
	}
}
