using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoldierCharacterClass : ICharacterClass
{

  	public List<Vector3> showMovementRange(Vector3 currentPosition)
  	{
	    float currentX = currentPosition.x;
	    float currentY = currentPosition.y;
	    float currentZ = currentPosition.z;
	    List<Vector3> availableMovement = new List<Vector3>();

		for(int i = -1; i <= 1; i++)
		{
			availableMovement.Add(new Vector3(currentX + i, currentY, currentZ));
			availableMovement.Add(new Vector3(currentX, currentY, currentZ + i));
		}

    return availableMovement;
  }
}
