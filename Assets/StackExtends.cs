using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class StackExtends
{

    public static Stack<T> Shuffle<T>(this Stack<T> stack)
    {
        var rnd = new System.Random();
        return new Stack<T>(stack.OrderBy(x => rnd.Next()));
    }

}
