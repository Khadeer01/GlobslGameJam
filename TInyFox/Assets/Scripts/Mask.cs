using UnityEngine;
using System.Collections;

public class Mask : MonoBehaviour
{
    [Header("Mask Settings")]
    public float activeDuration = 5f;
    public float cooldownDuration = 3f;

    public bool IsMaskActive { get; private set; }

    private bool canUse = true;

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

        // Mask effect active
        yield return new WaitForSeconds(activeDuration);

        IsMaskActive = false;

        // Cooldown
        yield return new WaitForSeconds(cooldownDuration);
        canUse = true;
    }
}
