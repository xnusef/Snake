using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _direction = Vector2.up;
    private Vector2 _actualDirection;
    [HideInInspector] public List<Transform> Tails;
    [SerializeField] private Transform _tail;

    [SerializeField]private float defaultCooldown = 0.4f;
    private float movementCooldown;
    private float nextMove = 0f;

    void Awake()
    {
        this.Tails = new List<Transform>();
    }
    void ResetCooldown() => this.movementCooldown = this.defaultCooldown;

    void Update()
    {
        if (Time.time >= nextMove)
        {
            Move();
            this.nextMove += this.movementCooldown;
        }
    }

    void OnEnable()
    {
        GameManager.GM.PM = this;
        ResetCooldown();
        this.Tails.Add(this.transform);
        this.transform.position = new Vector3(0, 0, 0);
        nextMove = Time.time + this.movementCooldown;
        SetDir(Vector2.up);
    }

    void Move()
    {
        _actualDirection = this._direction;
        for (int i = Tails.Count - 1 ; i > 0 ; i--)
        {
            Tails[i].position = Tails[i - 1].position;
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + this._actualDirection.x,
            Mathf.Round(this.transform.position.y) + this._actualDirection.y,
            0f
        );
    }

    public void SetDir(Vector2 nextDirection)
    {
        if ((this._actualDirection + nextDirection) != Vector2.zero)
            this._direction = nextDirection;
    }

    private void Eat()
    {
        Transform snakeSegment = GameObject.Instantiate(_tail,
        this.Tails[Tails.Count - 1].position,
        Quaternion.identity,
        GameObject.Find("Player").GetComponent<Transform>()
        );

        Tails.Add(snakeSegment);

        GameManager.GM.ScoreScript.AddScore();
        if (this.movementCooldown > 0.05f)
                this.movementCooldown -= 0.005f;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
            Eat();
        if (other.tag == "Obstacle" || (other.tag == "Tail" && Tails.Count > 2))
            Lose();
    }
    
    void Lose()
    {
        for (int i = 1 ; i < Tails.Count ; i++)
            Destroy(Tails[i].gameObject);
        this.Tails.Clear();
        GameManager.GM.Lose();
    }
}