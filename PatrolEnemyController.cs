using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatrolEnemyController : MonoBehaviour
{
    public GameObject target;

    private SpriteRenderer spriteRenderer;    
    private float moveSpeed = 6.5f;
    private bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeColor(new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isActive)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
            transform.Rotate(0f, 0f, (transform.rotation.z + 15f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        ShurikenController shuriken = collision.gameObject.GetComponent<ShurikenController>();

        if (player != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (shuriken != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            Activate();
        }
    }

    private void Activate()
    {
        ChangeColor(new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f));
        isActive = true;
    }

    private void ChangeColor(Color color)
    {
        spriteRenderer.color = color;
    }
}
