using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SheepGraze : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento das ovelhas
    public float grazingTime = 4f; // Tempo de pastagem antes de se mover para outro local
    public Collider pastureArea; // Collider representando a �rea de pastagem
    private Vector3 targetPosition; // Posi��o alvo dentro da �rea de pasto
    private bool isMoving = false; // Flag para verificar se a ovelha est� se movendo
    private bool shouldGraze = true;
    private SheepState sheepState;
    private SheepState.ShipState lastState;

    private void Start()
    {
        sheepState = GetComponent<SheepState>();
        // Inicializa a posi��o alvo dentro da �rea de pasto
        SetRandomTargetPosition();
    }

    private void FixedUpdate()
    {
        // Se a ovelha estiver se movendo, mova-a em dire��o � posi��o alvo
        if (isMoving && shouldGraze)
        {
            if (lastState != sheepState.GetSheepState())
            {
                SetSheepDirection(targetPosition);
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Se a ovelha estiver perto o suficiente da posi��o alvo, pare de se mover
            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                grazingTime = Random.Range(5.0f, 8.0f);
                sheepState.SetSheepState(SheepState.ShipState.Graze);
                // Inicia a contagem para a pr�xima movimenta��o ap�s o tempo de pastagem
                Invoke("SetRandomTargetPosition", grazingTime);
            }
        }
    }

    private void SetRandomTargetPosition()
    {
        // Obt�m uma posi��o aleat�ria dentro dos limites da �rea de pasto
        targetPosition = GetRandomPositionInPastureArea(pastureArea);
        SetSheepDirection(targetPosition);
        isMoving = true;
    }

    private Vector3 GetRandomPositionInPastureArea(Collider areaCollider)
    {
        // Obt�m os limites do colisor da �rea de pasto
        Vector3 center = areaCollider.bounds.center;
        Vector3 size = areaCollider.bounds.size;

        // Calcula uma posi��o aleat�ria dentro dos limites da �rea de pasto
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
        // Calcula a diferen�a entre as coordenadas X da posi��o alvo e da ovelha
        float deltaX = targetPos.x - transform.position.x;

        // Calcula a diferen�a entre as coordenadas Z da posi��o alvo e da ovelha
        float deltaZ = targetPos.z - transform.position.z;

        // Define a dire��o com base nas diferen�as
        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaZ) || Mathf.Abs(deltaZ) > Mathf.Abs(deltaX) + 1.5f) // Se a diferen�a em X for maior que a diferen�a em Z
        {
            // Define a dire��o como esquerda ou direita com base no sinal de deltaX
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
        else // Se a diferen�a em Z for maior ou igual � diferen�a em X
        {
            // Define a dire��o como para frente ou para tr�s com base no sinal de deltaZ
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
