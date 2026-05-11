using UnityEngine;
using System.Collections;

public class sword : MonoBehaviour
{
    public Animator objAnimator;
    public float attackdelay;

    private bool isAttacking = false;

    void Start()
    {
        objAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isAttacking) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            objAnimator.SetBool("attack", true);
            StartCoroutine(EndAttack());
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            objAnimator.SetBool("upattack", true);
            StartCoroutine(EndAttack());
        }
    }

    /// <summary>
    /// Waits for the attack duration then resets all attack animator states.
    /// </summary>
    private IEnumerator EndAttack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(attackdelay);
        objAnimator.SetBool("attack", false);
        objAnimator.SetBool("upattack", false);
        isAttacking = false;
    }
}
