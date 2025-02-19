using Blazor.SvgDiagram.Models;

namespace Blazor.SvgDiagram.Events;

public class DiagramAddShapeEvent
{
    public ShapeType ShapeType { get; set; } = ShapeType.Rectangle;
}