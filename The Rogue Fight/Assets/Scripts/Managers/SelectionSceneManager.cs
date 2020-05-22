using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class SelectionSceneManager : MonoBehaviour
{
    public PlayerIDManager playerIDManager;

    public TMP_Text playerID1Text;
    public TMP_Text playerID2Text;

    public void OnReadyToFight()
    {
        SetPlayerIDs();
        LoadFightScene();
    }


    private void SetPlayerIDs()
    {
        playerIDManager.SetPlayer1ID(DecodeID(playerID1Text.text));
        playerIDManager.SetPlayer2ID(DecodeID(playerID2Text.text));
    }

    private int DecodeID(string rogue)
    {
        switch (rogue)
        {
            case "Rogue_01":
                return 1;
            case "Rogue_02":
                return 2;
            case "Rogue_03":
                return 3;
            case "Rogue_04":
                return 4;
            case "Rogue_05":
                return 5;
            case "Rogue_06":
                return 6;
            default:
                return 0;
        }
    }

    private void LoadFightScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
