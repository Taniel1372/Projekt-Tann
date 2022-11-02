using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public Rigidbody rb;
    public  Transform car;
    float carRotation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    bool driving;
    public TrailRenderer bLeft;
    public TrailRenderer bRight;
    public TrailRenderer fLeft;
    public TrailRenderer fRight;
    Vector3 place;
    // Update is called once per frame
    void FixedUpdate()
    {
        MyInput();
        if (Input.GetKey("w"))
        {
            moveDirection = transform.forward * verticalInput;
            rb.AddForce(moveDirection.normalized * 0.4f, ForceMode.VelocityChange);
            driving = true;
        }
        else if (Input.GetKey("s"))
        {
            moveDirection = transform.forward * verticalInput;
            rb.AddForce(moveDirection.normalized * 0.4f, ForceMode.VelocityChange);
            driving = true;
        }
        if (rb.velocity.y !> 0 && rb.velocity.z !> 0 && rb.velocity.z !> 0 )
        {driving = false;}
        if (Input.GetKey("d")&& driving)
        {
            car.rotation = Quaternion.Euler(0,carRotation + 1,0);
            carRotation ++;
        }
        if (Input.GetKey("a")&& driving)
        {
            car.rotation = Quaternion.Euler(0,carRotation - 1,0);
            carRotation --;
        }
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }
    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == "ground")
        {
            bLeft.enabled = false;
            bRight.enabled = false;
            fLeft.enabled = false;
            fRight.enabled = false;
        }
    }
}
