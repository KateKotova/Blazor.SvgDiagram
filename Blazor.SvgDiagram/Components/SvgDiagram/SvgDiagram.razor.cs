using Blazor.SvgDiagram.Events;
using Blazor.SvgDiagram.Models;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.SvgDiagram.Components.SvgDiagram;

public partial class SvgDiagram : IAsyncDisposable
{
    [Inject]
    public IJSRuntime JSRuntime { get; set; }

    [Inject]
    public ComponentBus Bus { get; set; }

    [Parameter]
    public string DiagramSvgId { get; set; } = "diagram";

    private IJSObjectReference? _jsModule;

    protected override void OnInitialized()
    {
        Bus.Subscribe<DiagramParametersChangedEvent>(DiagramParametersChangedEventHandler);
    }

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
        Bus.UnSubscribe<DiagramParametersChangedEvent>(DiagramParametersChangedEventHandler);

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
            var parameters = new DiagramParametersModel();
            await _jsModule.InvokeVoidAsync("createSvgDiagram", DiagramSvgId,
                parameters.Width, parameters.Height);
        }
    }

    private async Task DiagramParametersChangedEventHandler(MessageArgs args, CancellationToken ct)
    {
        var message = args.GetMessage<DiagramParametersChangedEvent>();
        if (message is null || _jsModule is null)
        {
            return;
        }

        await _jsModule.InvokeVoidAsync("updateSvgDiagramParameters", DiagramSvgId,
            message.Parameters.Width, message.Parameters.Height);
    }
}