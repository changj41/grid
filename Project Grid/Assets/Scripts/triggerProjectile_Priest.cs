using UnityEngine;
using System.Collections;

public class triggerProjectile_Priest : MonoBehaviour {

	public GameObject projectile;
	public Transform shootPoint;
	public float startOffset = 1f;
	private GameObject magicMissile;

	public float attackLenght;
	public float attackRange;
	public float missileHeightGain = 0.3f;
//	private GameObject _gameController;
//	private GameController  _gameControllerScript;


	public Priest _priest;

	public void shoot()
	{
		magicMissile = Instantiate(projectile, shootPoint.position, transform.rotation) as GameObject;
		Vector3 pos = transform.position + new Vector3(0f, startOffset, 0f);
		Vector3[] path = new Vector3[3];
		Vector3 targetPos =  _priest.newpos;
		float distance = Vector3.Distance(pos, targetPos);
		path[0] = pos;
		path[1] = Vector3.MoveTowards(pos, targetPos, distance / 2.3f);
		path[1].y += missileHeightGain;
		path[2] = targetPos;

		iTween.MoveTo(magicMissile, iTween.Hash(
							"speed", 10f,
							"orienttopath", true,
							"path", path,
							"easetype", "linear",
							"oncomplete", "OnFXMissileReachedTarget",
							"oncompletetarget", gameObject,
							"oncompleteparams", magicMissile
						));
	}



	private void OnFXMissileReachedTarget(GameObject missile)
	{
		GameObject.Destroy(missile, 0.1f);
	}
//	void OnTriggerEnter(Collider other) {
//		print("do");
//		if(_gameController.GetComponent<GameController>().PreSelectedUnit == "Priest" || _gameController.GetComponent<GameController>().PreSelectedUnit == "Priest" ){
//			if(other.gameObject.tag=="EmenyCharacter")
//			{
//				if((other.gameObject.name == "EAssassin1"&&_gameControllerScript.EAssassin1IsCover == true) || (other.gameObject.name == "EAssassin2"&&_gameControllerScript.EAssassin2IsCover == true))
//				{
//					if(other.gameObject.name == "EAssassin1")
//					{
//						_gameControllerScript.EAssassin1IsCover = false;
//						GameObject.Find("EAssassin1").GetComponentInChildren<TextMesh>().text = "EAssassin1";
//					}
//					else if(other.gameObject.name == "EAssassin2")
//					{
//						_gameControllerScript.EAssassin2IsCover = false;
//						GameObject.Find("EAssassin2").GetComponentInChildren<TextMesh>().text = "EAssassin2";
//					}
//					Destroy(this.gameObject);
//				}
//				else
//				{
//					Destroy(other.gameObject);
//				}
//			}
//		}
//	}
	
}
