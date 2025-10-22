using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerLevel3 : MonoBehaviour
{
    [SerializeField] private TMP_Text paddle1ScoreText;
    [SerializeField] private TMP_Text paddle2ScoreText;
    [SerializeField] private Transform paddle1Transform;
    [SerializeField] private Transform paddle2Transform;
    [SerializeField] private Transform ballTransform;
    [SerializeField] private int puntosParaGanar = 5;
    [SerializeField] private TMP_Text victoriaText;

    private int paddle1Score;
    private int paddle2Score;

    private static GameManagerLevel3 _instance;
    public static GameManagerLevel3 Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameManagerLevel3>();
            }
            return _instance;
        }
    }

    public void Paddle1Score()
    {
        paddle1Score++;
        paddle1ScoreText.text = paddle1Score.ToString();

        if (paddle1Score >= puntosParaGanar)
        {
            Ganar();
        }
    }

    public void Paddle2Score()
    {
        paddle2Score++;
        paddle2ScoreText.text = paddle2Score.ToString();

        if (paddle2Score >= puntosParaGanar)
        {
            Ganar();
        }
    }

    private void Ganar()
    {
        Time.timeScale = 0f; // pausa el juego

        // Si querés cambiar de escena:
        // SceneManager.LoadScene("IntermedioN3aFinal");
    }

    public void Restart()
    {
        paddle1Transform.position = new Vector2(paddle1Transform.position.x, 0);
        paddle2Transform.position = new Vector2(paddle2Transform.position.x, 0);
        ballTransform.position = Vector2.zero;
    }
}
