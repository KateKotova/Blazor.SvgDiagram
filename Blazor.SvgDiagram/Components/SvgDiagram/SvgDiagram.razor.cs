using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.SvgDiagram.Components.SvgDiagram;

public partial class SvgDiagram : IAsyncDisposable
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public string DiagramSvgId { get; set; } = "diagram";

    private IJSObjectReference? _jsModule;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
                "./js/svg-diagram/svg-diagram.js");

            await CreateDiagramAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_jsModule is not null)
        {
            try
            {
                await _jsModule.DisposeAsync();
            }
            catch (JSDisconnectedException)
            {
                // TODO: show an error message
            }
        }
    }

    public async Task CreateDiagramAsync()
    {
        if (_jsModule is not null)
        {
            await _jsModule.InvokeVoidAsync("createDiagram", DiagramSvgId);
        }
    }
}