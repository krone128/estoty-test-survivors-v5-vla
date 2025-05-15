using System;
using System.Collections.Generic;
using Code.Gameplay.Lifetime.Behaviours;
using Code.Gameplay.Projectiles.Behaviours;
using Code.Gameplay.Projectiles.Services;
using Code.Gameplay.Teams.Behaviours;
using Code.Gameplay.UnitStats;
using Code.Gameplay.UnitStats.Behaviours;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Behaviour
{
    public class OrbitalProjectileSpawner : MonoBehaviour
    {
        [Inject] private IProjectileFactory _projectileFactory;

        [SerializeField] private Team _team;
        [SerializeField] private Stats _playerStats;
        
        private float _projectileUpdateInterval;
        private float _currentTime;
        
        private float _projectileCount;
        private float _maxProjectileCount;
        private float _projectileSpeed;
        private float _orbitRadius;
        
        private IDestroyNotify[] _activeProjectiles;
        private Transform[] _sockets;
        private Transform _socketRoot;
        
        public void Initialize(int projectileMaxCount, float speed, float orbitRadius, float projectileUpdateInterval)
        {
            _maxProjectileCount = projectileMaxCount;
            _projectileUpdateInterval = projectileUpdateInterval;
            _orbitRadius = orbitRadius;
            _projectileSpeed = speed;
            _projectileCount = 0;
            
            _activeProjectiles = new IDestroyNotify[projectileMaxCount];
            _sockets = new Transform[projectileMaxCount];
            
            SpawnSockets();
            SpawnInitialProjectiles();
        }

        private void Update()
        {
            UpdateRespawnedOrbitals();
            UpdateMovement();
        }

        private void UpdateMovement()
        {
            _socketRoot.Rotate(Vector3.forward, _projectileSpeed * Time.deltaTime, Space.Self);
        }

        private void UpdateRespawnedOrbitals()
        {
            if(_projectileCount >= _maxProjectileCount) return;
            
            _currentTime += Time.deltaTime;

            if (_currentTime < _projectileUpdateInterval) return;
            
            for (var i = 0; i < _maxProjectileCount; i++)
            {
                if (_activeProjectiles[i] != null) continue;
                SpawnProjectile(i);
                _currentTime -= _projectileUpdateInterval;
                if (_currentTime < _projectileUpdateInterval) return;
            }
        }

        private void SpawnProjectile(int orbitalIndex)
        {
            var projectile = _projectileFactory.SpawnOrbitalProjectile(_sockets[orbitalIndex], _team.Type,
                _playerStats.GetStat(StatType.Damage));

            var projectileComponent = projectile.GetComponent<IDestroyNotify>();
            _activeProjectiles[orbitalIndex] = projectileComponent;
            
            projectileComponent.OnDestroy += HandleProjectileDestroy;
                
            _projectileCount++;
            return;

            void HandleProjectileDestroy()
            {
                projectileComponent.OnDestroy -= HandleProjectileDestroy;
                _activeProjectiles[orbitalIndex] = null;
                _projectileCount--;
            }
        }

        private void SpawnInitialProjectiles()
        {
            for (var i = 0; i < _maxProjectileCount; i++) 
                SpawnProjectile(i);
        }

        private void SpawnSockets()
        {
            _socketRoot = new GameObject("OrbitalRoot").transform;
            _socketRoot.SetParent(transform);
            _socketRoot.localPosition = Vector3.zero;

            for (int i = 0; i < _maxProjectileCount; i++)
            {
                var orbitalSocket = new GameObject($"OrbitalSocket {i}").transform;
                var initialRotation = 360f / _maxProjectileCount * i;
                orbitalSocket.SetParent(_socketRoot.transform);
                orbitalSocket.localPosition = Quaternion.AngleAxis(initialRotation, Vector3.forward) * new Vector3(0, _orbitRadius, 0);
                _sockets[i] = orbitalSocket;
            }
        }

    }
}