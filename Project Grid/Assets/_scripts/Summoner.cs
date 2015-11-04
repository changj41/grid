using UnityEngine;
using System.Collections;

public class Summoner : MonoBehaviour {

  private Rigidbody _rigidbody;

	// Use this for initialization
	void Start ()
  {
    _rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update()
  {

	}

  void OnMouseDown()
  {
    Vector3 floatPosition = _rigidbody.position;
    if(floatPosition.y > 1)
    {
      floatPosition.y--;
    } else
    {
      floatPosition.y += 1.0f;
    }
    _rigidbody.position = floatPosition;
  }
}
