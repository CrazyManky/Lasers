using System.Collections.Generic;
using _Project.Configs;
using UnityEngine;

namespace _Project.Screpts.GamePlay
{
    [RequireComponent(typeof(LineRenderer))]
    [RequireComponent(typeof(RotationComponent))]
    public class LaserReflection : MonoBehaviour
    {
        [SerializeField] private LaserConfig _laserConfig;
        [SerializeField] private Transform laserStartPoint;
        [SerializeField] private float laserLength = 100f;
        [SerializeField] private int maxReflections = 10;
        [SerializeField] private LineRenderer lineRenderer;

        private Vector2 direction;
        private List<Vector2> laserPositions = new List<Vector2>();
        private RotationComponent _rotationComponent;
        private int _reflections;

        void Start()
        {
            direction = transform.up;
            laserPositions.Add(laserStartPoint.position);
            _rotationComponent = GetComponent<RotationComponent>();
            lineRenderer.material = _laserConfig.GetDefaultLaserMaterial();
        }

        void Update()
        {
            if (!_rotationComponent.IInteractive)
            {
                laserPositions.Clear();
                lineRenderer.positionCount = 0;
                return;
            }

            laserPositions.Clear();
            laserPositions.Add(laserStartPoint.position);
            direction = transform.up;
            CastLaser(laserStartPoint.position, direction, _reflections);
        }

        void CastLaser(Vector2 startPosition, Vector2 currentDirection, int reflectionCount)
        {
            RaycastHit2D hit = Physics2D.Raycast(startPosition, currentDirection, laserLength);

            if (hit.collider != null)
            {
                laserPositions.Add(hit.point);
                if (hit.collider.TryGetComponent(out RotationComponent rotationComponent) && !rotationComponent.IInteractive)
                    return;
                Vector2 reflectionDirection = CalculateReflection(currentDirection, hit.normal, hit.transform);

                if (hit.collider.TryGetComponent(out Battary battary))
                {
                    if (reflectionCount < maxReflections)
                        CastLaser(hit.point, reflectionDirection, reflectionCount + 1);
                    battary.AddValue(0.1f);
                    return;
                }

                if (reflectionCount < maxReflections)
                {
                    CastLaser(hit.point, reflectionDirection, reflectionCount + 1);
                }
            }
            else
            {
                laserPositions.Add(startPosition + currentDirection * laserLength);
                _reflections = 0;
            }

            UpdateLaserLine();
        }

        Vector2 CalculateReflection(Vector2 direction, Vector2 normal, Transform hitTransform)
        {
            if (hitTransform.TryGetComponent(out Reflect reflect))
            {
                return reflect.ReflectionDirection;
            }

            return Vector2.Reflect(direction, normal);
        }


        void UpdateLaserLine()
        {
            lineRenderer.positionCount = laserPositions.Count;
            lineRenderer.SetPositions(laserPositions.ConvertAll(pos => (Vector3)pos).ToArray());
        }
    }
}