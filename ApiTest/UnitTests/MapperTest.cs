using AutoMapper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Text;
using Web_Api;
using Web_Api.DTOs.Mapper;
using Xunit;

namespace Tests.UnitTests
{
    public class MapperTest
    {
        private IMapper _mapper;

        private MapperConfiguration _mapperConfiguration;
        public MapperTest()
        {
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityDtoProfile());
            });
            _mapper = _mapperConfiguration.CreateMapper();
        }

        [Fact]
        public void MapperShouldBeCorrect()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

    }
}
