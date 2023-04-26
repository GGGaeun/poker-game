using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player
{
    public string nickname;
    public List<string> hand = new List<string>{ "C1", "C2", "C3", "C4" };
}
