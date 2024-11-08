using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RoleInitializer : MonoBehaviour
{
    public CanvasManager canvasManager;
    private List<string> roles;

    // Start is called before the first frame update
    void Start()
    {
        int playerCount = PlayerPrefs.GetInt("PlayerCount", 8);
        InitializeRoles(playerCount);
        ShuffleRoles();
        SaveRolesForGame();
        StartCoroutine(ShowGameCanvasAfterDelay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void InitializeRoles(int playerCount)
    {
        switch (playerCount)
        {
            case 8:
            default:
                roles = new List<string>() { "Godfather", "Mafia", "Masked Mafia", "Detective", "Doctor", "Sniper", "Citizen", "Citizen" };
                break;
            case 10:
                roles = new List<string>() { "Godfather", "Mafia", "Masked Mafia", "Detective", "Doctor", "Sniper", "Mayer", "Citizen", "Citizen", "Citizen" };
                break;

            case 12:
                roles = new List<string>() { "Godfather", "Mafia", "Masked Mafia", "Serial Killer", "Detective", "Doctor", "Sniper", "Mayer", "Citizen", "Citizen", "Mason", "Savior" };
                break;
        }
    }

    private void ShuffleRoles()
    {
        for (int i = 1; i <= 50; i++)
        {
            int i1 = Random.Range(0, roles.Count);
            int i2 = Random.Range(0, roles.Count);
            (roles[i1], roles[i2]) = (roles[i2], roles[i1]);
        }
    }

    private void SaveRolesForGame()
    {
        for (int i = 0; i < roles.Count; i++)
            PlayerPrefs.SetString("Player-" + (i + 1).ToString(), roles[i]);
    }

    IEnumerator ShowGameCanvasAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        canvasManager.ShowGameCanvas();
    }
}
