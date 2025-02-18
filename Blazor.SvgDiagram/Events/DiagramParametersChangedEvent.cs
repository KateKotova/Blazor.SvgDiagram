using Blazor.SvgDiagram.Models;

namespace Blazor.SvgDiagram.Events;

public class DiagramParametersChangedEvent
{
    public DiagramParametersModel Parameters { get; set; } = new();
}