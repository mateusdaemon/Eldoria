using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepHerding : MonoBehaviour
{
    private GameObject parent;
    private GameObject playerRef;
    private bool runAway = false;
    private PlayerStats.Direction runAwayDir;
    private SheepState sheepState;
    private SheepGoInside sheepGoInside;

    public AudioSource sheepBea;
    public SheepGraze grazeBehavior;

    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
        sheepState = parent.GetComponent<SheepState>();
        sheepGoInside = parent.GetComponent<SheepGoInside>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (runAway)
        {
            RunAwaySheep();            
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRef = other.gameObject;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CancelInvoke("ResetGrazeBehavior");
            CancelInvoke("SetGrazeState");
            if (!sheepBea.isPlaying)
            {
                sheepBea.Play();
            }
            grazeBehavior.Graze(false);
            playerRef = other.gameObject;
            runAway = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRef = null;
            runAway = false;
            Invoke("SetGrazeState", 0.2f);
            Invoke("ResetGrazeBehavior", 1.5f);
        }
    }

    private void RunAwaySheep()
    {
        float dist = Vector3.Distance(this.transform.position, playerRef.transform.position);
        float posX = transform.position.x;
        float posZ = transform.position.z;
        Vector3 playerPos = playerRef.transform.position;
        Vector3 sheepPos = this.transform.position;

        // Determina para onde a ovelha deve correr com base na posição do jogador

        // Se o jogador estiver próximo horizontalmente
        if (Mathf.Abs(playerPos.x - sheepPos.x) <= 1.5f)
        {
            // Se o jogador estiver à frente da ovelha
            if (playerPos.z > sheepPos.z)
            {
                posZ -= dist; // Move a ovelha para trás
                runAwayDir = PlayerStats.Direction.Front;
            }
            else // Se o jogador estiver atrás da ovelha
            {
                posZ += dist; // Move a ovelha para frente
                runAwayDir = PlayerStats.Direction.Back;
            }
        }
        // Se o jogador estiver próximo verticalmente
        else if (Mathf.Abs(playerPos.z - sheepPos.z) <= 1.5f)
        {
            // Se o jogador estiver à esquerda da ovelha
            if (playerPos.x > sheepPos.x)
            {
                posX -= dist; // Move a ovelha para a esquerda
                runAwayDir = PlayerStats.Direction.Left;
            }
            else // Se o jogador estiver à direita da ovelha
            {
                posX += dist; // Move a ovelha para a direita
                runAwayDir = PlayerStats.Direction.Right;
            }
        }
        else // Se o jogador não estiver próximo horizontal ou verticalmente
        {
            // Determina a direção com base na posição do jogador em relação à ovelha
            if (playerPos.x > sheepPos.x)
            {
                if (playerPos.z > sheepPos.z)
                {
                    posX -= dist; // Move a ovelha para a esquerda
                    posZ -= dist; // Move a ovelha para trás
                    runAwayDir = PlayerStats.Direction.Front;
                }
                else
                {
                    posX -= dist; // Move a ovelha para a esquerda
                    posZ += dist; // Move a ovelha para frente
                    runAwayDir = PlayerStats.Direction.Back;
                }
            }
            else
            {
                if (playerPos.z > sheepPos.z)
                {
                    posX += dist; // Move a ovelha para a direita
                    posZ -= dist; // Move a ovelha para trás
                    runAwayDir = PlayerStats.Direction.Front;
                }
                else
                {
                    posX += dist; // Move a ovelha para a direita
                    posZ += dist; // Move a ovelha para frente
                    runAwayDir = PlayerStats.Direction.Back;
                }
            }
        }

        Vector3 target = new Vector3(posX, 0, posZ);

        OrientSheepAnim();

        parent.transform.position = Vector3.MoveTowards(transform.position, target, 0.1f);
    }

    private void OrientSheepAnim()
    {
        switch (runAwayDir)
        {
            case PlayerStats.Direction.Right:
                sheepState.SetSheepState(SheepState.ShipState.GoRight);
                break;
            case PlayerStats.Direction.Left:
                sheepState.SetSheepState(SheepState.ShipState.GoLeft);
                break;
            case PlayerStats.Direction.Front:
                sheepState.SetSheepState(SheepState.ShipState.GoFront);
                break;
            case PlayerStats.Direction.Back:
                sheepState.SetSheepState(SheepState.ShipState.GoBack);
                break;
            default:
                break;
        }
    }

    private void ResetGrazeBehavior()
    {
        if (!sheepGoInside.GoInside())
        {
            grazeBehavior.Graze(true);
        }
    }

    private void SetGrazeState()
    {
        sheepState.SetSheepState(SheepState.ShipState.Graze);
    }
}
