using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Grants a 1-second damage immunity window after any hit is received.
/// Add this component to any entity, then check IsImmune before applying damage
/// and call OnDamageReceived after damage is applied.
/// </summary>
public class damgepro : MonoBehaviour
{
    private const float ImmunityDuration = 1f;

    public bool IsImmune { get; private set; } = false;

    /// <summary>
    /// Fired when damage is received and the immunity window begins.
    /// </summary>
    public event Action OnDamageReceivedEvent;

    /// <summary>
    /// Call this whenever the entity receives damage. Starts the immunity window.
    /// </summary>
    public void OnDamageReceived()
    {
        if (!IsImmune)
        {
            IsImmune = true;
            OnDamageReceivedEvent?.Invoke();
            StartCoroutine(ResetImmunityAfterDelay());
        }
    }

    private IEnumerator ResetImmunityAfterDelay()
    {
        yield return new WaitForSeconds(ImmunityDuration);
        IsImmune = false;
    }
}
