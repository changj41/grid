using UnityEngine;
using System.Collections;

public class GridMaker : MonoBehaviour {

  	public GameObject _white;
  	public GameObject _blue;

  	public int _width;
  	public int _length;

  	private bool alternate = false;

	// Use this for initialization
	void Start () 
	{

	    for(int i = 0; i < _width*_length; i++)
	    {
			Quaternion initQuat = Quaternion.Euler(new Vector3(90, 0, 0));
	    	Vector3 initPosition = new Vector3((int) i / _width, 0, (int) i % _width);
	    	if(i % _width == 0) 
			{
	        	alternate = !alternate;
	    	}

	      	if(alternate) 
			{
	        	if(i % 2 == 0) 
				{
	          		Instantiate(_white, initPosition, initQuat);
	        	} 
				else 
				{
	          		Instantiate(_blue, initPosition, initQuat);
	        	}
	      	} 
			else 
			{
	        	if(i % 2 == 0) 
				{
	          		Instantiate(_blue, initPosition, initQuat);
	        	} 
				else 
				{
	          		Instantiate(_white, initPosition, initQuat);
	        	}
	      	}

    	}

	
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
