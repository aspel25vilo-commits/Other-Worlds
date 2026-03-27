using System.Collections;
using UnityEngine;

/// <summary>
/// Makes the entity's SpriteRenderer flicker while it is immune to damage.
/// Requires a damgepro component on the same GameObject.
/// </summary>
[RequireComponent(typeof(damgepro))]
[RequireComponent(typeof(SpriteRenderer))]
public class flickereffect : MonoBehaviour
{
    [Tooltip("How many times per second the sprite toggles on/off.")]
    public float flickerRate = 15f;

    private damgepro immunityHandler;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        immunityHandler = GetComponent<damgepro>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        immunityHandler.OnDamageReceivedEvent += StartFlicker;
    }

    private void OnDestroy()
    {
        immunityHandler.OnDamageReceivedEvent -= StartFlicker;
    }

    private void StartFlicker()
    {
        StartCoroutine(FlickerCoroutine());
    }

    private IEnumerator FlickerCoroutine()
    {
        float interval = 1f / flickerRate;

        while (immunityHandler.IsImmune)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(interval);
        }

        spriteRenderer.enabled = true;
    }
}
