using UnityEngine;
using System.Collections;

public class DragDrop : UIDragDropItem {

	protected override void OnDragDropRelease (GameObject surface)
	{
		base.OnDragDropRelease (surface);
		print(surface);
	}
}
