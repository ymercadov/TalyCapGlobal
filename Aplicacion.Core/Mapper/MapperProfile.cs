using AutoMapper;
using Dominio.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aplicacion.Core
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Books, BooksDTO>();
            CreateMap<BooksDTO, Books>();
            CreateMap<Author, AuthorsDTO>();
            CreateMap<AuthorsDTO, Author>();
            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO,Users>();

        }
    }
}
