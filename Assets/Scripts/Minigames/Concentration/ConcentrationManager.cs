using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConcentrationManager : MinigameManager
{

    public GameObject CardPrefab;

    public List<int> cardValues = new List<int> { 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8 };

    public int[] numFaceUp = new int[] {0, 0, 0, 0};

    public int[] faceUpCards = new int[] {-1, -1, -1, -1, -1, -1, -1, -1}; //Stores index of cards 0-15

    public int[] numCardsPerPlayer = new int[] {0, 0, 0, 0};

    public int[] score = new int[] {0, 0, 0, 0};

    public int matchCount = 0;

    public GameObject[] cards = new GameObject[36];

    public Material[] colors = new Material[9];

    public bool finished = false;

    public int player = 0;

    private static System.Random rng = new System.Random();

    void Shuffle(List<int> list) {
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            int value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    void CardSetup() {
        
        float xpos = -10f;
        float zpos = -14f;
        Shuffle(cardValues);
        for (int i = 0; i < cardValues.Count; i++) {
            if (i % 6 == 0) {
                xpos = -10f;
                zpos += 4f;
            }
            cards[i] = Instantiate(CardPrefab, new Vector3(xpos, 0f, zpos), new Quaternion(0f, 0f, 0f, 0f));
            cards[i].GetComponent<CardScript>().cardValue = cardValues[i];
            cards[i].GetComponent<CardScript>().index = i;
            cards[i].transform.GetChild(0).gameObject.GetComponent<Renderer>().material = colors[cards[i].GetComponent<CardScript>().cardValue];
            xpos += 4f;
        }
    }

    // Start is called before the first frame update
    //void Start()
    //{
    //    StartCoroutine(GameLoop());
    //}

    // Update is called once per frame
    void Update()
    {
        if (matchCount == 18) {
            finished = true;
        }
    }

    public void Flip(GameObject card, int index) {
        if (card.GetComponent<CardScript>().faceUp) {
            return;
        }
        Debug.Log(card.GetComponent<CardScript>().player);
        player = card.GetComponent<CardScript>().player;
        if (numFaceUp[player - 1] == 2) {
            cards[faceUpCards[(player - 1) * 2]].GetComponent<CardScript>().StartFlip();
            cards[faceUpCards[(player - 1) * 2 + 1]].GetComponent<CardScript>().StartFlip();
            numFaceUp[player - 1] = 0;
            faceUpCards[(player - 1) * 2] = -1;
            faceUpCards[(player - 1) * 2 + 1] = -1;
        }

        card.GetComponent<CardScript>().StartFlip();
        faceUpCards[(player - 1) * 2 + numFaceUp[player - 1]] = index;
        numFaceUp[player - 1] += 1;

        CheckMatch();
    }

    public void CheckMatch() {
        if (faceUpCards[(player - 1) * 2] < 0 || faceUpCards[(player - 1) * 2 + 1] < 0) {
            return;
        }
        if (cards[faceUpCards[(player - 1) * 2]].GetComponent<CardScript>().cardValue == cards[faceUpCards[(player - 1) * 2 + 1]].GetComponent<CardScript>().cardValue) {
            score[cards[faceUpCards[(player - 1) * 2 + 1]].GetComponent<CardScript>().player - 1] += 1;
            matchCount += 1;
            cards[faceUpCards[(player - 1) * 2]].GetComponent<CardScript>().ScorePopup();
            Destroy(cards[faceUpCards[(player - 1) * 2]]);
            Destroy(cards[faceUpCards[(player - 1) * 2 + 1]]);
            faceUpCards[(player - 1) * 2] = -1;
            faceUpCards[(player - 1) * 2 + 1] = -1;
            numFaceUp[player - 1] = 0;
        }
    }

    public void EndGame() {
        Debug.Log("Player " + (Array.IndexOf(score, score.Max())+1).ToString() + " wins");
    }

    public override IEnumerator GameLoop() {
        LockMovement();

        yield return StartCoroutine(GameStarting());
        UnlockMovement();

        yield return StartCoroutine(GamePlaying());

        LockMovement();

        yield return StartCoroutine(GameEnding());

        yield return StartCoroutine(ShowResults());

        yield return StartCoroutine(ReturnToBoard());
    }

    public override IEnumerator GameStarting() {
        UIMainText.text = "Ready?";
        UITimerText.text = "";
        LockMovement();

        yield return StartCoroutine(AdjustPlayers());

        CardSetup();

        yield return startWait;
    }

    public override IEnumerator GamePlaying()
    {
        phase = "Playing";
        UIMainText.text = "GO!";

        yield return new WaitForSeconds(1.5f);

        timer = TotalGameTime / Time.fixedDeltaTime;
        // While the game hasn't ended and while the timer is greater than 0
        while (!finished && (timer > 0))
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
    public override IEnumerator GameEnding()
    {
        phase = "End";
        UIMainText.text = "Finish";
        UITimerText.text = "";

        LockMovement();

        timer = endWaitSec / Time.fixedDeltaTime;

        while(timer > 0)
        {
            // If more than 1.5 seconds has past, remove "Finish!" from the UI
            if (((endWaitSec / Time.fixedDeltaTime) - timer) > (1.5 / Time.fixedDeltaTime))
            {
                UIMainText.text = "";
            }

            yield return null;
        }
    }

    public override IEnumerator ShowResults()
    {
        int winner = 0;
        bool tie = false;

        int highscore = score.Max();
        if (score[0] == highscore) {
            if (winner == 0) {
                winner = 1;
            }

            else {
                tie = true;
            }
        }

        if (score[1] == highscore) {
            if (winner == 0) {
                winner = 2;
            }

            else {
                tie = true;
            }
        }

        if (score[2] == highscore) {
            if (winner == 0) {
                winner = 3;
            }

            else {
                tie = true;
            }
        }

        if (score[3] == highscore) {
            if (winner == 0) {
                winner = 4;
            }

            else {
                tie = true;
            }
        }

        if (tie) {
            UIMainText.text = "It's a tie!";
        }
        else
        {
            UIMainText.text = "Player " + (Array.IndexOf(score, score.Max())+1).ToString() + " Wins!";
            // Increase the winner's score
            scoreTracker.GetComponent<ScoreTracker>().IncreaseScore((Array.IndexOf(score, score.Max())+1));
        }
        yield return resultsWait;
    }
}
