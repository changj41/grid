using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Summoner : MonoBehaviour {

  private Rigidbody _rigidbody;
  private SummonerCharacterClass _summonerClass;
  private GameObject _greenPrefab;
  private InputManager _inputManager;
  private GameObject _camera;

  private bool showingMovementRange;

	// Use this for initialization
	void Start ()
  {
    _rigidbody = GetComponent<Rigidbody>();
    _summonerClass = new SummonerCharacterClass();
    _greenPrefab = Resources.Load<GameObject>(Constants.Path.GreenTilePrefab);
    _inputManager = new InputManager();
    _camera = GameObject.FindGameObjectWithTag(Constants.Tags.MainCamera);
    showingMovementRange = false;
	}
	
	// Update is called once per frame
	void Update()
  {
    if(showingMovementRange)
    {
      ScreenInput input = _inputManager.GetInput();
      if(input != null)
      {
        Ray ray = new Ray(_camera.transform.position, input.inputPoint - _camera.transform.position);
        RaycastHit[] hits = Physics.RaycastAll(ray, 10.0f);
        
        for(int i = 0; i < hits.Length; i++)
        {
          //CHECK HERE FOR TAG ISSUES (NEEDS TO BE THE 2ND ONE)
          if(hits[i].rigidbody.tag == Constants.Tags.MovementRangeIndicator)
          {
            showingMovementRange = false;
            clearMovementIndicators();
            moveCharacter(hits[i].transform.position);
          }
        }
        
        Debug.Log(hits.Length);
        Debug.Log(hits[1].rigidbody.tag);
      }
    }
	}

  void OnMouseDown()
  {
    if(!showingMovementRange)
    {
      showingMovementRange = true;
      List<Vector3> possibleMoves = _summonerClass.showMovementRange(_rigidbody.position);
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
              GameObject moveRangeTile = Instantiate(_greenPrefab, tileCoordinate, initQuat) as GameObject;
              //moveRangeTile.transform.SetParent(this.transform);
            }
          }
        }
      }
    }
    else
    {
      showingMovementRange = false;
      clearMovementIndicators();
    }
    /*
    Vector3 floatPosition = _rigidbody.position;
    if(floatPosition.y > 1)
    {
      floatPosition.y--;
    } else
    {
      floatPosition.y += 1.0f;
    }
    _rigidbody.position = floatPosition;
    */
  }

  private void clearMovementIndicators()
  {
    GameObject[] movementTiles = GameObject.FindGameObjectsWithTag(Constants.Tags.MovementRangeIndicator);
    for(int i = 0; i < movementTiles.Length; i++)
    {
      Destroy(movementTiles[i]);
    }
  }

  private void moveCharacter(Vector3 newPosition)
  {
    Vector3 currentPosition = this.transform.position;
    this.transform.position = new Vector3(newPosition.x, currentPosition.y, newPosition.z);
  }
}
