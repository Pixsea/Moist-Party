using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class SpotlightMazeManager : MinigameManager
{
    public Text ScoreText1;  // Text to show the score for player 1
    public Text ScoreText2;
    public Text ScoreText3;
    public Text ScoreText4;
    public Text CenterText;  // text in the center of screen for reference
    public int player1Score = 0;  // How much time player 1 has gotten in spotlight/claimed spotlight?
    public int player2Score = 0;  // player 2
    public int player3Score = 0;  // player 3
    public int player4Score = 0;  // player 4
    public PointLights pLs;
    
    public override IEnumerator GameLoop()
    {
        Debug.Log("Active");

        // Start off by running the 'GameStart'
        yield return StartCoroutine(GameStarting());
        UnlockMovement2();
        pLs.givesPoints = true;
        pLs.lightMove = true;

        // Once the 'GameStart' coroutine is finished, run the 'GamePlaying' coroutine but don't return until it's finished.
        yield return StartCoroutine(GamePlaying());

        pLs.givesPoints = false;
        pLs.lightMove = false;

        // Once execution has returned here, run the 'GameEnd' coroutine, again don't return until it's finished.
        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowScores());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }

    public override IEnumerator GameStarting()
    {
        UIMainText.text = "Ready?";
        UITimerText.text = "";

        LockMovement2();

        // Adjust non used players
        yield return StartCoroutine(AdjustPlayers());

        // Wait for the specified length of time until yielding control back to the game loop.
        yield return startWait;
    }

    public override IEnumerator GamePlaying()
    {
        Debug.Log("Active");
        phase = "Playing";
        UIMainText.text = "GO!";

        timer = TotalGameTime / Time.fixedDeltaTime;

        // While the game hasn't ended and while the timer is greater than 0
        while (!gameEnded && (timer > 0))
        {
            // If more than 1.5 seconds has past, remove "GO!" from the UI
            if (((TotalGameTime / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            if (UsesTimer)
            {
                UITimerText.text = (Mathf.Ceil(timer * Time.fixedDeltaTime)).ToString();
            }

            // ... return on the next frame.
            yield return null;
        }
    }

    IEnumerator ShowScores()
    {
        // Adjust text positions to only show texts for the number of players then center them

        if (Players.Length == 1)
        {
            ScoreText1.transform.position = CenterText.transform.position;
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();
        }

        else if (Players.Length == 2)
        {
            ScoreText1.transform.position = CenterText.transform.position - new Vector3(125, 0, 0);
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();

            ScoreText2.transform.position = CenterText.transform.position + new Vector3(125, 0, 0);
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();
        }

        else if (Players.Length == 3)
        {
            ScoreText1.transform.position = CenterText.transform.position - new Vector3(250, 0, 0);
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();

            ScoreText2.transform.position = CenterText.transform.position;
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();

            ScoreText3.transform.position = CenterText.transform.position + new Vector3(250, 0, 0);
            ScoreText3.text = "Player 3:\n" + player3Score.ToString();
        }

        else
        {
            ScoreText1.text = "Player 1:\n" + player1Score.ToString();
            ScoreText2.text = "Player 2:\n" + player2Score.ToString();
            ScoreText3.text = "Player 3:\n" + player3Score.ToString();
            ScoreText4.text = "Player 4:\n" + player4Score.ToString();
        }


        yield return new WaitForSeconds(3);
    }

    public override IEnumerator ShowResults()
    {
        ScoreText1.text = "";
        ScoreText2.text = "";
        ScoreText3.text = "";
        ScoreText4.text = "";

        int highest = Mathf.Max(player1Score, player2Score, player3Score, player4Score);

        bool tie = false;
        int winner = 0;

        // Find the player number of the winner
        if (player1Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 1;
            }

            else
            {
                tie = true;
            }
        }

        if (player2Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 2;
            }
            // Otherwise tie
            else
            {
                tie = true;
            }
        }

        if (player3Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 3;
            }

            else
            {
                tie = true;
            }
        }

        if (player4Score == highest)
        {
            // If no winner has been chosen, set them as the winner
            if (winner == 0)
            {
                winner = 4;
            }

            else
            {
                tie = true;
            }
        }

        if (tie)
        {
            UIMainText.text = "TIE";
        }
        else
        {
            UIMainText.text = "Player " + winner.ToString() + " Wins!";

            // Increase the winner's score
            scoreTracker.GetComponent<ScoreTracker>().IncreaseScore(winner);
        }

        yield return resultsWait;
    }

    public override IEnumerator GameEnding()
    {
        phase = "End";
        UIMainText.text = "Finish";
        UITimerText.text = "";

        LockMovement2();

        timer = endWaitSec / Time.fixedDeltaTime;

        while (timer > 0)
        {
            // If more than 1.5 seconds has past, remove "Finish!" from the UI
            if (((endWaitSec / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            yield return null;
        }
    }

    public void IncreaseScore(int playerNum, int score)
    {
        if (playerNum == 1)
        {
            player1Score += score;
        }
        else if (playerNum == 2)
        {
            player2Score += score;
        }
        else if (playerNum == 3)
        {
            player3Score += score;
        }
        else if (playerNum == 4)
        {
            player4Score += score;
        }
    }
    public override IEnumerator AdjustPlayers()
    {
        Debug.Log("test1");
        Debug.Log(Players.Length);
        // Only c=change players if there are players to change
        if (Players.Length > 0)
        {
            Debug.Log("test1");
            // Remove players who aren't palying from the arena
            if (numPlayers < 4)
            {
                Players[3].gameObject.transform.position -= new Vector3(0, 100, 0);
                //Players[3].gameObject.SetActive(false);
            }

            if (numPlayers < 3)
            {
                Debug.Log(Players[2].gameObject.name);
                Players[2].gameObject.transform.position -= new Vector3(0, 100, 0);
                //Players[2].gameObject.SetActive(false);
            }
        }

        yield return null;
    }

    // Locks all player movement
    public void LockMovement2()
    {
        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            foreach (PlayerController2 pObject in Players[i].gameObject.GetComponentsInChildren<PlayerController2>())
            {
                pObject.lockMovement = true;
            }
        }
    }

    // Unlocks all player movement
    public void UnlockMovement2()
    {
        // Create the player Dictionary from the player array
        for (int i = 0; i < Players.Length; i++)
        {
            foreach (PlayerController2 pObject in Players[i].gameObject.GetComponentsInChildren<PlayerController2>())
            {
                pObject.lockMovement = false;
            }
        }
    }
}
