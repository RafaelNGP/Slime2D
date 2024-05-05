using TMPro;
using UnityEngine;

public class GameLogic : MonoBehaviour
{

    [SerializeField] float speed = 0.01f;
    [SerializeField] TextMeshProUGUI winText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")){
            Debug.Log("Collided with enemy");
            winText.gameObject.SetActive(true);
        }
    }

    private void Update()
    {
        float actualPosition = gameObject.transform.position.x;
        bool gameState = gameObject.GetComponent<Rigidbody2D>().simulated;

        if (actualPosition < -5.7f) actualPosition = -5.7f;
        if (actualPosition > 5.3f) actualPosition = 5.3f;
            if (Input.GetKey(KeyCode.Space))
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }

        if (actualPosition >= -5.7f && actualPosition <= 5.3f && !gameState)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
                float newPosition = actualPosition - speed;
                gameObject.transform.localPosition = new Vector3(newPosition, 4.46f, 0f);       
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                float newPosition = actualPosition + speed;
                gameObject.transform.localPosition = new Vector3(newPosition, 4.46f, 0f);
            }
        } 

        if (Input.GetKey(KeyCode.Escape)){
            winText.gameObject.SetActive(false);
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            gameObject.transform.localPosition = new Vector3(0, 4.46f, 0);
        }
    }
}
