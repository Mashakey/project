﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class TempClass
{
    public static string player1 = "asd";
    public static string player2;
    public static int settimer;
    public static int win;
}

public class asdf : MonoBehaviour
{
    public InputField f1;
    public InputField f2;
    public InputField f3;

    public static string player1;
    public static string player2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void players()
    {
        TempClass.player1 = f1.text;
        TempClass.player2 = f2.text;
        TempClass.settimer = Convert.ToInt32(f3.text);
    }
}
