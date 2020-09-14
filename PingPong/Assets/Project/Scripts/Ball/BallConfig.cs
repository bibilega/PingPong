using UnityEngine;

[CreateAssetMenu(fileName = "BallData", menuName = "ScriptableObject/BallData")]
public class BallConfig : ScriptableObject
{
    public float Speed = 100;
    public Vector2 Scale = new Vector2(1, 1);
    public Color Color = Color.white;
}
