using Blazor.SvgDiagram.Events;
using Blazor.SvgDiagram.Models;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;

namespace Blazor.SvgDiagram.Components.DiagramPanel;

public partial class DiagramElementsPanel
{
    [Inject]
    public ComponentBus Bus { get; set; }

    private void OnAddShape(ShapeType shapeType)
    {
        Bus.Publish(new DiagramAddShapeEvent { ShapeType = shapeType });
    }

    private void OnRemoveSelectedElements()
    {
        Bus.Publish(new DiagramRemoveSelectedElementsEvent());
    }
}