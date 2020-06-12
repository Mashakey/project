using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class p1_event : MonoBehaviour
{
    public Text img1;
    public Text img2;
    // Start is called before the first frame update
    void Start()
    {
        q();
        
    }
    public void q()
    {
        img1.text = TempClass.player1;
        img2.text = TempClass.player2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
