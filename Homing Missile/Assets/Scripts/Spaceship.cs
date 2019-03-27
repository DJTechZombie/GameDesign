using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour {

	public float speed = 1f;
    public GameObject speech;
    public AudioSource alienTalk;

	private void Update()
	{
		float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

		transform.Translate(horizontal, vertical, 0f);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitReact();
    }

    IEnumerator speechBubbleDisplay()
    {
        speech.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        speech.gameObject.SetActive(false);
    }

    public void hitReact()
    {
        StartCoroutine("speechBubbleDisplay");
        alienTalk.Play();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            hitReact();
        }
    }
}
