using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Death : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Die();
            Restart();
        }
    }
    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void Restart()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().name));

    }
    IEnumerator LoadLevel(string levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }

}
