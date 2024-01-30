using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class PingPongPlay : MonoBehaviour
{
    public static PingPongPlay instance;
    public SphereController spCtrl;
    public Transform paddleRight;
    public Transform paddleLeft;
    public Transform ball;
    public PaddleController pCtrlRight;
    public PaddleController pCtrlLeft;

    public TMPro.TMP_Text infoText;
    public TMPro.TMP_Text scoreText;
    private void Awake()
    {
        instance = this;
    }
    private void OnDestroy()
    {
        instance = null;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (paddleRight == null)
        {
            paddleRight = GameObject.Find("paddleRight").transform;
            paddleLeft = GameObject.Find("paddleLeft").transform;
            ball = GameObject.Find("ball").transform;
            infoText = GameObject.Find("Canvas/infoText").GetComponent<TMP_Text>();
            scoreText = GameObject.Find("Canvas/scoreText").GetComponent<TMP_Text>();
        }
        if (spCtrl == null)
        {
            spCtrl = ball.gameObject.AddComponent<SphereController>();
        }
        pCtrlRight = paddleRight.gameObject.AddComponent<PaddleController>();
        pCtrlLeft = paddleLeft.gameObject.AddComponent<PaddleController>();
        pCtrlRight.ResetPos();
        pCtrlLeft.ResetPos();

        SetAndUpdateGamePhase(GamePhase.BeforeGame);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
    }

    float sensitivity = 0.1f;
    float input_h;
    float input_v;
    void ReadInput()
    {
        input_h = Input.GetAxis("Horizontal") * sensitivity;
        input_v = Input.GetAxis("Vertical") * sensitivity;
        //Debug.Log($"input = {input_h}, {input_v}");

        if (Input.GetKeyUp(KeyCode.F1))
        {
            SetAndUpdateGamePhase(GamePhase.DuringGame);
            spCtrl.StartAddForce();
        }

        pCtrlRight.SetXMove(input_h);
        pCtrlLeft.SetXMove(input_v);
    }


    #region Score and gameplay

    public GamePhase phase = GamePhase.BeforeGame;
    int gameRound;
    int leftScore;
    int rightScore;

    void InitScores()
    {
        leftScore = 0;
        rightScore = 0;
    }
    public void Scored(int sensorId)
    {
        // left=1 right=2
        if (sensorId == 1)
        {
            leftScore++;
        }
        else
        {
            rightScore++;
        }
        UpdatePhase();
    }
    void SetAndUpdateGamePhase(GamePhase _phase)
    {
        this.phase = _phase;
        UpdatePhase();
    }
    void UpdatePhase()
    {
        switch (phase)
        {
            case GamePhase.BeforeGame: UpdateTextBeforeGame(); break;
            case GamePhase.DuringGame: UpdateScoreText(); break;
            case GamePhase.Ending: break;

        }
    }
    void UpdateTextBeforeGame()
    {
        infoText.text = "Welcome Pong";
        scoreText.text = "Press F1 to Start Game";
    }
    void UpdateScoreText()
    {
        infoText.text = "";
        string scoreStr = $"{leftScore} - {rightScore}";
        scoreText.text = scoreStr;
    }
    #endregion
}

public enum GamePhase
{
    BeforeGame = 1,
    DuringGame = 2,
    Ending = 3,
}