using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class VampireSkill : MonoBehaviour
{
    [SerializeField] private float _durationInSeconds = 6;
    [SerializeField] private float _actionRadius = 5;
    [SerializeField] private float _power = 0.02f;
    [SerializeField] private LayerMask layerMaskEnemy;

    private Coroutine _coroutine = null;
    private Player _player;


    private void Start()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        if (Input.GetAxis(PlayerInputData.Params.VampireSkill) != 0 && _coroutine == null)
        {
            _coroutine = StartCoroutine(PullingLifeOut());
        }
    }

    private IEnumerator PullingLifeOut()
    {
        float executionTime = 0;

        while (executionTime < _durationInSeconds)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _actionRadius, layerMaskEnemy);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.TakeDamage(_power);
                   _player.TakeHeal(_power);
                }
            }

            executionTime += Time.deltaTime;
            yield return null;
        }

        _coroutine = null;
    }
}