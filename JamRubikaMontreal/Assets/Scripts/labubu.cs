using System;
using UnityEngine;

public class labubu : MonoBehaviour
{
    public bool isWorking = false;

    public AudioManager _audio;
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private ParticleSystem Explosion;

    public GameObject unpackLabubu;
    public GameObject packedLabubu;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("labubu"))
        {
            Explosion.Play();
            _audio.Play("SFX_Collision");
            rb.AddExplosionForce(300f, transform.position, 5f,3f,ForceMode.Force);
        }
    }

    public void PackLabubu()
    {
        unpackLabubu.SetActive(false);
        packedLabubu.SetActive(true);
    }
    
    public void Start()
    {
        _audio = GameObject.Find("AUDIO_MANAGER").GetComponent<AudioManager>();
    }
}
