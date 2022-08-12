using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontrole : MonoBehaviour
{

    public Animator anim;

    public float playerspeed;
    public float smoothrotationtime=0.25f;

  
    // ref 
    float currentvelocity;
    float speedvelocity;

    float currentspeed;

    Transform cameratransform;
    // Start is called before the first frame update
    void Start()
    {
        cameratransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        playermove();
    }

    void playermove()
    {
      
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector2 inputdir = input.normalized;

        if (inputdir != Vector2.zero)
        {
            float roation =  Mathf.Atan2(inputdir.x, inputdir.y) * Mathf.Rad2Deg +cameratransform.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, roation, ref currentvelocity,smoothrotationtime);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
        float targetspeed = playerspeed * inputdir.magnitude;
        currentspeed = Mathf.SmoothDamp(currentspeed, targetspeed, ref speedvelocity, 0.1f);
        transform.Translate(transform.forward * currentspeed* Time.deltaTime, Space.World);



    }


}
