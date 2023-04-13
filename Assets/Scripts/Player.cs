using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _projectileToSpawn;
    [SerializeField] Transform _projectileSpawnLocation;
    [SerializeField] GameObject[] Enemys;

    private int _maxLife = 100;
    private int _life;
    private bool enemyAttack = false;
    private float cooldown = 0;

    private void Start()
    {
        _life = _maxLife;
    }
    void Update()
    {
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);

        // Projectile
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject clone = Instantiate(_projectileToSpawn, _projectileSpawnLocation.transform.position, Quaternion.identity);
            clone.transform.forward = transform.forward;
        }

        // Shield
        if (Input.GetKeyDown(KeyCode.E))
            _shield.SetActive(!_shield.activeSelf);
        print(_life);
        print(cooldown);
        cooldown = Mathf.Max(0, cooldown - Time.deltaTime);
        if (enemyAttack)
        {
            UpdateLife();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && cooldown == 0)
        {
            enemyAttack = true;
            cooldown = 1;
        }
    }

    public void UpdateLife()
    {
        _life = Mathf.Max(0, _life-10);
        enemyAttack = false;
    }

}
