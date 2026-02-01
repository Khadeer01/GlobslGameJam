using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour
{
    [Header("Mask Settings")]
    public float activeDuration = 5f;
    public float cooldownDuration = 3f;

    public bool IsMaskActive { get; private set; }

    private bool canUse = true;
    private float lastUseTime = -100f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canUse)
        {
            StartCoroutine(MaskRoutine());
        }
    }

    IEnumerator MaskRoutine()
    {
        canUse = false;
        IsMaskActive = true;
        lastUseTime = Time.time;

        // Mask effect active
        yield return new WaitForSeconds(activeDuration);

        IsMaskActive = false;

        // Cooldown
        yield return new WaitForSeconds(cooldownDuration);
        AudioManager.Play(AudioManager.Sound.MaskOn); 
        canUse = true;
    }

    public bool CanUse()
    {
        return canUse && !IsMaskActive;
    }

    // Returns remaining cooldown time in seconds
    public float GetCooldownTime()
    {
        if (IsMaskActive)
            return 0f;

        if (canUse)
            return 0f;

        float elapsedSinceUse = Time.time - lastUseTime - activeDuration;
        float remaining = cooldownDuration - elapsedSinceUse;
        return Mathf.Max(0f, remaining);
    }
}
