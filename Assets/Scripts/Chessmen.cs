﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Chessmen : MonoBehaviour
{
   public int CurrentX { set; get; }
    public int CurrentY { set; get; }
    public bool isWite;

    public void SetPosition(int x, int y)
    {
        CurrentX = x;
        CurrentY = y;
    }

    public virtual bool [,] PossibleMove()
    {
        return new bool [8,8];
    }
}
