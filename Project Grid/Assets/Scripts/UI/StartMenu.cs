using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public void LogBUttonClicked(){
		Application.LoadLevelAsync("GameUi");
	}
}
