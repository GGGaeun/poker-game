using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public List<Image> handImages = new List<Image>();

    public Sprite[] cardImages;
    // 뒷면   0
    // 조커   1
    // 하트 1 2
    // 하트 2

    public string[] DeckSet =
    {
        "Jocker",
        "H1","H2","H3","H4","H5","H6","H7","H8","H9","H10","HJ","HQ","HK",
        "S1","S2","S3","S4","S5","S6","S7","S8","S9","S10","SJ","SQ","SK",
        "C1","C2","C3","C4","C5","C6","C7","C8","C9","C10","CJ","CQ","CK",
        "D1","D2","D3","D4","D5","D6","D7","D8","D9","D10","DJ","DQ","DK",
    };

    //카드 이미지 파일을 불러와              카드 정보값으로
    public Sprite GetCardImage(string card)
    {
                                        //      1     + 1 = 2
        int cardNumber = Array.IndexOf(DeckSet, card) + 1;
        // cardNumaber = 2
        Sprite cardImage = cardImages[cardNumber];
        //                    cardImages[2];
        return cardImage;
    }

    //UpdateHand(arr)
    // arr = [ "H1", "H2", "H3", "H4" ]
    public void UpdateHand(string[] cards)
    {
        // cards의 개수만큼(4개)
        if (handImages.Count < cardImages.Length)
        {
            int count = cardImages.Length - handImages.Count;
            for(int i = 0; i < count; i++)
            {
                Image image = Instantiate(handImages[0].gameObject, handImages[0].transform.parent).GetComponent<Image>();
                handImages.Add(image);
            }
        }
        for(var i = 0; i < handImages.Count; i++)
        {
            //                                       H1
            //handImages[0].sprite = GetCardImage(cards[0]);
            if (i < cards.Length)
            {
                handImages[i].gameObject.SetActive(true);
                handImages[i].sprite = GetCardImage(cards[i]);
            }
            else
            {
                handImages[i].gameObject.SetActive(false);
            }
        }
    }
}
