using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public static bool _gameIsOver;

    private void Start()
    {
        _gameIsOver = false;
    }

    void Update()
    {

        if (_gameIsOver)
        {
            return;
        }

        if (PlayerStats._lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        _gameIsOver = true;
        gameOverUI.SetActive(true);
    }
}
