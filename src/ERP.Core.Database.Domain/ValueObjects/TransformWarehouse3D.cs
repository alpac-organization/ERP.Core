namespace ERP.Core.Database.Domain.ValueObjects;

public record TransformWarehouse3D
{
    public decimal PositionX { get; init; }
    public decimal PositionY { get; init; }
    public decimal PositionZ { get; init; }
    public decimal RotationY { get; init; }
}