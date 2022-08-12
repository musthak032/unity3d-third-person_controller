using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cmfollow : MonoBehaviour
{
    //cam roation control
   public float Yaxis;
   public float Xaxis;
   public float rotationsensitivity;

    //cam follow player
    public Transform target;
    public float zdistance;

    public float rotationmin;
    public float rotationmax;

    //smoth
    public float smoothturntime=0.12f;
    Vector3 targetrotation;
    //ref
    Vector3 currentvel;


    
    void Start()
    {
        
    }
    void follow()
    {
        Yaxis += Input.GetAxis("Mouse X")*rotationsensitivity;
        Xaxis -= Input.GetAxis("Mouse Y")*rotationsensitivity;

        Xaxis = Mathf.Clamp(Xaxis, rotationmin, rotationmax);

        targetrotation = Vector3.SmoothDamp(targetrotation, new Vector3(Xaxis, Yaxis), ref currentvel, smoothturntime);
        transform.eulerAngles = targetrotation;

        //follow the player
        transform.position = target.position - transform.forward * zdistance;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        follow();
    }


}
