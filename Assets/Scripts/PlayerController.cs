using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Helpers;

[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float Tilt;
    public Boundary Boundary;

    public GameObject Shot;
    public Transform ShotSpawn;
    public float FireRate;

    private float nextFire = 0;

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

    public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > this.nextFire)
        {
            this.nextFire = Time.time + this.FireRate;
            Instantiate(this.Shot, this.ShotSpawn.position, this.ShotSpawn.rotation);
            this.GetComponent<AudioSource>().Play();
        }
    }
}
