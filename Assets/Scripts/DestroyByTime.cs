using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
    public float LifeTime;

    public void Start()
    {
        Destroy(gameObject, this.LifeTime);
    }
}
