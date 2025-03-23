using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float speed = 60;

    private AnimatedSprite2D _sprite;

    public override void _Ready()
    {
        _sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
    }

    public override void _Process(double delta)
    {
        var velocity = GetMovementVector() * speed;
        Velocity = velocity;
        UpdateAnimation(velocity);
        MoveAndSlide();
    }

    /// <summary>
    /// Get the player's movement vector from the input actions
    /// </summary>
    /// <returns>The player's movement vector</returns>
    private Vector2 GetMovementVector()
    {
        float x = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        float y = Input.GetActionStrength("move_down") - Input.GetActionStrength("move_up");

        return new Vector2(x, y);
    }

    /// <summary>
    /// Update the player's animation
    /// </summary>
    /// <param name="velocity">The player's velocity</param>
    private void UpdateAnimation(Vector2 velocity)
    {
        if (velocity == Vector2.Zero)
        {
            _sprite.Play("idle_down");
            return;
        }

        if (velocity.X != 0)
        {
            switch (velocity.X)
            {
                case > 0:
                    _sprite.Play("move_right");
                    break;
                case < 0:
                    _sprite.Play("move_left");
                    break;
            }
        }
        else
        {
            switch (velocity.Y)
            {
                case > 0:
                    _sprite.Play("move_down");
                    break;
                case < 0:
                    _sprite.Play("move_up");
                    break;
            }
        }
    }
}