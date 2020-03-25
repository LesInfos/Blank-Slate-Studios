using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementtemp : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Animator animator;
    //public Animator animatorGrass;
    public Transform movePoint;
    public Rigidbody2D rb;

    public LayerMask whatStopsMovement;

    Vector2 movement;

    Vector3 lastPosition = Vector3.zero;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
    }

    private void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
        //Debug.Log("speed: " + speed);

    }

    // Update is called once per frame
    void Update()
    {

        // Everything inside here handles grid based movement

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f), .2f, whatStopsMovement))
                {
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f);
                }
            }
        }
    }

    //// Detects if player enters grass
    //private void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Debug.Log("Entered!");
    //    //animatorGrass.SetBool("isEntered", true);
    //}
    //// Detects if player exits grass
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    Debug.Log("Exited!");
    //    //animatorGrass.SetBool("isEntered", false);
    //}
    //// Detects if player is currently in grass
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    Debug.Log("Inside!");
    //}

}
