using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    //private Rigidbody2D myRigid;

    private bool facingRight;

    private Animator myAnimator;

    //private bool attack;

    //private bool jumpAttack;

    //private bool slide;

    //private bool isGrounded;

    //private bool jump;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private Transform[] groundPoints;

    [SerializeField]
    private float groundRaidus;

    [SerializeField]
    private LayerMask whatIsGround;

    [SerializeField]
    private bool airControl;


    private Rigidbody2D MyRigid { get; set;}

    private bool Attack { get; set; }
    private bool Slide { get; set; }
    private bool Jump { get; set; }
    private bool Onground { get; set; }

    // Use this for initialization
    void Start() {
        MyRigid = GetComponent<Rigidbody2D>();

        myAnimator = GetComponent<Animator>();

        facingRight = true;
    }

    void Update() {
        HandleInputKey();
    }

    // Update is called once per frame
    void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");

        Onground = IsGround();

        HandelMovement(horizontal);

        Flip(horizontal);

        //HandleAttack();

        HandleLayer();

        //ResetValue();
    }

    //Handel move player
    void HandelMovement(float horizontal) {
        //if (myRigid.velocity.y < 0)
        //{
        //    myAnimator.SetBool("land", true);
        //}
        //if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (!isGrounded || airControl))
        //{
        //    myRigid.velocity = new Vector2(horizontal * movementSpeed, myRigid.velocity.y);
        //}
        //if (isGrounded && jump)
        //{
        //    isGrounded = false;
        //    myRigid.AddForce(new Vector2(0, jumpForce));
        //    myAnimator.SetTrigger("jump");
        //}
        //if(slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        //{
        //    myAnimator.SetBool("slide", true);
        //}
        //else if(!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide")){
        //    myAnimator.SetBool("slide", false);

        //}

        //myAnimator.SetFloat("speed", Mathf.Abs(horizontal));


        if (MyRigid.velocity.y < 0) {
            myAnimator.SetBool("land", true);
        }
        if (!Attack && !Slide && (!Onground || airControl)) {
            MyRigid.velocity = new Vector2(horizontal * movementSpeed, MyRigid.velocity.y);
        }

        if (Jump && MyRigid.velocity.y == 0)
        {
            MyRigid.AddForce(new Vector2(0, jumpForce));
        }
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));

    }

    //Flip face palyer
    void Flip(float horizontal) {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }

    //Handel player attack
    //void HandleAttack() {
    //    if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
    //    {
    //        myAnimator.SetTrigger("attack");
    //        myRigid.velocity = Vector2.zero;
    //    }
    //    if (jumpAttack && !isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumpAttack")) {
    //        myAnimator.SetBool("jumpAttack", true);
    //    }
    //    if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("JumpAttack")) {
    //        myAnimator.SetBool("jumpAttack", false);
    //    }

    //}

    //Handle input key 
    void HandleInputKey()
    {
        if (Input.GetKey(KeyCode.H))
        {
            //attack = true;
            //jumpAttack = true;

        }
        if (Input.GetKey(KeyCode.J)) {
            //slide = true;
        }
        if (Input.GetKey(KeyCode.K))
        {
            //jump = true;
        }
    }

    //void ResetValue() {
    //    attack = false;
    //    slide = false;
    //    jump = false;
    //    jumpAttack = false;
    //}

    private bool IsGround() {
        if (MyRigid.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colider = Physics2D.OverlapCircleAll(point.position, groundRaidus, whatIsGround);

                for (int i = 0; i < colider.Length; i++) {
                    if (colider[i].gameObject != gameObject)
                    {
                        //myAnimator.ResetTrigger("jump");
                        //myAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }


    private void HandleLayer() {
        if (!Onground)
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else {
            myAnimator.SetLayerWeight(1, 0);
        }
    }
}
