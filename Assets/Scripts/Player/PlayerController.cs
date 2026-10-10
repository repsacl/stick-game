using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Player's Color")]
    public Color playerColor;

    [Space]

    [Header("Move Controller")]
    public Animator anim;
    public Rigidbody2D rb;
    public float playerSpeed;
    
    [Space]

    [Header("Jump Controller")]
    public float jumpForce;
    public int extraJumpsValue;
    public Transform playerPos;
    public LayerMask ground;
    public float positionRadius;
    public bool isGrounded;
    public Vector2 jumpHeight;
    private int extraJumps;

    [Space]

    [Header("Gun Controller")]
    public Shooting ragdollShoot;

    //public bool isGround;


    [Space]

    [Header("Seconds To Wait")]
    public float secondsToWaitJump = 0.05f;

    [Space]

    [Header("Effects")]
    public ParticleSystem dust;
    public TrailRenderer trailRenderer;
    public GameObject goalEffeckt;
    public GameObject respawnImpactEffeck;

    [Space]

    [Header("RespawnPoint controller")]
    public Vector3 respawnPoint;

    private float moveInput;
    private bool jumped = false;
    private bool m_FacingRight = true;


    [Space]

    [Header("Skin Loader")]
    public CharcterDatabase charcterDB;
    public Sprite artworkSprite;

    [Space]

    public GameObject anchor;


    private static int selectedOption = 0;

    [HideInInspector]
    public MulitpleCamerafollow camFollow;
    private Camera cam;

    public string collisionTag;


    [HideInInspector] public TimeManager timeManager;


    public float timeRun;







    void Start()
    {
        camFollow = GameObject.Find("Main Camera").GetComponent<MulitpleCamerafollow>();

        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();

        for (int i = 0; i < colliders.Length; i++)
        {
            for (int k = i + 1; k < colliders.Length; k++)
            {
                Physics2D.IgnoreCollision(colliders[i], colliders[k]);
            }
        }

        camFollow.targets.Add(GetComponent<Transform>());

        extraJumps = extraJumpsValue;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        timeManager = FindObjectOfType<TimeManager>();
        timeManager.pIDManager.Add(GetComponent<PlayerUIIDManager>());
        
        //timeManager.playerTimeIds = 
        
        //timeManager.playerTimeIds.Add(GetComponent<PlayerUIIDManager>());
        //for (int i = 0; i < timeManager.playerTimeIds.Length; i++)
        //{
        //timeManager.playerTimeIds[i];
        //}
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(playerPos.position, positionRadius, ground);
        MoveInput();
        GroundInput();
    }

    void MoveInput()
    {
        rb.linearVelocity = new Vector2(moveInput * playerSpeed, rb.linearVelocity.y);
        anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));

        if (moveInput > 0f && !m_FacingRight)
        {
            Flip();
        }
        else if (moveInput < 0f && m_FacingRight)
        {
            Flip();
        }
    }

    void GroundInput()
    {

        if (isGrounded == true && jumped == true)
        {
            anim.SetTrigger("IsLanding");
            CreateDust();
            jumped = false;
            //moving = true;
            anim.SetBool("IsJumping", false);
        }

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
            //isGround = true;
            //anim.SetTrigger("IsLanding");
        }
    }

    void Flip()
    {
        m_FacingRight = !m_FacingRight;
        CreateDust();
    }

    public void Move(InputAction.CallbackContext context)
    {
        //CreateDust();
        moveInput = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded == true && extraJumps > 0)
        {
            FindObjectOfType<AudioManager>().Play("Jump2");
            StartCoroutine(jump());
        }
        else if (context.performed && extraJumps > 0)
        {
            FindObjectOfType<AudioManager>().Play("Jump2");
            StartCoroutine(jump());
        }
    }

    IEnumerator jump()
    {
        CreateDust();
        rb.linearVelocity = Vector2.up * jumpForce;
        extraJumps--;
        //FindObjectOfType<AudioManager>().Play("Jump");
        yield return new WaitForSeconds(secondsToWaitJump);
        anim.SetTrigger("isJumping");
        jumped = true;
        anim.SetBool("IsJumping", true);
        //isGround = false;
        //moving = false;
    }

    void CreateDust()
    {
        dust.Play();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Cheacker")
        {
            Instantiate(respawnImpactEffeck, transform.position, transform.rotation);
            respawnPoint = col.transform.position;
        }

        if(col.tag == collisionTag)
        {
            timeRun = GameObject.Find("EventSystem").GetComponent<GameManager>().timeStart;
            GameObject.Find("EventSystem").GetComponent<GameManager>().timeTest = timeRun;
            GetComponent<PlayerUIIDManager>().playerTime = timeRun;
            GameObject.Find("EventSystem").GetComponent<TimeManager>().playerTime.Add(timeRun);
            GameObject.Find("EventSystem").GetComponent<TimeManager>().Goal(GetComponent<PlayerUIIDManager>().playerID);

            camFollow.targets.Remove(GetComponent<Transform>());

            Instantiate(goalEffeckt, transform.position, transform.rotation);

            Destroy(anchor);

            GetComponent<LobbyMenu>().Pause();
        }
    }

    private void UpdtatedCharacter(int selectedOption)
    {
        Character character = charcterDB.GetCharacter(selectedOption);
        //artworkSprite.color = character.playerColor;

        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = character.playerColor;
        }
        //playerHealth.colorEffect();
        //trailRenderer.startColor = playerColor;
    }

    private static void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    void PlayerColor()
    {
        //playerColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));

        //SpriteRenderer colorbullet = this.ragdollShoot.bullet.GetComponent<SpriteRenderer>();
        //colorbullet.color = this.playerColor;

        SpriteRenderer[] renderers = this.anchor.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer rd in renderers)
        {
            rd.color = playerColor;

            //SpriteRenderer crd = child.AddComponent<SpriteRenderer>();
            //crd.sprite = rd.sprite;
            //crd.color = Color.black;
        }
        //trailRenderer.startColor = playerColor;

        //SpriteRenderer colorbullet = ragdollShoot.bullet.GetComponent<SpriteRenderer>();
        //colorbullet.color = this.playerColor;
    }
}
