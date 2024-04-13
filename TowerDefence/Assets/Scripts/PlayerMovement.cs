using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 1;
    public float rotationSpeed = 5f;
    private Vector3 movementDirection;

    public float rayLength;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);

        FaceMovementDir();
        Interact();

    }

    private void FixedUpdate()
    {
        Interact();
    }


    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, rayLength);
            Debug.DrawRay(transform.position, movementDirection * rayLength, color: Color.red, 1f);

            if (hit.rigidbody != null)
            {
                //Debug.Log(hit.rigidbody.name);

                if (hit.rigidbody.CompareTag("Resource"))
                {
                    //Debug.Log("Res");

                }
                else if (hit.rigidbody.CompareTag("Building"))
                {
                    //Debug.Log("Build");

                }
                

            }
        }



    }



    private void FaceMovementDir()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, verticalInput, 0f).normalized;

        if (movementDirection != Vector3.zero)
        {
            float targetAngle = Mathf.Atan2(-movementDirection.x, movementDirection.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), rotationSpeed * Time.deltaTime);

        }

    }

}
