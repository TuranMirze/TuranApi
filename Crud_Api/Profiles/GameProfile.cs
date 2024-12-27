using AutoMapper;
using Crud_Api.DTO.Games;
using Crud_Api.Entities;

namespace Crud_Api.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile() 
        { 
            CreateMap<GamesCreateDto, Game>();
        }
    }
}
