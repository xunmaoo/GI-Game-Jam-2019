using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    //This is the script that control player move.
    [SerializeField] float runSpeed = 5f;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    Vector2 directionForAnim;
    public bool isHome = false;//we start to be awake
    public static Player instance;
    public string areaTransitionName;
    

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        //
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        directionForAnim = Vector2.zero;//face front
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Debug.Log(directionForAnim);
        Debug.Log(transform.position);
    }




    //Run
    private void Run()
    {
        //change to oppsite status of isHome
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHome = !isHome;
            StartCoroutine(returningHome());
            
        }
        float controlThrowX = Input.GetAxisRaw("Horizontal");
        float controlThrowY = Input.GetAxisRaw("Vertical");

        if (isHome)
        {
           
            return;
            
        }
        else if (!isHome)
        {
            

            //value is between -1 to 1.
            // Vector2 playerVelocity = new Vector2(myRigidBody.velocity.x, myRigidBody.velocity.y);
            // if (controlThrowX != 0)
            // {
            //    playerVelocity = new Vector2(controlThrowX * runSpeed
            //        , myRigidBody.velocity.y);
            // }
            // else if (controlThrowY != 0)
            // {
            //     playerVelocity = new Vector2(myRigidBody.velocity.x
            //         , controlThrowY * runSpeed);
            // }
            // I have no idea why but if I separate these two my player will slip away

            Vector2 playerVelocity = new Vector2(controlThrowX * runSpeed, controlThrowY * runSpeed);

            myRigidBody.velocity = playerVelocity;
            //
            if (directionForAnim.x != 0 || directionForAnim.y != 0)
            {
                AnimateMovement(directionForAnim);
            }
            else
            {//set back to layer 0
                myAnimator.SetLayerWeight(2, 0);
                myAnimator.SetLayerWeight(1, 0);
                myAnimator.SetLayerWeight(0, 1);

            }

        }

        
        SetupDirectionAnim(controlThrowX, controlThrowY);

    }

    IEnumerator returningHome()
    {
        yield return new WaitForSeconds(1);
        myAnimator.SetLayerWeight(2, 1);//change layer
    }

    //we set up directionForAnim for animation
    private void SetupDirectionAnim(float controlThrowX, float controlThrowY)
    {
        //directionForAnim = new Vector2(Mathf.Sign(controlThrowX), Mathf.Sign(controlThrowY));
        //
        if (controlThrowY > 0)
        {
            directionForAnim = Vector2.up;
        }
        else if (controlThrowY < 0)
        {
            directionForAnim = Vector2.down;
        }
        else if (controlThrowX > 0)
        {
            directionForAnim = Vector2.right;
        }
        else if (controlThrowX < 0)
        {
            directionForAnim = Vector2.left;
        }
        else
        {
            directionForAnim = Vector2.zero;
        }
    }

    //Call the animation that we want depends on movement.
    private void AnimateMovement(Vector2 directionForAnim)
    {
        //we have three layers!
        //standing, walking and stay home

        myAnimator.SetLayerWeight(1, 1);//first 1 for layer 1, second for weight 1
        //animator.SetLayerWeight(0, 0);
        myAnimator.SetLayerWeight(2, 0);

        myAnimator.SetFloat("x", directionForAnim.x);
        myAnimator.SetFloat("y", directionForAnim.y);
    }
}
