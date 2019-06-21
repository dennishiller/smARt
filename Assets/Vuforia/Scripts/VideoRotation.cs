using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoRotation : MonoBehaviour
{

    RaycastHit hit;
    Ray ray;
    GameObject imageTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            if (imageTarget.transform.rotation.x.Equals(90))
            {
                imageTarget.transform.rotation = Quaternion.Euler(0, 1, 0);
            }
            else
            {
                Debug.Log("yo");
                imageTarget.transform.rotation = Quaternion.Euler(90, 1, 0);
            }
        }
    }
}
