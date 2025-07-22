
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Button[] buttons;//count : 9
    [SerializeField] private TextMeshProUGUI playerTurn;

    private const string player1 = "O";
    private const string player2 = "X";
    private bool isPlayer1 = true;
    private int count = 0;
    private GameManager gameManager;
    private AudioManager audioManager;

    private int[][] winMoves = new int[][]
    {
        new int[] { 0, 1, 2 },
        new int[] { 3, 4, 5 },
        new int[] { 6, 7, 8 },
        new int[] { 0, 3, 6 },
        new int[] { 1, 4, 7 },
        new int[] { 2, 5, 8 },
        new int[] { 0, 4, 8 },
        new int[] { 2, 4, 6 }
    };
    private void Start()
    {
        InitializeBoard();
        gameManager = FindAnyObjectByType<GameManager>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    private void InitializeBoard()
    {
        foreach (var button in buttons)
        {

            button.onClick.AddListener(() =>
            {
                PlayMove(button);
            });
            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            text.text = "";
        }
        UpdatePlayerTurnUI();
    }


    private void PlayMove(Button button)
    {
        count++;
        TextMeshProUGUI cellText = button.GetComponentInChildren <TextMeshProUGUI>();
        cellText.text  = GetCurrentPlayer();
        button.enabled = false;

        checkWin();

        isPlayer1 = !isPlayer1;
        UpdatePlayerTurnUI();

    }

    private bool checkTriplets(int index1,int index2, int index3, string currentPlayer)
    {
        Button[] buttonsList = {
            buttons[index1],
            buttons[index2],
            buttons[index3],
        };

        //check if all text equal to player move
        foreach(Button button in buttonsList)
        {
            TextMeshProUGUI text = button.GetComponentInChildren<TextMeshProUGUI>();
            if (!text.text.Equals(currentPlayer))
            {
                return false;
            }

        }

        //if win color win move to green
        foreach(Button button in buttonsList)
        {
            button.GetComponent<Image>().color = Color.green;
        }

        return true;
    }
    private void checkWin()
    {
        foreach (var moves in winMoves)
        {
            string currentPlayer = GetCurrentPlayer();
            if (checkTriplets(moves[0], moves[1], moves[2], currentPlayer))
            {
                EndGame();
            }
        }
        if (count >= 9)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        foreach (var button in buttons)
        {
            button.enabled = false;
        }
        audioManager.PlayWinSound();
        gameManager.LoadGameOver();
    }
    
    private void UpdatePlayerTurnUI()
    {
        playerTurn.text = GetCurrentPlayer();
        if (isPlayer1)
        {
            playerTurn.color = Color.green;

        }
        else
        {
            playerTurn.color = Color.red;
        }
    }

    private string GetCurrentPlayer()
    {
        return isPlayer1? player1 : player2;
    }
}
