using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{

    public bool automatic = false;
    public float speed = 3;
    public float h = 0.5f;
    public float jumpPower = 5;
    public Rigidbody rb;
    Vector3 movement;

    void Update()
    {

        if (automatic)
        {
            movement.Set(h, 0f, 0f);
        }
        else
        {
            movement.Set(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        }
        movement = movement.normalized * speed * Time.deltaTime;

        this.transform.Translate(movement);

        if (Input.GetButtonDown("Jump"))
        {
            this.rb.velocity = new Vector3(this.rb.velocity.x, jumpPower, this.rb.velocity.z);
        }

    }
}
