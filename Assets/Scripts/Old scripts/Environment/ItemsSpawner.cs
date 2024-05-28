using UnityEngine;
using UnityEngine.Pool;

public class ItemsSpawner : MonoBehaviour
{
    [SerializeField] private Item _itemPrefab;
    [SerializeField] private int _poolCapacity = 1;
    [SerializeField] private int _poolMaxSize = 1;

    private Camera _mainCamera;
    private ObjectPool<Item> _pool;
 
    private Vector2 _pointRightUp;
    private Vector2 _pointLeftDown;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _pointLeftDown = _mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        _pointRightUp = _mainCamera.ViewportToWorldPoint(new Vector2(1, 1));

        _pool = new ObjectPool<Item>(
            createFunc: () => CreateFunc(),
            actionOnGet: (item) => ActionOnGet(item),
            actionOnRelease: (item) => item.gameObject.SetActive(false),
            actionOnDestroy: (item) => ActionOnDestroy(item),
            collectionCheck: false,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize);
    }

    private void FixedUpdate()
    {
        if (_pool.CountActive <= _poolCapacity)
        {
            _pool.Get();
        }
    }

    private Item CreateFunc()
    {
        Item item = Instantiate(_itemPrefab);

        item.HaveTaken += ActionOnRelease;

        return item;
    }

    private void ActionOnGet(Item item)
    {
        item.transform.position = SelectionSpawnPoint();
        item.gameObject.SetActive(true);
    }

    private Vector2 SelectionSpawnPoint()
    {
        float pointX = Random.Range(_pointLeftDown.x, _pointRightUp.x);
        float pointY = Random.Range(_pointLeftDown.y, _pointRightUp.y);

       return new Vector2(pointX, pointY);
    }

    private void ActionOnRelease(Item item)
    {
        _pool.Release(item);
    }

    private void ActionOnDestroy(Item item)
    {
        item.HaveTaken -= ActionOnRelease;
        
        Destroy(item);
    }
}
