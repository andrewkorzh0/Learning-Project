using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum directions
{
    up,
    down,
    right,
    left,
    stay_b,
    stay_f,
    stay_r,
    stay_l
}

public class Movement : MonoBehaviour
{
    [SerializeField] float speed;
    Queue<directions> lockedSide = null;
    Queue<directions> directionOfMove;
    PlayerManager playerManager;
    GameObject player;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer; // delete when get left animation
   

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        playerManager = GameObject.FindGameObjectWithTag("PlayerManager").GetComponent<PlayerManager>();
    }

    /*
    
    notes: 
        horizontal idles


    */
    public directions stay_type = directions.stay_f;
    void FixedUpdate() // without Time.deltaTime
    {
        bool inputAvailable = false;
        directionOfMove = new Queue<directions>();
        if(playerManager.couldMove) //could I move?
        {
            float playerNewX = player.transform.position.x;
            float playerNewY = player.transform.position.y;
            
            if(Input.GetAxisRaw("Horizontal") == -1)
            {
                stay_type = directions.stay_l;
                bool could = true;
                if(lockedSide != null)
                {
                    foreach(directions i in lockedSide)
                    {
                        if(i == directions.left) could = false;
                    }
                }
                if(could)
                {                    
                    inputAvailable = true;
                    playerNewX -= speed;
                    directionOfMove.Enqueue(directions.left);
                }
            }
            if(Input.GetAxisRaw("Horizontal") == 1)
            {
                stay_type = directions.stay_r;
                bool could = true;
                if(lockedSide != null)
                {
                    foreach(directions i in lockedSide)
                    {
                        if(i == directions.right) could = false;
                    }
                }
                if(could)
                {                    
                    inputAvailable = true;
                    playerNewX += speed;
                    directionOfMove.Enqueue(directions.right);
                }
            }
            if(Input.GetAxisRaw("Vertical") == 1) 
            {
                stay_type = directions.stay_b;
                bool could = true;
                if(lockedSide != null)
                {
                    foreach(directions i in lockedSide)
                    {
                        if(i == directions.up) could = false;
                    }
                }
                if(could)
                {
                    inputAvailable = true;
                    playerNewY += speed;
                    directionOfMove.Enqueue(directions.up);
                }
            }
            if(Input.GetAxisRaw("Vertical") == -1)
            {
                stay_type = directions.stay_f;
                bool could = true;
                if(lockedSide != null)
                {
                    foreach(directions i in lockedSide)
                    {
                        if(i == directions.down) could = false;
                    }
                }
                if(could)
                {
                    inputAvailable = true;
                    playerNewY -= speed;
                    directionOfMove.Enqueue(directions.down);
                }
            }
            
            if(inputAvailable)
            rb.MovePosition( new Vector2(playerNewX, playerNewY) );
        }
        //animation
        directions animateDirection = stay_type;
        for (int i = 0; i < directionOfMove.Count; i++)
            animateDirection = directionOfMove.Dequeue();

        switch(animateDirection)
        {
            case directions.stay_f:
                if(playerManager.inAction == false) animator.SetInteger("state", 0); 
            break;

            case directions.stay_r:
                if(playerManager.inAction == false) animator.SetInteger("state", 3);
            break;
            
            case directions.stay_l:
                if(playerManager.inAction == false) animator.SetInteger("state", 5);
            break;

            case directions.stay_b:
                if(playerManager.inAction == false) animator.SetInteger("state", 0); 
            break;

            case directions.up:
                animator.SetInteger("state", 1);
            break;

            case directions.down:
                animator.SetInteger("state", 1);
            break;

            case directions.right:
                animator.SetInteger("state", 2);
            break;

            case directions.left:
                animator.SetInteger("state", 4); // edit to self number ************
            break;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        WallStoper(other);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        lockedSide = null;
    }

    public void WallStoper(Collision2D other)
    {
        lockedSide = new Queue<directions>();
        if (other.contacts.Length == 1)
            {
                // print("x" + collision.contacts[0].point + " < collider | player > " + player.transform.localPosition.x + GetComponent<Collider2D>().offset.x);
                // print("y" + collision.contacts[0].point + " < collider | player > " + player.transform.localPosition.y + GetComponent<Collider2D>().offset.y);
            }

        if (other.contacts.Length == 2)
        {
            ContactPoint2D[] contacts = other.contacts;
            if (contacts[0].point.y == contacts[1].point.y)
            {
                if (contacts[0].point.y > player.transform.localPosition.y + GetComponent<Collider2D>().offset.y)
                {
                        lockedSide.Enqueue(directions.up);
                }
                if (contacts[0].point.y < player.transform.localPosition.y + GetComponent<Collider2D>().offset.y)
                {
                        lockedSide.Enqueue(directions.down);
                }
            }
            if (contacts[0].point.x == contacts[1].point.x)
            {
                if (contacts[0].point.x > player.transform.localPosition.x + GetComponent<Collider2D>().offset.x)
                {
                    lockedSide.Enqueue(directions.right);
                }
                if (contacts[0].point.x < player.transform.localPosition.x + GetComponent<Collider2D>().offset.x)
                {
                    lockedSide.Enqueue(directions.left);
                }
            }
        }
        else if (other.contacts.Length >= 3)
        {
            /*
            string attention = "----------------3 contacts----------------\n";
            foreach(ContactPoint2D i in other.contacts)
            {
                attention += i + "\n";
            }
            attention += "----------------   ends   ----------------";
            print(attention);
            */
        }
    }
}