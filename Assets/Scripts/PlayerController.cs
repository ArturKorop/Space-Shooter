using UnityEngine;
using System.Collections;
using Assets.Scripts.Helpers;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundary Boundary;

    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var rigidbody = this.GetComponent<Rigidbody>();
        var moveVector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidbody.velocity = moveVector * this.Speed;

        rigidbody.position = new Vector3
        (
            Mathf.Clamp(rigidbody.position.x, Boundary.xMin, Boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidbody.position.z, Boundary.zMin, Boundary.zMax)
        );

        rigidbody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidbody.velocity.x * -this.Tilt);
    }
}
