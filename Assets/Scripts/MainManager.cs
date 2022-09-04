using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;

    private GameManager gameManager;

    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text HighScoreText;
    public Text nameText;
    public GameObject GameOverText;

    private bool m_Started = false;
    private int m_Points;
    public int highScore;


    private bool m_GameOver = false;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //Duplicate GameManager created every time the scene is loaded
            Destroy(gameObject);
        }

    }

    void Start()
    {
        gameManager = GameManager.Instance;
        nameText.text = GameManager.user.UserName;

        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);

        int[] pointCountArray = new[] { 1, 1, 2, 2, 5, 5 };
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        checkHighscore();
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        checkHighscore();

        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    private void checkHighscore()
    {
        if (m_Points > GameManager.user.UserScore)
        {
            GameManager.user.UserScore = m_Points;
            HighScoreText.text = "NEW HIGHSCORE!";
            gameManager.UpdatePlayerScore(m_Points);
        }
        Debug.Log("Score: " + m_Points);
        Debug.Log("HighScore: " + highScore);
    }

}
