using UnityEngine;
using System.Collections;

public class AttackAssassin : MonoBehaviour {

	public void WhenAttackAssassin(Collider other,GameController _gameControllerScript)
	{
		if(other.gameObject.tag != this.gameObject.tag)
		{
			print("1");
			if((other.gameObject.name == "Assassin1"&&_gameControllerScript.Assassin1IsCover == true) || (other.gameObject.name == "Assassin2"&&_gameControllerScript.Assassin2IsCover == true))
			{
				print("2");
				if(other.gameObject.name == "Assassin1")
				{
					print("3");
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
				print("4");
				Destroy(other.gameObject);
			}
		}
	}
}
