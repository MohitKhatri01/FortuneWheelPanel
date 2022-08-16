using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WheelRotation : MonoBehaviour
{
    public float finalAngle;
    public float randomValue;
    public float timeInterval = 0.1f;
    bool coroutineAllowed = false;
    public Text Scoretext;
    public GameObject winCanvas;
    // Start is called before the first frame update
    void Start()
    {
        coroutineAllowed = true;
        winCanvas.gameObject.SetActive(false);
    }

    public void SpinButtonPressed()
    {
        if (coroutineAllowed == true)
        StartCoroutine(SpinWheel());
    }

    IEnumerator SpinWheel()
    {
        randomValue = Random.Range(20, 30);
        timeInterval = 0.1f;
        coroutineAllowed = false;

        for(int i = 0; i<randomValue; i++)
        {
            transform.Rotate(0, 0, 15f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
                timeInterval = 0.2f;
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
                timeInterval = 0.35f;
            yield return new WaitForSeconds(timeInterval);
        }
        if(Mathf.RoundToInt(transform.eulerAngles.z) % 30 !=0)
        {
            transform.Rotate(0, 0, 15f);
        }

        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z);

        switch (finalAngle)
        {
            case 0: Scoretext.text = "You Have Won 5 Coins";
                break;
            case 30:
                Scoretext.text = "You Have Won 10 Coins";
                break;
            case 60:
                Scoretext.text = "You Have Won 30 Coins";
                break;
            case 90:
                Scoretext.text = "You Have Won 500 Coins";
                break;
            case 120:
                Scoretext.text = "You Have Won 50 Coins";
                break;
            case 150:
                Scoretext.text = "You Have Won 25 Coins";
                break;
            case 180:
                Scoretext.text = "You Have Won 5 Coins";
                break;
            case 210:
                Scoretext.text = "You Have Won 200 Coins";
                break;
            case 240:
                Scoretext.text = "You Have Won 10 Coins";
                break;
            case 270:
                Scoretext.text = "You Have Won 20 Coins";
                break;
            case 300:
                Scoretext.text = "You Have Won 50 Coins";
                break;
            case 330:
                Scoretext.text = "You Have Won 10 Coins";
                break;
            case 360:
                Scoretext.text = "You Have Won 5 Coins";
                break;

        }
        winCanvas.SetActive(true);
        
    }

    public void CloseWinPopup()
    {
        winCanvas.SetActive(false);
        coroutineAllowed = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
