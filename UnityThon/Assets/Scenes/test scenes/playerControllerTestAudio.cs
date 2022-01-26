using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControllerTestAudio : MonoBehaviour
{
    public float speed=10;
    public AudioClip moving;
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody=this.GetComponent<Rigidbody>();
        _audioSource=this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed;
        float z = Input.GetAxis("Vertical") * speed;
        _rigidbody.AddForce(x,0,z);
        if(!_rigidbody.IsSleeping()&&!_audioSource.isPlaying)_audioSource.PlayOneShot(moving);//そして既に再生中なら重ねて再生しない
        else if(_rigidbody.IsSleeping())_audioSource.Stop();
    }
}
