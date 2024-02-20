using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class NewBehaviourScript : MonoBehaviour
{
    PlayerMovement playerMovement;
    private float horizontal;
    private bool isFacingRight = true;


    public void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        Flip();
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            Vector3 localPosition = transform.localPosition;
            localPosition.x *= -1f;
            transform.localPosition = localPosition;

        }
    }
}
