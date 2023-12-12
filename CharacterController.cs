using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{

    Rigidbody2D rigidbodySelf;

    public Sprite[] walksLeft;
    public Sprite standLeft;
    public Sprite[] walksRight;
    public Sprite standRight;
    float time = 0;
    float walkingGap = 0.25f;
    int index = 0;

    public bool controlling = true;

    public float walkSpeed = 100f;
    public float jumpSpeed = 100f;
    public float maxSpeed = 300f;
    public float maxSpeedSave;
    public float iceSpeed = 500f;

    public bool jumped;
    public AudioSource jumpSound;

    public float accel = 0.5f;
    public bool onIce = false;
    public float horizentalDir;

    public bool onChangingGravity = false;
    public float changedGravity;

    bool onWallJump = false;
    float dirWallJump = 0;
    float xPowerWallJump = 10000f;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == "snowFloor")
            return;

        if (collider.tag == "floor" || collider.gameObject.layer == 8)
            GetComponent<BoxCollider2D>().isTrigger = true;

        if (collider.tag == "walljump")
        {
            onWallJump = true;
            if(collider.transform.localRotation.y == 1f)
                dirWallJump = xPowerWallJump;
            else
                dirWallJump = xPowerWallJump * -1;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.name == "snowFloor")
            return;

        if (collider.tag == "floor"|| collider.gameObject.layer == 8)
            GetComponent<BoxCollider2D>().isTrigger = false;

        if (collider.tag == "walljump")
        {
            onWallJump = false;
        }
    }

    void Start()
    {
        rigidbodySelf = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
        if (controlling == false)
            return;

        // walking animation
        startWalkingAnimationWhenKeyDown();
        playWalkingAnimation(horizentalDir);
        endWalkingAnimationWhenKeyUp();


    }
        
    void FixedUpdate()
    {
        if (controlling == false)
            return;

        // phisics options of stage concept
        applyChangedGravityWhenOnit();
        jumpOnWallWhenKeyDown();

        // controlling
        horizentalDir = Input.GetAxisRaw("Horizontal");
        addHorizentalForceToCharacterWhenKeyPressing();
        addVerticalForceToCharacterWhenKeyDown();

        // jump only once 
        resetJumpedSwchWhenCharacterOnGround();
    }

    void startWalkingAnimationWhenKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GetComponent<Image>().sprite = walksLeft[0];
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GetComponent<Image>().sprite = walksRight[0];
        }
    }

    void playWalkingAnimation(float dir)
    {
        time += Time.deltaTime;
        if (time >= walkingGap)
        {
            time = 0;
            index = 1 - index;
            if (dir == -1)
            {
                GetComponent<Image>().sprite = walksLeft[index];
            }
            else if (dir == 1)
            {
                GetComponent<Image>().sprite = walksRight[index];
            }
        }
    }

    void endWalkingAnimationWhenKeyUp()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.RightArrow))
                return;
            GetComponent<Image>().sprite = standLeft;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
                return;
            GetComponent<Image>().sprite = standRight;
        }
    }
        


    void addHorizentalForceToCharacterWhenKeyPressing()
    {
        ignoreDoubleKeyPressing();

        setMaxSpeedHigherWhenOnIce();

        rigidbodySelf.AddForce(Vector2.right * horizentalDir * walkSpeed, ForceMode2D.Impulse);
        if (rigidbodySelf.velocity.x > maxSpeed)
        {//오른쪽
            rigidbodySelf.velocity = new Vector2(maxSpeed, rigidbodySelf.velocity.y);//y값을 0으로 잡으면 공중에서 멈춰버림
        }
        else if (rigidbodySelf.velocity.x < maxSpeed * (-1))
        {//왼쪽
            rigidbodySelf.velocity = new Vector2(maxSpeed * (-1), rigidbodySelf.velocity.y);
        }

        addFrictionForce();
    }

    void ignoreDoubleKeyPressing()
    {
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            horizentalDir = 0;
            rigidbodySelf.velocity = new Vector2(0, rigidbodySelf.velocity.y);
        }
    }

    void setMaxSpeedHigherWhenOnIce()
    {
        if (onIce)
        {
            maxSpeed = iceSpeed;
        }
    }

    void addFrictionForce()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            if (onIce) { return; }
            rigidbodySelf.velocity = new Vector2(rigidbodySelf.velocity.normalized.x * 0.5f, rigidbodySelf.velocity.y);
        }
    }

    void jumpOnWallWhenKeyDown()
    {
        if (onWallJump == true && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Space)))
        {
            onWallJump = false;
            rigidbodySelf.velocity = Vector2.zero;
            Vector2 up = new Vector2(dirWallJump, jumpSpeed);
            rigidbodySelf.AddForce(up, ForceMode2D.Impulse);

            return;
        }
    }

    void addVerticalForceToCharacterWhenKeyDown()
    {
        if (jumped == false && (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.Space)))
        {
            if (jumped == true)
                return;

            jumped = true;
            jumpSound.Play();
            jumped = true;
            rigidbodySelf.velocity = Vector2.zero;
            jumped = true;
            Vector2 up = new Vector2(0, jumpSpeed);
            jumped = true;
            rigidbodySelf.AddForce(up, ForceMode2D.Impulse);
            jumped = true;
        }
    }


    void resetJumpedSwchWhenCharacterOnGround()
    {
        // ban jumping when still jumping
        if (rigidbodySelf.velocity.y >= 0)
            return;

        float yPos = -60f;
        float len = 5;
        Vector3 down = new Vector3(0, -len, 0);

        Debug.DrawRay(rigidbodySelf.position + new Vector2(0f, yPos), down, Color.red);
        Debug.DrawRay(rigidbodySelf.position + new Vector2(-36f, yPos), down, Color.red);
        Debug.DrawRay(rigidbodySelf.position + new Vector2(36f, yPos), down, Color.red);

        RaycastHit2D rayHit = Physics2D.Raycast(rigidbodySelf.position + new Vector2(0f, yPos), down, len, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitLeft = Physics2D.Raycast(rigidbodySelf.position + new Vector2(-36f, yPos), down, len, LayerMask.GetMask("Platform"));
        RaycastHit2D rayHitRight = Physics2D.Raycast(rigidbodySelf.position + new Vector2(36f, yPos), down, len, LayerMask.GetMask("Platform"));

        resetJumpSwchWhenRaycastHittedGround(rayHit);
        resetJumpSwchWhenRaycastHittedGround(rayHitLeft);
        resetJumpSwchWhenRaycastHittedGround(rayHitRight);

    }

    void resetJumpSwchWhenRaycastHittedGround(RaycastHit2D rayHit)
    {
        if (rayHit.transform == null)
            return;

        if (rayHit.distance < 55f)
        {
            jumped = false;
            if (rayHit.transform.tag == "ice")
            {
                onIce = true;
            }
            else
            {
                maxSpeed = maxSpeedSave;
                onIce = false;
            }
        }
    }

    void applyChangedGravityWhenOnit()
    {
        if (onChangingGravity)
        {
            rigidbodySelf.gravityScale = changedGravity;
        }
        else
        {
            rigidbodySelf.gravityScale = 200f;
        }
    }

    public void stopCharacter()
    {
        GetComponent<Image>().sprite = standRight;
        rigidbodySelf.velocity = new Vector2(rigidbodySelf.velocity.normalized.x * 0.5f, rigidbodySelf.velocity.y);
    }


}
