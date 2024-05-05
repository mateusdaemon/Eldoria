using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SheepGraze : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento das ovelhas
    public float grazingTime = 4f; // Tempo de pastagem antes de se mover para outro local
    public Collider pastureArea; // Collider representando a área de pastagem
    private Vector3 targetPosition; // Posição alvo dentro da área de pasto
    private bool isMoving = false; // Flag para verificar se a ovelha está se movendo
    private bool shouldGraze = true;
    private SheepState sheepState;
    private SheepState.ShipState lastState;

    private void Start()
    {
        sheepState = GetComponent<SheepState>();
        // Inicializa a posição alvo dentro da área de pasto
        SetRandomTargetPosition();
    }

    private void FixedUpdate()
    {
        // Se a ovelha estiver se movendo, mova-a em direção à posição alvo
        if (isMoving && shouldGraze)
        {
            if (lastState != sheepState.GetSheepState())
            {
                SetSheepDirection(targetPosition);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Se a ovelha estiver perto o suficiente da posição alvo, pare de se mover
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                grazingTime = Random.Range(5.0f, 8.0f);
                sheepState.SetSheepState(SheepState.ShipState.Graze);
                // Inicia a contagem para a próxima movimentação após o tempo de pastagem
                Invoke("SetRandomTargetPosition", grazingTime);
            }
        }
    }

    private void SetRandomTargetPosition()
    {
        // Obtém uma posição aleatória dentro dos limites da área de pasto
        targetPosition = GetRandomPositionInPastureArea(pastureArea);
        SetSheepDirection(targetPosition);
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

    private void SetSheepDirection(Vector3 targetPos)
    {
        // Calcula a diferença entre as coordenadas X da posição alvo e da ovelha
        float deltaX = targetPos.x - transform.position.x;

        // Calcula a diferença entre as coordenadas Z da posição alvo e da ovelha
        float deltaZ = targetPos.z - transform.position.z;

        // Define a direção com base nas diferenças
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaZ) || Mathf.Abs(deltaZ) > Mathf.Abs(deltaX) + 1.5f) // Se a diferença em X for maior que a diferença em Z
        {
            // Define a direção como esquerda ou direita com base no sinal de deltaX
            if (deltaX > 0)
            {
                sheepState.SetSheepState(SheepState.ShipState.GoRight);
                lastState = SheepState.ShipState.GoRight;
            }
            else
            {
                sheepState.SetSheepState(SheepState.ShipState.GoLeft);
                lastState = SheepState.ShipState.GoLeft;
            }
        }
        else // Se a diferença em Z for maior ou igual à diferença em X
        {
            // Define a direção como para frente ou para trás com base no sinal de deltaZ
            if (deltaZ > 0)
            {
                sheepState.SetSheepState(SheepState.ShipState.GoBack);
                lastState = SheepState.ShipState.GoBack;
            }
            else
            {
                sheepState.SetSheepState(SheepState.ShipState.GoFront);
                lastState = SheepState.ShipState.GoFront;
            }
        }
    }
}
