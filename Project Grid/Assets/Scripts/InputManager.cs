//------------------------------------------------------------------------------
// The purpose of InputManager is to tell the game when inputs happen.
// The InputManager sorts through the details of whether the input was a mouse
// click or a touch
//------------------------------------------------------------------------------
using System;
using UnityEngine;

public class InputManager
{
	private bool _useTouch;

	public InputManager()
	{
		_useTouch = Input.touchSupported;
	}

	public ScreenInput GetInput()
	{
		if(_useTouch)
		{
			return getTouchInput();
		}
		else
		{
			return getMouseInput();
		}
	}

	private ScreenInput getTouchInput()
	{
		ScreenInput result = null;
		if(Input.touchCount > 0)
		{
			Touch firstTouch = Input.GetTouch(0);
			if (firstTouch.phase == TouchPhase.Began)
			{
				result = new ScreenInput();
				result.inputPoint = Camera.main.ScreenToWorldPoint(firstTouch.position);
				result.state = ScreenInput.State.Down;
			}
		}

		return result;
	}

	private ScreenInput getMouseInput()
	{
		ScreenInput result = null;

		if(Input.GetMouseButtonDown(0 /*left*/))
		{
			result = new ScreenInput();
      Vector3 mouseInput = Input.mousePosition;
      mouseInput.z = 10;
			result.inputPoint = Camera.main.ScreenToWorldPoint(mouseInput);
			result.state = ScreenInput.State.Down;
		}

		return result;
	}
}

// Represents in input on the screen, such as a mouse click or a touch
public class ScreenInput
{
	public enum State
	{
		Down,  // First frame click/touch down
		Hold,  // Click/touch held down
		Up,    // First frame click/touch up (released)
	}

	public Vector3 inputPoint;
	public State state;
}