using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        // Certifique-se de que o Rigidbody2D está obtido corretamente
        player = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Define a velocidade diretamente, sem usar força
        player.velocity = new Vector2(moveHorizontal * speed, moveVertical * speed);
    }
}
