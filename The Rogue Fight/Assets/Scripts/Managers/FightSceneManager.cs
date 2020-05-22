using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("P1: " + PlayerIDManager.Player1 + " P2: " + PlayerIDManager.Player2);

        GameObject player1 = Resources.Load<GameObject>("Characters/Rogue_0" + PlayerIDManager.Player1);
        GameObject player2 = Resources.Load<GameObject>("Characters/Rogue_0" + PlayerIDManager.Player2);

        Instantiate(player1);
        Instantiate(player2, new Vector3(5, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
