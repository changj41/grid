using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HeroCharacterClass : ICharacterClass
{

	public List<Vector3> showMovementRange(Vector3 currentPosition)
	{
		float currentX = currentPosition.x;
		float currentY = currentPosition.y;
		float currentZ = currentPosition.z;
    	List<Vector3> availableMovement = new List<Vector3>();

    	// Use boardZ because it's bigger
    	for(int i = 0; i < 2 * Constants.Board.boardZ; i++)
    	{
      		// Input X direction coordinates
      		availableMovement.Add(new Vector3(currentX - Constants.Board.boardX + i, currentY, currentZ));
      		// Input Z direction coordinates
      		availableMovement.Add(new Vector3(currentX, currentY, currentZ - Constants.Board.boardZ + i));
      		// Input Diagonal direction coordinates
      		availableMovement.Add(new Vector3(currentX - Constants.Board.boardZ + i, currentY, currentZ - Constants.Board.boardZ + i));
      		availableMovement.Add(new Vector3(currentX + Constants.Board.boardZ - i, currentY, currentZ - Constants.Board.boardZ + i));
    	}

		return availableMovement;
  	}

	/*public List<Vector3> showAttackRange(Vector3 currentPosition)
  	{
	    float currentX = currentPosition.x;
	    float currentY = currentPosition.y;
	    float currentZ = currentPosition.z;
	    List<Vector3> availableAttack = new List<Vector3>();

	    // Use boardZ because it's bigger
	    for(int i = 0; i < 2 * Constants.Board.boardX; i++)
    	{
      		// Input X direction coordinates
		    availableAttack.Add(new Vector3(currentX - Constants.Board.boardX + i, currentY, currentZ));
		    // Input Z direction coordinates
		    availableAttack.Add(new Vector3(currentX, currentY, currentZ - Constants.Board.boardZ + i));
		    // Input Diagonal direction coordinates
		    availableAttack.Add(new Vector3(currentX - Constants.Board.boardX + i, currentY, currentZ - Constants.Board.boardZ + i));
		    availableAttack.Add(new Vector3(currentX + Constants.Board.boardX - i, currentY, currentZ - Constants.Board.boardZ + i));
		}

    	return availableAttack;
  	}*/
}
