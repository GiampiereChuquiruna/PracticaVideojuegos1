using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPractica : MonoBehaviour
{
    public float velocity = 8, jumpForce = 10;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;


    const int QUIETO = 0;
    const int CAMINAR = 1;
    const int ATACAR = 2;
    const int CORRER = 3;
    const int SALTAR = 4;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Iniciando");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {  
        

        if(Input.GetKey(KeyCode.RightArrow)){
           
           sr.flipX= false;           
            if (Input.GetKey(KeyCode.X)){
               rb.velocity = new Vector2(17, rb.velocity.y);
               changeAnimation(CORRER);
            }
            else {
               rb.velocity = new Vector2(velocity, rb.velocity.y);
               changeAnimation(CAMINAR);
            }

           //animator.SetInteger("Estado", 1);
           
        }
        else if(Input.GetKey(KeyCode.Z)){
           rb.velocity = new Vector2(0, rb.velocity.y);
           //animator.SetInteger("Estado", 2);
           changeAnimation(ATACAR);
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
           
           sr.flipX= true;
           //animator.SetInteger("Estado", 1);
            if (Input.GetKey(KeyCode.X)){
               rb.velocity = new Vector2(-17, rb.velocity.y);
               changeAnimation(CORRER);
            }
            else {
               rb.velocity = new Vector2(velocity, rb.velocity.y);
               changeAnimation(CAMINAR);
            }
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
                rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                changeAnimation(SALTAR);
        }
        else{
                rb.velocity = new Vector2(0, rb.velocity.y);
                //animator.SetInteger("Estado", 0);
                changeAnimation(QUIETO);
            }
    }

    void OnCollisonEnter2D(Collision2D other){
        //Debug.Log(other.gameObject.name);
        if(other.gameObject.tag == "Enemy"){
           Debug.Log("Perdiste");
        }
    }    

    private void changeAnimation (int v){
        animator.SetInteger("Estado", v);
    }
}
