using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    public float Speed = 4f;
    public Vector2 Velocity = Vector2.zero;
    private Transform playerTransform;

    private void Awake()
    {
        playerTransform = transform;
    }

    private void Update()
    {
        Vector2 _moveAmount = Vector2.zero;
        if(Input.GetAxisRaw("Vertical") > 0.1f)
        {
            _moveAmount.y = Speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Vertical") < - 0.1f)
        {
            _moveAmount.y = Speed * Input.GetAxisRaw("Vertical") * Time.deltaTime;
        }

        if (Input.GetAxisRaw("Horizontal") > 0.1f)
        {
            _moveAmount.x = Speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal") < -0.1f)
        {
            _moveAmount.x = Speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }
        Velocity = _moveAmount;
        playerTransform.Translate(_moveAmount);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
