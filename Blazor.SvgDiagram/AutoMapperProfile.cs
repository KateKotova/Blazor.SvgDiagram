using AutoMapper;
using Blazor.SvgDiagram.Models;
using Blazor.SvgDiagram.ViewModels;

namespace Blazor.SvgDiagram;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<DiagramParametersViewModel, DiagramParametersModel>()
            .ForMember(destination => destination.Width,
                act => act.MapFrom(source => source.Width == null
                ? DiagramParametersViewModel.MinSize : int.Parse(source.Width)))
            .ForMember(destination => destination.Height,
                act => act.MapFrom(source => source.Height == null
                ? DiagramParametersViewModel.MinSize : int.Parse(source.Height)))
            .ReverseMap();
    }
}