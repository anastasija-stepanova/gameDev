using UnityEngine;

public interface IFigure
{
    void Initialize(Vector2 position, float scale, int zRotation, FigureType type);
    void SetPosition(Vector2 position);
    void SetSize(float scale);
    void SetRotation(int zRotation);
    void SetColor(AvailableColors color);
}
