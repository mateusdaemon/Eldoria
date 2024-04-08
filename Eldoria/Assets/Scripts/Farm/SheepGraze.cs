using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepGraze : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento das ovelhas
    public float grazingTime = 4f; // Tempo de pastagem antes de se mover para outro local
    public Collider pastureArea; // Collider representando a área de pastagem
    private Vector3 targetPosition; // Posição alvo dentro da área de pasto
    private bool isMoving = false; // Flag para verificar se a ovelha está se movendo
    private bool shouldGraze = true;

    private void Start()
    {
        // Inicializa a posição alvo dentro da área de pasto
        SetRandomTargetPosition();
    }

    private void FixedUpdate()
    {
        // Se a ovelha estiver se movendo, mova-a em direção à posição alvo
        if (isMoving && shouldGraze)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Se a ovelha estiver perto o suficiente da posição alvo, pare de se mover
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                // Inicia a contagem para a próxima movimentação após o tempo de pastagem
                Invoke("SetRandomTargetPosition", grazingTime);
            }
        }
    }

    private void SetRandomTargetPosition()
    {
        // Obtém uma posição aleatória dentro dos limites da área de pasto
        targetPosition = GetRandomPositionInPastureArea(pastureArea);
        isMoving = true;
    }

    private Vector3 GetRandomPositionInPastureArea(Collider areaCollider)
    {
        // Obtém os limites do colisor da área de pasto
        Vector3 center = areaCollider.bounds.center;
        Vector3 size = areaCollider.bounds.size;

        // Calcula uma posição aleatória dentro dos limites da área de pasto
        float randomX = Random.Range(center.x - size.x / 2, center.x + size.x / 2);
        float randomZ = Random.Range(center.z - size.z / 2, center.z + size.z / 2);

        return new Vector3(randomX, transform.position.y, randomZ);
    }

    public void Graze(bool graze)
    {
        shouldGraze = graze;
    }
}
