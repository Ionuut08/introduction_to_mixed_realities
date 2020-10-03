using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject object1;
    public GameObject object2;
    public Animator animate;

    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance (object1.transform.position, object2.transform.position);
        
        if (distance <= 1)
        {
           animate.SetBool("cameraIsClose", true);
        } else {
            animate.SetBool("cameraIsClose", false);
        }
    }
}
