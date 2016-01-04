using UnityEngine;
using System.Collections;

public class GameUi : MonoBehaviour {

	public GameObject UI1000;
	public GameObject UI2000;
	// Use this for initialization
	void Start () {
		Debug.Log("???");
		UI1000.SetActive(true);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void UI1000left5BUttonClicked(){
		Debug.Log("!!!");
		UI1000.SetActive(false);
		UI2000.SetActive(true);
	}
	public void UI2000left1ButtonClicked(){
		Application.LoadLevel("Grid");
	}
}
