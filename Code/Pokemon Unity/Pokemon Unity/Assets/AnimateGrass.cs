using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateGrass : MonoBehaviour
{
    public Animator animator;

    // Detects if player enters grass
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Entered!");
        animator.SetBool("isEntered", true);
    }
    // Detects if player exits grass
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exited!");
        animator.SetBool("isEntered", false);
    }
    // Detects if player is currently in grass
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Inside!");
    }
}
