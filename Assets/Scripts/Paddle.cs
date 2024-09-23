using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float ScreenWidthInUnits = 16f;
    [SerializeField] float MinX = 1f;
    [SerializeField] float MaxX = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float MousePosInUnits = Input.mousePosition.x / Screen.width * ScreenWidthInUnits;
        Vector2 paddlePos = new Vector2(MousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(MousePosInUnits, MinX, MaxX);
        transform.position = paddlePos;
    }
}

