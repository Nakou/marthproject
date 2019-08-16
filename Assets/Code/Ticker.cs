using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    [SerializeField] float topPos = 0;
    [SerializeField] float botPos = 0;
    [SerializeField] float triggerOnPos = 0;
    [SerializeField] float triggerOffPos = 0;
    [SerializeField] float stepSpeed = 0;

    public bool tickerOn = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        if (anchoredPosition.y < topPos)
        {
            if(anchoredPosition.y < triggerOffPos && anchoredPosition.y > triggerOnPos)
            {
                tickerOn = true;
            } else
            {
                tickerOn = false;
            }
            anchoredPosition.y += stepSpeed;
            GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        } else
        {
            anchoredPosition.y = botPos;
            GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        }
    }
}
