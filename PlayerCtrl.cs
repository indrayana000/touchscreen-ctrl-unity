using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    public float moveSpeed = 300;

    public float jumpForce = 10f;

    public GameObject character;

    private Rigidbody2D characterBody;
    private float ScreenWidth;

    Animator Animation;
    // Start is called before the first frame update
    void Start()
    {
        ScreenWidth = Screen.width;
        characterBody = character.GetComponent<Rigidbody2D>();
        Animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount) {
            if (Input.GetTouch (i).position.x > ScreenWidth / 2){
                
                //move right
                RunCharacter (1.0f);

                //mengambil animasi
                if (Animation.GetCurrentAnimatorStateInfo (0).IsName ("idle_cat")) {
                    Animation.SetTrigger ("run");
                }
            }

            if (Input.GetTouch (i).position.x < ScreenWidth / 2){

                //RunCharacter (-1.0f); -> move left

                //jump
                //characterBody.AddForce(Vector3.up * jumpHeight);
                //NumberJumps += 1;

                characterBody.AddForce(new Vector2(0f,jumpForce), ForceMode2D.Force);
            }
            ++i;
        }
    }

    // fungsi berhenti pada animator
    void berhenti(){
        Animation.SetTrigger ("stop");
    }

    void FixedUpdate(){
        #if UNITY_EDITOR
        RunCharacter (Input. GetAxis("Horizontal"));
        #endif
    }

    private void RunCharacter (float horizontalInput){
        characterBody.AddForce(new Vector2(horizontalInput * moveSpeed * Time.deltaTime, 0));
    }
}
