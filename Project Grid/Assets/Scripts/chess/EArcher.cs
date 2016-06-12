using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EArcher : MonoBehaviour
{

  	private Rigidbody _rigidbody;
  	private ArcherCharacterClass _ArcherClass;
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
	public Vector3 newpos;
	public Animator ani;
	string ClickTile;
	Vector3 i;
	Vector3 hitpos;
	public GameObject AttackShot;

  	// Use this for initialization
	void Start()
	{
    	_rigidbody = GetComponent<Rigidbody>();
		_ArcherClass = new ArcherCharacterClass();
	    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
	    _inputManager = new InputManager();
	    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
	    _gameController = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
		_gameControllerScript =  _gameController.GetComponent<GameController>();
		_redPrefab = Resources.Load<GameObject>(Constants.Path.RedTilePrefab);
	    showingMovementRange = false;
	    revealed = false;
	    clickCount = 0;

		_gameControllerScript.EArcher1IsCover = true;
		_gameControllerScript.EArcher2IsCover = true;
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
								ClickTile = hits[i].transform.gameObject.name;
								hitpos = hits[i].transform.position;
								if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1" && _gameControllerScript.EArcher1IsCover)
								{
									this.gameObject.GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
									StartCoroutine(waitParticle());
								}
								else if(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2" && _gameControllerScript.EArcher2IsCover)
								{
									this.gameObject.GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
									this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
									StartCoroutine(waitParticle());
								}
								else if((_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher1" && !_gameControllerScript.EArcher1IsCover) 
									||(_gameController.GetComponent<GameController>().PreSelectedUnit == "EArcher2" && !_gameControllerScript.EArcher2IsCover))
								{
									StartCoroutine(waittimetomove(hits[i].transform.position));
								}
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
			if(_gameControllerScript.EArcher1IsCover && this.gameObject.name == "EArcher1" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(Coverselect)";
			}
			else if(!_gameControllerScript.EArcher1IsCover && this.gameObject.name == "EArcher1" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
			else if(!_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2" &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
			{
				panel.transform.Find("see").gameObject.SetActive(false);
			}
		}
		if(GameObject.Find("myinceasecard4"))
		{
			if(GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect && _gameController.GetComponent<GameController>().selectedUnit == "Hero1")
			{
				see();
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchSelect = false;
				GameObject.Find("myinceasecard4").GetComponent<InceaseCard>().MagicWatchUsed = true;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().ResetDefaultColor();
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<TweenAlpha>().enabled = false;
				GameObject.Find("myinceasecard4").GetComponent<UIButton>().defaultColor = new Color(255/255f,255/255f,255/255f,80/255f);
				GameObject.Find("Hero1").GetComponent<Hero>().see();
				print(GameObject.Find("myinceasecard4").GetComponent<UILabel>().color);
			}
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
		newpos= new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
		GetComponentInChildren<TextMesh>().text = this.gameObject.name;
		if(this.gameObject.name == "EArcher1"){
			if(_gameControllerScript.EArcher1IsCover){
				_gameControllerScript.EArcher1IsCover = false;
			}
		}
		if(this.gameObject.name == "EArcher2"){
			if(_gameControllerScript.EArcher2IsCover){
				_gameControllerScript.EArcher2IsCover = false;
			}
		}
  	}

	private void showMovementRange()
	{
		List<Vector3> possibleMoves = _ArcherClass.showMovementRange(_rigidbody.position);
		Quaternion initQuat = Quaternion.Euler(new Vector3(90, 0, 0));
		string tempname = "";
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
						if(_gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
						{
							if(!_gameControllerScript.EArcher1IsCover)
							{
								if(check.Length == 0)
								{
									GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
							}
						}
						else if(_gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
						{
							if(!_gameControllerScript.EArcher2IsCover)
							{
								if(check.Length == 0)
								{
									GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
							}
						}
						if(Physics.Raycast(ray, out hit))
						{
							if(check.Length == 2 )
							{	

								print("++"+tempname+"++");

								if(hit.collider.name != tempname)
								{
									print(hit.collider.name);
									tempname = hit.collider.name;
									print(tileCoordinate);
									GameObject moveRangeTile = Instantiate(_redPrefab, tileCoordinate, initQuat) as GameObject;
									moveRangeTile.transform.SetParent(this.transform);
								}
							}
						}
					}
				}
			}
		}
	}

	private void showUnit(bool show)
	{
		if(!revealed)
		{
			if(show)
			{
				GetComponentInChildren<TextMesh>().text = unitName;
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = "";
			}
		}
  	}

	public void attack()
	{
		print("attack  " + this.gameObject.name);
		//			showingMovementRange = true;
		//			_gameController.GetComponent<GameController>().pieceSelected = true;
		//			_gameController.GetComponent<GameController>().selectedUnit = unitName;
		//			_gameController.GetComponent<GameController>().PreSelectedUnit = unitName;
		//			showMovementRange();
		//			GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(select)";
		if(this.gameObject.name == "EArcher1" && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1" &&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.EArcher1IsCover)
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(CoverselectM&A)";
			}
			else
			{
				GetComponentInChildren<TextMesh>().text = this.gameObject.name + "\n(M&A)";
			}
		}
		else if(this.gameObject.name == "EArcher2"  && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2"&&showingMovementRange == false)
		{
			showingMovementRange = true;
			showMovementRange();
			if(_gameControllerScript.EArcher2IsCover)
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
//		if(_gameControllerScript.EArcher1IsCover && this.gameObject.name == "EArcher1" && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
//		{
			GetComponentInChildren<TextMesh>().text = unitName;
		if(this.name == "EArcher1")
		{
			_gameControllerScript.EArcher1IsCover = false;
		}
		else if(this.name == "EArcher2")
		{
			_gameControllerScript.EArcher2IsCover = false;
		}
			panel.SetActive(false);
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
			StartCoroutine(waitParticle());
//		}
//		else if(_gameControllerScript.EArcher2IsCover && this.gameObject.name == "EArcher2"  && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
//		{
//			GetComponentInChildren<TextMesh>().text = unitName;
//			_gameControllerScript.EArcher2IsCover = false;
//			panel.SetActive(false);
//			_gameController.GetComponent<GameController>().selectedUnit = "";
//			_gameController.GetComponent<GameController>().pieceSelected = false;
//			this.gameObject.GetComponent<MeshRenderer>().enabled = false;
//			this.transform.Find("Character").GetComponent<MeshRenderer>().enabled = false;
//			this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(true);
//			StartCoroutine(waitParticle());
//		}
	}
	public void cannel()
	{
		print(this.gameObject.gameObject);
		if(this.gameObject.name == "EArcher1" && _gameControllerScript.EArcher1IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher1\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EArcher2"  && _gameControllerScript.EArcher2IsCover && _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher2\n(Cover)";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if( this.gameObject.name == "EArcher1" && !_gameControllerScript.EArcher1IsCover &&_gameController.GetComponent<GameController>().selectedUnit == "EArcher1")
		{

			GetComponentInChildren<TextMesh>().text = "EArcher1";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
		else if(this.gameObject.name == "EArcher2"  &&!_gameControllerScript.EArcher2IsCover &&  _gameController.GetComponent<GameController>().selectedUnit == "EArcher2")
		{
			GetComponentInChildren<TextMesh>().text = "EArcher2";
			clearMovementIndicators();
			_gameController.GetComponent<GameController>().selectedUnit = "";
			_gameController.GetComponent<GameController>().pieceSelected = false;
		}
	}
	IEnumerator waitParticle(){
		yield return new WaitForSeconds(1.5f);
		this.transform.Find("Orc_Scout").gameObject.SetActive(true);
		this.transform.Find("fx_magic_lightning_summon_blue").gameObject.SetActive(false);
		if(ClickTile == "Red(Clone)")
		{
			StartCoroutine(waittimetomove(hitpos));
		}
	}
	IEnumerator waittimetomove(Vector3 pos){
		GameObject Model;
		Model = this.transform.FindChild("Orc_Scout").gameObject;
		Vector3 currentPosition = this.transform.position;
		//down
		if(pos.x < currentPosition.x)
		{
			i = new Vector3(0,270,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//up
		else if(pos.x > currentPosition.x)
		{
			i = new Vector3(0,90,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//right
		else if(pos.z < currentPosition.z)
		{
			i = new Vector3(0,180,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		//left
		else if(pos.z > currentPosition.z)
		{
			i = new Vector3(0,0,0);
			iTween.RotateTo(Model,iTween.Hash("rotation",i,"speed",180f,"easetype","linear","oncomplete","Move","oncompletetarget",this.gameObject));
		}
		newpos = pos;
		if(!GameObject.Find("myinceasecard2") || (GameObject.Find("myinceasecard2") && !GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().isActiveAndEnabled))
		{
			
		}
		if(ClickTile == "Red(Clone)")
		{
			ani.SetTrigger("Attack");
			AttackShot.GetComponent<triggerProjectile_EArcher>().shoot();
			yield return new WaitForSeconds(1.5f);
			if(!GameObject.Find("myinceasecard2") || (GameObject.Find("myinceasecard2") && !GameObject.Find("myinceasecard2").GetComponent<TweenAlpha>().isActiveAndEnabled))
			{
				yield return new WaitForSeconds(1.0f);
				moveCharacter(pos);
			}
		}
		if(ClickTile == "Green(Clone)")
		{
			yield return new WaitForSeconds(0.8f);
			moveCharacter(pos);
		}
	}
	public void TheItalianJobStep2()
	{
		print("!!");
		AttackShot.GetComponent<triggerProjectile_EArcher>().shoot();
		StartCoroutine(ForStep2());
	}
	IEnumerator ForStep2()
	{
		ani.SetTrigger("Attack");
		yield return new WaitForSeconds(1.2f);
		moveCharacter(newpos);
	}
}
