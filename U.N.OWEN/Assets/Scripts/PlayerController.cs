using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    // player movement
    [SerializeField] float speed;
    public bool isHome = false;//we start with not being home
    private Rigidbody2D rb;
    private Vector2 moveVelocity;

    public Animator animator;// to access the animates

    //helper for check direction
    private float dirHorizontal;
    private float dirVertical;
    private Vector2 direction;

    //for scene loading
    public static PlayerController instance;
    public string areaTransitionName = "1-1-1";


    private void Start()
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
        
        //initialization
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.zero;//face forward.
        animator = GetComponent<Animator>();
       

    }

    private void Update()
    {

        //change to oppsite status of isHome
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isHome = !isHome;
        }
        Run();

    }

    //if isHome state is on, we dont run, this function also dealed with this situation
    private void Run()
    {
        if (isHome)
        {
            animator.SetLayerWeight(2, 1);
        }
        else if (!isHome)
        {
            if (direction.x != 0 || direction.y != 0)
            {
                AnimateMovement(direction);
            }
            else
            {//set back to layer 0
                animator.SetLayerWeight(2, 0);
                animator.SetLayerWeight(1, 0);
                animator.SetLayerWeight(0, 1);

            }

        }

        //direction
        dirHorizontal = Input.GetAxisRaw("Horizontal");
        dirVertical = Input.GetAxisRaw("Vertical");
        Vector2 moveInput = new Vector2(dirHorizontal, dirVertical);
        moveVelocity = moveInput * speed;

        if (dirVertical == 1)
        {
            direction = Vector2.up;
        }
        else if (dirVertical == -1)
        {
            direction = Vector2.down;
        }
        else if (dirHorizontal == 1)
        {
            direction = Vector2.right;
        }
        else if (dirHorizontal == -1)
        {
            direction = Vector2.left;
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (!isHome)
        {
            rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
          
        }
        else//in home
        {//i change health a little bit here
        
        }
    }
    
    public void AnimateMovement(Vector2 direction)
    {
        //we have three layers!
        //standing, walking and stay home
       
        animator.SetLayerWeight( 1 , 1 );//first 1 for layer 1, second for weight 1
        //animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(2, 0);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

    }
}


