using UnityEngine;


// Purpose: Control Settings for the Player
// Component: Player Input [non-gameObject]


public class InputManager
{
    // Class to contain keycodes 

    public KeyCode Left { get; }
    public KeyCode Right { get; }
    public KeyCode Jump { get; }

    public InputManager(EnumHelper.Player player)
    {
        // Different input controls for different players
        if (player == EnumHelper.Player.Player1)
        {
            Left = KeyCode.A;
            Right = KeyCode.D;
            Jump = KeyCode.W;
        }
        else if (player == EnumHelper.Player.Player2)
        {
            Left = KeyCode.LeftArrow;
            Right = KeyCode.RightArrow;
            Jump = KeyCode.UpArrow;
        }
    }
}
