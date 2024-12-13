using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    private float _playerAwarenessDistance = 5f; // Default value, can be adjusted in Inspector.

    private Transform _player;

    private void Awake()
    {
        // Find the PlayerControls component and get the Transform.
        _player = FindObjectOfType<PlayerControls>()?.transform;
        if (_player == null)
        {
            Debug.LogError("Player not found! Ensure there is a GameObject with a PlayerControls component in the scene.");
        }
    }

    private void Update()
    {
        if (_player == null)
        {
            Debug.LogWarning("Player Transform is null. Awareness logic skipped.");
            return;
        }

        // Calculate the vector from the enemy to the player.
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        // Log for debugging purposes.
        Debug.Log($"Enemy Position: {transform.position}");
        Debug.Log($"Player Position: {_player.position}");
        Debug.Log($"Distance to Player: {enemyToPlayerVector.magnitude}");
        Debug.Log($"Direction to Player: {DirectionToPlayer}");

        // Check if the player is within awareness distance.
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {
            AwareOfPlayer = true;
            Debug.Log("Aware of Player!");
        }
        else
        {
            AwareOfPlayer = false;
            Debug.Log("Player out of range.");
        }
    }

    // Visualize the awareness distance in the Scene view.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _playerAwarenessDistance);
    }
}
