using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Colors;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] Ticker ticker;
    [SerializeField] float jumpForce = 2;
    [SerializeField] float moveSpeed = 2;
    [SerializeField] TextMeshPro spell;
    Colors colors;

    float horizontal = 0;
    bool jump = false;
    Rigidbody2D rb;

    bool redSelected = false;
    bool greenSelected = false;
    bool blueSelected = false;

    public COLORGAME currentSelectedColor = COLORGAME.NULL;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colors = GameObject.FindGameObjectWithTag("Game").GetComponent<Colors>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            resetLevel();
        }
        rb.AddForce(new Vector2(0, jumpForce * (jump ? 10 : 0)));
        transform.Translate(new Vector2(moveSpeed * horizontal, 0));
        if (ticker.tickerOn)
        {
            if(Input.GetKeyDown(KeyCode.W)){
                redSelected = true;
            }
            if(Input.GetKeyDown(KeyCode.X)){
                greenSelected = true;
            }
            if(Input.GetKeyDown(KeyCode.C)){
                blueSelected = true;
            }
        } else
        {
            redSelected = false;
            greenSelected = false;
            blueSelected = false;
        }
        defineColor();
        if(currentSelectedColor != COLORGAME.NULL)
        {
            spell.gameObject.SetActive(true);
            spell.color = colors.getColor(currentSelectedColor);
        } else
        {
            spell.gameObject.SetActive(false);
        }
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
    }

    public void defineColor()
    {
        currentSelectedColor = colors.defineColor(redSelected, greenSelected, blueSelected);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Foe>() != null)
        {
            if (collision.gameObject.GetComponent<Foe>().aggressive)
            {
                resetLevel();
            }
        }
    }

    void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
