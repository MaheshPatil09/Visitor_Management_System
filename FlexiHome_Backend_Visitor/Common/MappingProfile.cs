using AutoMapper;
using FlexiHome_Backend_Visitor.VisitorModel;
using FlexiHome_Backend_Visitor.VisitorEntity;
namespace FlexiHome_Backend_Visitor.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<VisitorModelClass,VisitorEntityClass>().ReverseMap();
        }
    }
}
