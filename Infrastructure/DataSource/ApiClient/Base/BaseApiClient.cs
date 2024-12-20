﻿using AutoMapper;
using Infrastructure.DataSource.ApiClientFactory;
using Infrastructure.Nswag;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DataSource.ApiClient.Base
{
    public interface IBuildApiClient<T> {
       public  Task<T> GetApiClient();
    }
    public class BuildApiClient<T>: IBuildApiClient<T> where T : class
    {

        protected readonly ClientFactory _clientFactory;
        protected readonly IMapper _mapper;
        protected readonly IConfiguration _config;
        public BuildApiClient(
                    ClientFactory clientFactory,
                    IMapper mapper,
                    IConfiguration config)
        {
            _clientFactory = clientFactory;
            _mapper = mapper;
            _config = config;
        }

     

        public  async Task<T>  GetApiClient()
        {
            var client = await _clientFactory.CreateClientWithAuthAsync<T>("ApiClient");
            return client;
        }

      
    }
}