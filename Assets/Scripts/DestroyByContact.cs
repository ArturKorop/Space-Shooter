using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject PlayerExplosion;
    public int ScoreValue;

    private GameController gameController;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if(gameControllerObject != null)
        {
            this.gameController = gameControllerObject.GetComponent<GameController>();
        }

        if(this.gameController == null)
        {
            Debug.Log("Cannot find 'GameController' object");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(this.Explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(this.PlayerExplosion, other.transform.position, other.transform.rotation);
        }

        gameController.AddScore(this.ScoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
