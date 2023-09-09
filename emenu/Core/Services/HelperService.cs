using AutoMapper;
using emenu.Controllers.Resources;
using emenu.Core.Contracts;
using emenu.Core.Models;
using emenu.Core.Models.Helper;
using emenu.Core.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace emenu.Core.Services
{
    public class HelperService
    {
        private readonly IMapper _mapper;
        public HelperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public PagedListRes<R> ToPageListResource<T, R>(PagedList<T> pagedList)
        {
            var listRes = _mapper.Map<IEnumerable<T>, IEnumerable<R>>(pagedList.List);

            return new PagedListRes<R>(pagedList.GetInfo(), listRes.ToList());
        }

    }
}
