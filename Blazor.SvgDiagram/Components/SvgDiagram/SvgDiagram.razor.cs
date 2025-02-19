using Blazor.SvgDiagram.Events;
using Blazor.SvgDiagram.Models;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Blazor.SvgDiagram.Components.SvgDiagram;

public partial class SvgDiagram : IAsyncDisposable
{
    [Inject]
    public IJSRuntime JsRuntime { get; set; }

    [Inject]
    public ComponentBus Bus { get; set; }

    [Parameter]
    public string DiagramSvgId { get; set; } = "diagram";

    private Lazy<Task<IJSObjectReference>>? _moduleTask;

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        _moduleTask = new(() => JsRuntime.InvokeAsync<IJSObjectReference>("import",
            "./js/svg-diagram/svg-diagram.js").AsTask());
        Bus.Subscribe<DiagramParametersChangedEvent>(DiagramParametersChangedEventHandler);
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await CreateDiagramAsync();
        }
    }

    public async ValueTask DisposeAsync()
    {
        Bus.UnSubscribe<DiagramParametersChangedEvent>(DiagramParametersChangedEventHandler);

        if (_moduleTask!.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }

    public async Task CreateDiagramAsync()
    {
        var module = await _moduleTask!.Value;
        var parameters = new DiagramParametersModel();
        await module.InvokeVoidAsync("createSvgDiagram", DiagramSvgId,
            parameters.Width, parameters.Height, parameters.ShowGrid);
    }

    private async Task DiagramParametersChangedEventHandler(MessageArgs args,
        CancellationToken ct)
    {
        var message = args.GetMessage<DiagramParametersChangedEvent>();
        if (message is null)
        {
            return;
        }

        var module = await _moduleTask!.Value;
        await module.InvokeVoidAsync("updateSvgDiagramParameters", message.Parameters.Width,
            message.Parameters.Height, message.Parameters.ShowGrid);
    }
}