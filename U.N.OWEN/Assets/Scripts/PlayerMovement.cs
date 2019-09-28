using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal, vertical;
    public float speed = 5f;

    public Animator anim;

    public static bool playerLocked = false;

    private int playerDirection = 0;

    public GameObject Bullet;

    private bool isWalking = false;
    public AudioSource walkSound;
    public GameObject gunSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) playerDirection = 1;
        else if (Input.GetKeyDown(KeyCode.D)) playerDirection = 2;
        else if (Input.GetKeyDown(KeyCode.S)) playerDirection = 3;
        else if (Input.GetKeyDown(KeyCode.A)) playerDirection = 4;


        if (playerLocked == false)
        {
            horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            anim.SetFloat("x", horizontal);
            anim.SetFloat("y", vertical);

            transform.position = new Vector2(transform.position.x + horizontal, transform.position.y + vertical);

            PlayerAttack();
            WalkSound();
        }
    }

    void PlayerAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Instantiate a bullet
            GameObject created_bullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity) as GameObject;
            created_bullet.GetComponent<Bullet>().direction = playerDirection;

            if (!gunSound.GetComponent<AudioSource>().isPlaying)
            {
                gunSound.GetComponent<AudioSource>().Play();
            }
        }
    }

    void WalkSound()
    {
        isWalking = (horizontal != 0 || vertical != 0);

        if (isWalking)
        {
            if (!walkSound.isPlaying)
            {
                walkSound.Play();
            }
        }
        else walkSound.Stop();
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    // player movement
    [SerializeField] float speed;
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

        Run();

    }

    //if isHome state is on, we dont run, this function also dealed with this situation
    private void Run()
    {

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

    }

    public void AnimateMovement(Vector2 direction)
    {
        //we have three layers!
        //standing, walking and stay home

        animator.SetLayerWeight(1, 1);//first 1 for layer 1, second for weight 1
        //animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(2, 0);

        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);

    }
}
*/
