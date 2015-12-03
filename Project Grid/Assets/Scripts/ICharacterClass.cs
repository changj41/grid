using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICharacterClass
{
  List<Vector3> showMovementRange(Vector3 currentPosition);
  List<Vector3> showAttackRange(Vector3 currentPosition);
}
