﻿using AkaLibraryMVC.DTO;
using AkaLibraryMVC.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaLibraryMVC.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookTitle, BookTitleDTO>();
            CreateMap<Library_Book, LibraryBookDTO>();
        }
    }
}