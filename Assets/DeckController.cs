using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeckController : MonoBehaviour
{
    public Player[] players;

    public Sprite[] cardImages;

    public Hand myHand;

    public Hand[] playerHand;

    public string[] DeckSet =
    {
        "Jocker",
        "H1","H2","H3","H4","H5","H6","H7","H8","H9","H10","HJ","HQ","HK",
        "S1","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK",
        "C1","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK",
        "D1","D2","D3","D4","D5","D6","D7","D8","D9","D10","DJ","DQ","DK",
    };
    public Image deckImage;

    public Stack<string> currentDeck;

    // Start is called before the first frame update
    void Start()
    {
        GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDeckImage(string card)
    {
        int cardNumber = Array.IndexOf(DeckSet, card) + 1;
        Sprite cardImage = cardImages[cardNumber];
        deckImage.sprite = cardImage;
    }


    public void GameStart()
    {
        InitGameInfo();
        InitDeck();
        InitHand();
    }

    public void PickMyCard()
    {
        Debug.Log("더이상 카드를 뽑을 수 없습니(.");
        if (6 <= players[0].hand.Count)
        {
            return;
        }
        //카드 한장 내 핸드에 추가
        players[0].hand.Add(GetCardFromDeck());

        myHand.UpdateHand(players[0].hand.ToArray());
    }


    private void InitDeck()
    {
        // 덱 초기화
        currentDeck = new Stack<string>(DeckSet);
        currentDeck = currentDeck.Shuffle();
        SetDeckImage(null);

    }

    private void InitGameInfo()
    {
        players = new Player[]{
            new Player(),
            new Player(),
            new Player(),
            new Player(),
            new Player()
        };

        players[0].nickname = "1번유저";
        players[1].nickname = "2번유저";
        players[2].nickname = "3번유저";
        players[3].nickname = "4번유저";
        players[4].nickname = "5번유저";

        // 각 점수 초기화
        // 플레이어 닉네임 표시
    }

    public string GetCardFromDeck()
    {
        return currentDeck.Pop();
    }

    private void InitHand()
    {
        // 각 손패를 짠다

        players[0].hand = new List<string> { GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck() };
        myHand.UpdateHand(players[0].hand.ToArray());
        players[1].hand = new List<string> { GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck() };
        playerHand[0].UpdateHand(players[1].hand.ToArray());
        players[2].hand = new List<string> { GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck() };
        playerHand[1].UpdateHand(players[2].hand.ToArray());
        players[3].hand = new List<string> { GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck() };
        playerHand[2].UpdateHand(players[3].hand.ToArray());
        players[4].hand = new List<string> { GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck(), GetCardFromDeck() };
        playerHand[3].UpdateHand(players[4].hand.ToArray());
    }
}
