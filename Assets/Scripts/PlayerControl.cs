using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private bool canJump;
    [SerializeField] float force = 5;
    [SerializeField] private AsteroidGameManager asteroidGameManager;
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioClip sfxJump, sfxHit;
    [SerializeField] Text textInfo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Jump();
            NoJump();
        }
    }

    public void Jump()
    {
        if (canJump)
        {
            sfx.clip = sfxJump;
            sfx.Play();
            GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
            canJump = false;
        }
    }

    public void NoJump()
    {
        canJump = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sphere"))
        {
            LoseScore(other);
        }
    }
    public void LoseScore(Collider other)
    {
        asteroidGameManager.Score--;
        sfx.clip = sfxHit;
        sfx.Play();
        other.gameObject.SetActive(false);
    }
}
