using AutoMapper;
using CQRSWebAppExample.Models.Data;
using CQRSWebAppExample.Models.DataModel;

namespace CQRSWebAppExample.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDataModel>();
        }
    }
}
