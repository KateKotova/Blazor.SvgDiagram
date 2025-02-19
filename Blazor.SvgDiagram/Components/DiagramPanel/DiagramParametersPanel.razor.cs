using AutoMapper;
using Blazor.SvgDiagram.Events;
using Blazor.SvgDiagram.Models;
using Blazor.SvgDiagram.ViewModels;
using Blazor.SvgDiagram.ViewModels.Parameters;
using BlazorComponentBus;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Blazor.SvgDiagram.Components.DiagramPanel;

public partial class DiagramParametersPanel
{
    [Inject]
    public ComponentBus Bus { get; set; }

    [Inject]
    public IMapper Mapper { get; set; }

    [Parameter]
    public DiagramParametersModel ParametersModel { get; set; } = new();

    private EditContext? _editContext;
    private ValidationMessageStore? _validationMessagesStore;
    private DiagramParametersViewModel _parametersViewModel = new();

    protected override void OnParametersSet()
    {
        base.OnInitialized();
        _parametersViewModel = Mapper.Map<DiagramParametersViewModel>(ParametersModel);
        _editContext = new(_parametersViewModel);
        _validationMessagesStore = new(_editContext);
    }

    public void ChangeParameters()
    {
        var parametersModel = Mapper.Map<DiagramParametersModel>(_parametersViewModel);
        Bus.Publish(new DiagramParametersChangedEvent { Parameters = parametersModel });
    }

    private void OnWidthChanged(ChangeEventArgs args) =>
        OnSizeChanged(args, new DiagramWidthParameter(_parametersViewModel));

    private void OnHeightChanged(ChangeEventArgs args) =>
        OnSizeChanged(args, new DiagramHeightParameter(_parametersViewModel));

    private void OnSizeChanged(ChangeEventArgs args, IStringParameter sideParameter)
    {
        if (_editContext == null || _validationMessagesStore == null)
        {
            return;
        }

        var fieldIdentifier = _editContext.Field(sideParameter.GetFieldName());
        _validationMessagesStore.Clear(fieldIdentifier);

        sideParameter.SetValue(args.Value?.ToString());
        try
        {
            _editContext.Validate();
        }
        catch (OverflowException)
        {
            _validationMessagesStore.Add(fieldIdentifier, sideParameter.GetCaption()
                + " вызывает переполнение");
            return;
        }

        var fieldIsValid = _editContext.IsValid(fieldIdentifier);
        if (fieldIsValid)
        {
            ChangeParameters();
        }
    }

    private void OnShowGridChanged(ChangeEventArgs args)
    {
        _parametersViewModel.ShowGrid = args.Value is not null && (bool)args.Value;
        ChangeParameters();
    }
}