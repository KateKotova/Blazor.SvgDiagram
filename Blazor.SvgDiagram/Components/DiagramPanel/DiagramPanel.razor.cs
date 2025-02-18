using Blazor.SvgDiagram.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.SvgDiagram.Components.DiagramPanel;

public partial class DiagramPanel
{
    [Parameter]
    public DiagramParametersModel DiagramParametersModel { get; set; } = new();
}