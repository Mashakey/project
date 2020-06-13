using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class asd : MonoBehaviour
{
    public Text wins;
    // Start is called before the first frame update
    void Start()
    {
        if(TempClass.win == 0)
        {
            wins.text = TempClass.player1 + ", ПОБЕДИТЕЛЬ!";
        } else
        {
            wins.text = TempClass.player2 + " ПОБЕДИТЕЛЬ!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
