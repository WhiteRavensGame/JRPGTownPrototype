using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteUpdater : MonoBehaviour
{
    [SerializeField] private VillagerAI _ai;
    [SerializeField] private List<VillagerSprite> _allSprites;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _maxSpriteChangeTime;

    private VillagerSprite _chosenSprite;
    private float _spriteChangeTime;
    private bool _facingRight = true;
    private bool _walking;

    public void Initialize()
    {
        System.Random random = new System.Random();
        int spriteChoice = random.Next(0, _allSprites.Count);
        _chosenSprite = _allSprites[spriteChoice];
    }

    private void Update()
    {
        if (_ai.Rb.velocity.magnitude < 0.1f)
        {
            if (_facingRight)
            {
                _spriteRenderer.sprite = _chosenSprite.RightIdle;
            }
            else
            {
                _spriteRenderer.sprite = _chosenSprite.LeftIdle;
            }

            return;
        }

        if (_ai.Rb.velocity.x < 0)
        {
            _facingRight = false;
        }
        else
        {
            _facingRight = true;
        }

        if (_spriteChangeTime < 0)
        {
            _spriteChangeTime = _maxSpriteChangeTime;
            
            if (_facingRight)
            {
                if (_walking)
                {
                    _spriteRenderer.sprite = _chosenSprite.RightIdle;
                    _walking = false;
                }
                else
                {
                    _spriteRenderer.sprite = _chosenSprite.RightWalk;
                    _walking = true;
                }
            }
            else
            {
                if (_walking)
                {
                    _spriteRenderer.sprite = _chosenSprite.LeftIdle;
                    _walking = false;
                }
                else
                {
                    _spriteRenderer.sprite = _chosenSprite.LeftWalk;
                    _walking = true;
                }
            }

            return;
        }

        _spriteChangeTime -= Time.deltaTime;
    }
}
