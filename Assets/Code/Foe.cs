using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour
{
    [SerializeField] public bool aggressive = true;
    [SerializeField] float speed = 10.0f;
    [SerializeField] Transform target;
    [SerializeField] Character character;

    Colors colors;
    Colors.COLORGAME localColor;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        colors = GameObject.FindGameObjectWithTag("Game").GetComponent<Colors>();
        int randColor = Random.Range(0, 7);
        switch (randColor)
        {
            case 0:
                localColor = Colors.COLORGAME.RED;
                break;
            case 1:
                localColor = Colors.COLORGAME.GREEN;
                break;
            case 2:
                localColor = Colors.COLORGAME.BLUE;
                break;
            case 3:
                localColor = Colors.COLORGAME.YELLOW;
                break;
            case 4:
                localColor = Colors.COLORGAME.CYAN;
                break;
            case 5:
                localColor = Colors.COLORGAME.PURPLE;
                break;
            case 6:
                localColor = Colors.COLORGAME.WHITE;
                break;
            default:
                localColor = Colors.COLORGAME.WHITE;
                break;
        }
        GetComponent<SpriteRenderer>().color = colors.getColor(localColor);
    }

    // Update is called once per frame
    void Update()
    {
        if(character.currentSelectedColor == localColor)
        {
            Destroy(gameObject);
        }
        if (aggressive)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, target.position, step);
        }
    }
}
