using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(AudioSource))]
public class CatController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private FloatingJoystick variableJoystick;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private GameObject tears;
    [SerializeField] private Button cryBtn;
    private Animator _animator;
    private bool cry;

    private void Start()
    {
        variableJoystick = FindObjectOfType<FloatingJoystick>();
        _animator = GetComponent<Animator>();
        walkSound = GetComponent<AudioSource>();
        cryBtn = GameObject.Find("CrySound").GetComponent<Button>();
        cryBtn.onClick.AddListener(CryBanana);
        rb = GetComponent<Rigidbody>();
    }

    void CryBanana()
    {
        cry = !cry;
        if (cry)
        {
            tears.gameObject.SetActive(true);
        }
        else
        {
            tears.gameObject.SetActive(false);
        }
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        Vector3 movement = direction * speed * Time.fixedDeltaTime;
        rb.AddForce(movement, ForceMode.VelocityChange);

        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        if (rb.velocity.magnitude > 0.2f)
        {
            _animator.SetBool("play",true);
            walkSound.UnPause();
        }
        else
        {
            _animator.SetBool("play",false);
            walkSound.Pause();
        }
        
        if (direction.magnitude > 0.1f)
        {
            Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
            rb.rotation = Quaternion.Lerp(rb.rotation, toRotation, speed * Time.fixedDeltaTime);
        }
    }
}