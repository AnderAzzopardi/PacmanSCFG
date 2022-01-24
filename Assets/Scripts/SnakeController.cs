using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    [SerializeField] GameObject SnakeBody;
    public int BodyLength = 0;

    public void IncreaseBodyLength()
    {
        BodyLength++;
        Vector3 headPos = this.gameObject.transform.position;
        GameObject newBodyPart = Instantiate(SnakeBody, 
            new Vector3((headPos.x + BodyLength), headPos.y), Quaternion.identity);
        newBodyPart.transform.parent = this.gameObject.transform;
    }
}
