using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoleAssigner : MonoBehaviour
{
    public TextMeshProUGUI roleTitle;
    public TextMeshProUGUI roleDescription;
    public Button toggleButton;
    private int currentPlayerIndex = 0;
    private List<string> roles = new List<string>();
    private bool isRoleVisible = false;

    void Start()
    {
        LoadRoles();
        ShowNextRole();
    }

    private void LoadRoles()
    {
        int roleCount = PlayerPrefs.GetInt("PlayerCount", 8);
        for (int i = 0; i < roleCount; i++)
        {
            string role = PlayerPrefs.GetString("Player-" + (i + 1).ToString(), "Citizen");
            roles.Add(role);
        }
    }

    public void ShowNextRole()
    {
        if (currentPlayerIndex == roles.Count)
        {
            roleTitle.text = "All roles assigned!";
            roleDescription.text = "Enjoy The Game!";
            toggleButton.gameObject.SetActive(false);
        }
        else if (!isRoleVisible)
        {
            UpdateUI();
            isRoleVisible = true;
        }
        else if (currentPlayerIndex < roles.Count)
        {
            UpdateUI();
            isRoleVisible = false;
            currentPlayerIndex++;
        }
    }

    private void UpdateUI()
    {
        if (isRoleVisible)
        {
            roleTitle.text = "Player " + (currentPlayerIndex + 1) + ": " + roles[currentPlayerIndex];
            roleDescription.text = GetRoleDescription(roles[currentPlayerIndex]);
            toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Understood!";
        }
        else
        {
            roleTitle.text = "Player " + (currentPlayerIndex + 1) + ": ???";
            roleDescription.text = "";
            toggleButton.GetComponentInChildren<TextMeshProUGUI>().text = "Show Role";
        }
    }

    private string GetRoleDescription(string role)
    {
        switch (role)
        {
            case "Godfather":
                return "The leader of the mafia who appears as a citizen when investigated by the detective";
            case "Mafia":
                return "An accomplice to the Godfather who is identified as a mafia member when investigated by the detective";
            case "Masked Mafia":
                return "A mafia member who appears as a citizen when investigated by the detective";
            case "Serial Killer":
                return "Has the ability to kill and acts as an offensive force for the mafia";
            case "Detective":
                return "Responsible for nighttime investigations to identify mafia members";
            case "Doctor":
                return "Can save one person from death each night";
            case "Sniper":
                return "Has the ability to kill a mafia member at night but must target correctly";
            case "Mayer":
                return "The Mayor can influence daytime executions with a veto power";
            case "Citizen":
                return "Participate in discussions and reasoning to identify the mafia";
            case "Mason":
                return "A special citizen who is connected with another citizen and can exchange information at night";
            case "Savior":
                return "A character who can prevent an execution or death once during the game";
            default:
                return "";
        }
    }
}
