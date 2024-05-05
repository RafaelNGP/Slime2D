using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackWithMouse : MonoBehaviour
{
    public Rigidbody2D projectilePrefab; // Referência ao prefab do projétil
    public float projectileSpeed = 25f; // Velocidade do projétil

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica se o botão esquerdo do mouse foi pressionado
        {
            Vector3 mousePosition = Input.mousePosition; // Obtém a posição do mouse
            mousePosition.z = 10f; // Define uma profundidade para a conversão de coordenadas
            Vector2 target = Camera.main.ScreenToWorldPoint(mousePosition); // Converte para coordenadas do mundo

            Vector2 shootingDirection = (target - (Vector2)transform.position).normalized; // Calcula a direção

            // Instancia o projétil e define sua velocidade
            Rigidbody2D projectileInstance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectileInstance.velocity = shootingDirection * projectileSpeed;

            // Ajusta a rotação do projétil para corresponder à direção do tiro
            float angle = Mathf.Atan2(shootingDirection.y, shootingDirection.x) * Mathf.Rad2Deg -90f;
            projectileInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            // Destrói o projétil após 2 segundos
            Destroy(projectileInstance.gameObject, 2f);
        }
    }
}
