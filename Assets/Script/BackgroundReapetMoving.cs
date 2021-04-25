using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundReapetMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    private SpriteRenderer _spriteRenderer;
    private float _startXPosition;
    private float _positionXToRepeat;
    
    // Start is called before the first frame update
    void Start()
    {
        _startXPosition = transform.position.x;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.drawMode = SpriteDrawMode.Tiled;
        _positionXToRepeat = transform.position.x - (_spriteRenderer.size.x * transform.localScale.x);
        _spriteRenderer.size *= new Vector2(2, 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.left * (_speed * Time.fixedDeltaTime);
        if (transform.position.x <= _positionXToRepeat)
        {
            transform.position = new Vector2(
                transform.position.x - _positionXToRepeat + _startXPosition,
                transform.position.y
            );
        }
    }
}
