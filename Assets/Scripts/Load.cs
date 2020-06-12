using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Load : MonoBehaviour
{
   
    public Slider slider;
    public float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ((timer >= 1) && (timer <= 3))
        {
            slider.value = 25;
        }
        if ((timer >= 3) && (timer <= 6))
        {
            slider.value = 50;
        }
        if ((timer >= 6) && (timer <= 9))
        {
            slider.value = 75;
        }
        if ((timer >= 9) && (timer <= 12))
        {
            slider.value = 100;
        }
        if (timer >= 12)
        {
            SceneManager.LoadScene(1);
        }
    }

}
