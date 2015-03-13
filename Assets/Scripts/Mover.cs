using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float Speed;

    public void Start()
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.velocity = this.transform.forward * this.Speed;
    }
}
