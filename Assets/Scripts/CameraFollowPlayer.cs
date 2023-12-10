using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    private Transform player;
    private Vector3 animationOffset, startOffset, moveVector;
    private float transition = 0f;
    
    private void Awake()
    {
        // anh xa
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animationOffset = new Vector3(0, 2, 5);
        startOffset = transform.position - player.position; // khoang cach camera va nhan vat

    }

    // Update is called once per frame
    void Update()
    {
        moveVector = player.position + startOffset;
        moveVector.y = Mathf.Clamp(moveVector.y, 3f, 5f); // Camera di chuyển theo trục y

        // Không cần đặt moveVector.x = 0f;

        transform.position = moveVector;

        if (transition > 1f)
        {
            transform.position = moveVector;
        }
        else
        {
            transform.position = Vector3.Lerp(moveVector + animationOffset, moveVector, transition);
            transition += 0.2f * Time.deltaTime;
            transform.LookAt(player.position);
        }
    }

}
