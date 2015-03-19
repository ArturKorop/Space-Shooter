using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour 
{
    public float Tumble;

    public void Start()
    {
        var rigidbody = this.GetComponent<Rigidbody>();
        rigidbody.angularVelocity = Random.insideUnitSphere * this.Tumble;
    }

}
