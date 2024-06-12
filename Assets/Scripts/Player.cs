using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float forceJump = 10;
    private Rigidbody2D rig;
    private Animator anim;
    public bool isJumping;
    public bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        jump();
    }

    void move(){
        UnityEngine.Vector3 movement = new UnityEngine.Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speed;

        if(Input.GetAxis("Horizontal") > 0f){
            anim.SetBool("run", true);
            transform.eulerAngles = new UnityEngine.Vector3(0f,0f,0f);
        }

        if(Input.GetAxis("Horizontal") < 0f){
            anim.SetBool("run", true);
            transform.eulerAngles = new UnityEngine.Vector3(0f,180f,0f);
            
        }

        if(Input.GetAxis("Horizontal") == 0f){
            anim.SetBool("run", false);
        }
    }

    void jump(){
        if(Input.GetButtonDown("Jump")){
            if(!isJumping){
                rig.AddForce(new UnityEngine.Vector2(0f, forceJump), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else{
                if(doubleJump){
                    rig.AddForce(new UnityEngine.Vector2(0f, forceJump), ForceMode2D.Impulse);
                doubleJump = false;
                }  
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            anim.SetBool("jump", false);
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = true;
        }
    }
}
