using AcademicPlatformApisWithEfCore.Domain.Interfaces.Mappers;
using AutoMapper;
using System;

namespace AcademicPlatformApisWithEfCore.Mapper.AutoMapper
{
    public class AutoMapperObjectConverter : IObjectConverter
    {
        private readonly IMapper _mapper;

        public AutoMapperObjectConverter(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public T Map<T>(object obj) => _mapper.Map<T>(obj);     
    }
}
