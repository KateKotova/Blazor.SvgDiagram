using System.ComponentModel.DataAnnotations;

namespace Blazor.SvgDiagram.ViewModels;

public class DiagramParametersViewModel
{
    public const int MinPositiveInt = 1;
    public const int MaxSize = 10000;

    public const string SideShouldBeDefinedMessageEnd = " должна быть определена";
    public const string SideShouldBePositiveIntMessageEnd = " должна быть положительным целым числом";
    public const string SideShouldBeInRangeMessageEnd = " должна быть в диапазоне от 1 до 10000";

    public const string WidthCaption = "Ширина";
    public const string HeightCaption = "Высота";
    public const string GridStepCaption = "Шаг сетки";

    [Required(ErrorMessage = WidthCaption + SideShouldBeDefinedMessageEnd)]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = WidthCaption
        + SideShouldBePositiveIntMessageEnd)]
    [Range(MinPositiveInt, MaxSize, ErrorMessage = WidthCaption + SideShouldBeInRangeMessageEnd)]
    public string? Width { get; set; } = "400";

    [Required(ErrorMessage = HeightCaption + SideShouldBeDefinedMessageEnd)]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = HeightCaption
        + SideShouldBePositiveIntMessageEnd)]
    [Range(MinPositiveInt, MaxSize, ErrorMessage = HeightCaption + SideShouldBeInRangeMessageEnd)]
    public string? Height { get; set; } = "300";

    public bool ShowGrid { get; set; }

    [Required(ErrorMessage = GridStepCaption + " должен быть определён")]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = GridStepCaption
        + "должен быть положительным целым числом")]
    [Range(MinPositiveInt, 100, ErrorMessage = GridStepCaption
        + " должен быть в диапазоне от 1 до 100")]
    public string? GridStep { get; set; } = "15";
}