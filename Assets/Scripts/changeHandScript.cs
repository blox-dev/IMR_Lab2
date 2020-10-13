using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeHandScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject chalk;
    private GameObject leftHand;
    private GameObject rightHand;
    void Start()
    {
        leftHand = GameObject.Find("leftHandContainer");
        rightHand = GameObject.Find("rightHandContainer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if(chalk.transform.parent == leftHand.transform)
            {
                chalk.transform.SetParent(rightHand.transform);
                chalk.transform.position = rightHand.transform.position;
            }
            else
            {
                chalk.transform.SetParent(leftHand.transform);
                chalk.transform.position = leftHand.transform.position;
            }
            Debug.Log(chalk.transform.parent);
        }
    }
}
