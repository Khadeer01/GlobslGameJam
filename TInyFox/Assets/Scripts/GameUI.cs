using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour
{
    [Header("UI Elements")]
    public  TextMeshProUGUI maskStatusText;      // shows "Mask Ready" or "On Cooldown"
    public  TextMeshProUGUI  maskCooldownText;    // shows countdown timer

    private Mask playerMask;

    void Start()
    {
        // Find the player and its Mask component
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            playerMask = playerObj.GetComponent<Mask>();
    }

    void Update()
    {
        if (playerMask == null) return;

        // Check if mask is ready
        if (playerMask.IsMaskActive)
        {
            maskStatusText.text = "Mask Active!";
            maskCooldownText.text = ""; // hide cooldown while active
        }
        else if (!playerMask.CanUse()) // needs a small function in Mask
        {
           maskStatusText.text = "";
            maskCooldownText.text = playerMask.GetCooldownTime().ToString("F1") + "s";
        }
        else
        {
            maskStatusText.text = "Mask Ready";
            maskCooldownText.text = "";
        }
    }
}
