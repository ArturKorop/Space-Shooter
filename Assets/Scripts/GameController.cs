using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Hazard;
    public Vector3 SpawnValue;
    public int HazardCount;
    public float SpawnWait;
    public float StartWait;
    public float WaveWait;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;

    private int Score;
    private bool gameOver;
    private bool restart;

    public void Start()
    {
        this.gameOver = false;
        this.restart = false;
        this.GameOverText.text = string.Empty;
        this.RestartText.text = string.Empty;
        this.Score = 0;
        this.UpdateScore();
        StartCoroutine(this.SpawnWaves());
    }

    public void Update()
    {
        if(this.restart)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }

    public void AddScore(int scoreValue)
    {
        this.Score += scoreValue;
        this.UpdateScore();
    }

    public void GameOver()
    {
        this.GameOverText.text = "Game Over";
        this.gameOver = true;
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

            if (this.gameOver)
            {
                this.RestartText.text = "Press 'R' for Restart";
                this.restart = true;
                break;
            }
        }
    }

    private void UpdateScore()
    {
        this.ScoreText.text = "Score: " + this.Score;
    }
}