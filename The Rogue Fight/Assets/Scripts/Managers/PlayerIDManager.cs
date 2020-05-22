using UnityEngine;

public class PlayerIDManager : MonoBehaviour
{
    private static int player1;
    private static int player2;

    public void Awake()
    {
        Transform parent = transform.parent;
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
        //transform.parent = parent;
    }

    public static int Player1
    {
        get
        {
            return player1;
        }
    }

    public static int Player2
    {
        get
        {
            return player2;
        }
    }

    public void SetPlayer1ID(int value)
    {
        player1 = value;
    }

    public void SetPlayer2ID(int value)
    {
        player2 = value;
    }

}
