using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SummonerCharacterClass : ICharacterClass {

	public List<Vector3> showMovementRange(Vector3 currentPosition)
  	{
	    float currentX = currentPosition.x;
	    float currentY = currentPosition.y;
	    float currentZ = currentPosition.z;
	    List<Vector3> availableMovement = new List<Vector3>();

	    for(int i = -1; i <= 1; i++)
	    {
			for(int j = -1; j <= 1; j++)
			{
		        availableMovement.Add(new Vector3(currentX + i, currentY, currentZ + j));
	      	}
    	}

    	return availableMovement;
  	}

  	/*public List<Vector3> showAttackRange(Vector3 currentPosition)
  	{
	    float currentX = currentPosition.x;
	    float currentY = currentPosition.y;
	    float currentZ = currentPosition.z;
	    List<Vector3> availableAttack = new List<Vector3>();

	    for(int i = -1; i <= 1; i++)
    	{
      		for(int j = -1; j <= 1; j++)
      		{
        		availableAttack.Add(new Vector3(currentX + i, currentY, currentZ + j));
      		}
    	}

    	return availableAttack;
  	}*/
}
