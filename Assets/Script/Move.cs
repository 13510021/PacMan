using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.35f;
    Vector2 dest = Vector2.zero;
    Collider2D cor2D;
    public AudioClip C;

    // Start is called before the first frame update
    void Start()
    {
        dest = transform.position;
        cor2D = GetComponent<Collider2D>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move closer to Destination
        Vector2 p = Vector2.MoveTowards(transform.position, dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);
        //BUG   float值有差值 出现差值后不能移动了
        if ((Vector2)transform.position == dest)
        {
            if (Input.GetKey(KeyCode.UpArrow) && validMove(Vector2.up))
                dest = (Vector2)transform.position + Vector2.up;
            
            if (Input.GetKey(KeyCode.RightArrow) && validMove(Vector2.right))
                dest = (Vector2)transform.position + Vector2.right;
            
            if (Input.GetKey(KeyCode.DownArrow) && validMove(Vector2.down))
                dest = (Vector2)transform.position + Vector2.down;
            
            if (Input.GetKey(KeyCode.LeftArrow) && validMove(Vector2.left))
                dest = (Vector2)transform.position + Vector2.left;
            
        }

        //bug 移动一会会旋转
        Vector2 dir = dest - (Vector2)transform.position;
        //print("dir.x" + dir.x);
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);

    }

    bool validMove(Vector2 dir)
    {
        //Cast line from 'next to Pac-Man' to 'Pac-Man'
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Linecast(pos + dir, pos);
        return (hit.collider == GetComponent<Collider2D>());
       

    }
}
