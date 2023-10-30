using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow : MonoBehaviour
{
    private float speed = 0.01f;
    // Start is called before the first frame update
    void Awake()
    {
        GameStateManager.Instance.OnPauseChange += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnPauseChange -= OnGameStateChanged; 
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Core").transform.position, speed);
    }
    private void OnGameStateChanged(GameState state)
    {
        enabled = state == GameState.Gameplay;
    }
}
