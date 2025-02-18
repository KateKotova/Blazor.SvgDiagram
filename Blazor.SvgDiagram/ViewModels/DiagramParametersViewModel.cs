using System.ComponentModel.DataAnnotations;

namespace Blazor.SvgDiagram.ViewModels;

public class DiagramParametersViewModel
{
    public const int MinSize = 1;
    public const int MaxSize = 10000;

    public const string SideShouldBeDefinedMessageEnd = " должна быть определена";
    public const string SideShouldBePositiveIntMessageEnd = " должна быть положительным целым числом";
    public const string SideShouldBeInRangeMessageEnd = " должна быть в диапазоне от 1 до 10000";

    public const string WidthCaption = "Ширина";
    public const string HeightCaption = "Высота";

    [Required(ErrorMessage = WidthCaption + SideShouldBeDefinedMessageEnd)]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = WidthCaption + SideShouldBePositiveIntMessageEnd)]
    [Range(MinSize, MaxSize, ErrorMessage = WidthCaption + SideShouldBeInRangeMessageEnd)]
    public string? Width { get; set; } = "400";

    [Required(ErrorMessage = HeightCaption + SideShouldBeDefinedMessageEnd)]
    [RegularExpression("([1-9][0-9]*)", ErrorMessage = HeightCaption + SideShouldBePositiveIntMessageEnd)]
    [Range(MinSize, MaxSize, ErrorMessage = HeightCaption + SideShouldBeInRangeMessageEnd)]
    public string? Height { get; set; } = "300";
}