using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithMouse : MonoBehaviour
{
    public Rigidbody2D projectilePrefab; // Refer�ncia ao prefab do proj�til
    public float projectileSpeed = 25f; // Velocidade do proj�til

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o bot�o esquerdo do mouse foi pressionado
        {
            Vector3 mousePosition = Input.mousePosition; // Obt�m a posi��o do mouse
            mousePosition.z = 10f; // Define uma profundidade para a convers�o de coordenadas
            Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition); // Converte para coordenadas do mundo

            Vector2 shootingDirection = (target - (Vector2)transform.position).normalized; // Calcula a dire��o

            // Instancia o proj�til e define sua velocidade
            Rigidbody2D projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileInstance.velocity = shootingDirection * projectileSpeed;

            // Ajusta a rota��o do proj�til para corresponder � dire��o do tiro
            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg -90f;
            projectileInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Destr�i o proj�til ap�s 2 segundos
            Destroy(projectileInstance.gameObject, 2f);
        }
    }
}
