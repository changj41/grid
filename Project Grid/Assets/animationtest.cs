using UnityEngine;
using System.Collections;

public class animationtest : MonoBehaviour {

	public GameObject ThisAssassin;
	// Use this for initialization
	void Start () {
		ThisAssassin.GetComponent<Animation>().wrapMode = WrapMode.Loop;
		ThisAssassin.GetComponent<Animation>().CrossFade("idle");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
