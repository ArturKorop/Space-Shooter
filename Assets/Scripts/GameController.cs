using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 SpawnValue;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;

    public void Start()
    {
        StartCoroutine(this.SpawnWaves());
    }

    private IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(this.StartWait);

        while (true)
        {
            for (int i = 0; i < this.HazardCount; i++)
            {
                var spawnPosition = new Vector3(Random.RandomRange(-this.SpawnValue.x, this.SpawnValue.x), this.SpawnValue.y, this.SpawnValue.z);
                var spawnRotation = Quaternion.identity;
                Instantiate(this.Hazard, spawnPosition, spawnRotation);

                yield return new WaitForSeconds(this.SpawnWait);
            }

            yield return new WaitForSeconds(this.WaveWait);
        }
    }
}