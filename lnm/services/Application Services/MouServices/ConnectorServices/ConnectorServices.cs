﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using model;
using model.Institution;
using model.MOUs;
using services.Application_Services.LeadServices.DTO;
using services.Application_Services.MouServices.DTO;
using services.Repository;

namespace services.Application_Services.MouServices.ConnectorServices
{
    public class ConnectorServices : IConnectorServices
    {
        private readonly IApplicationRepository<ConnectorMou> _repository;
        private readonly IMapper _mapper;

        public async Task<CommonResponse<List<connectorDtocs>>> GetAllConnectorsMouAsync()
        {
            var connectors = await _repository.GetAllAsync();
            var data =_mapper.Map<List<connectorDtocs>>(connectors);
            return new CommonResponse<List<connectorDtocs>>(true, "connectors mou fetched successfully", 200, data);
        }

        public async Task<CommonResponse<object>> GetConnectorMouByVersionAsync(float versionno) // this is for getting the individual version no of Mous
        {
            if (versionno == null)
            {
                return new CommonResponse<object>(false, "mou does not exist", 404, null);
            }
            var mou = await _repository.GetSingleAsync(u=>u.CmouMouVerionNo==versionno);

            return new CommonResponse<object>(true, "mou retireved successfully", 200, mou);
            
        }

        public async Task<CommonResponse<object>> GetCurrentConnectorMouByVersionAsync()
        {
            var allMous = await _repository.GetAllAsync();

            var latestVersion = allMous.Max(m => m.CmouMouVerionNo);

            var mou = await _repository.GetSingleAsync(u=>u.CmouMouVerionNo == latestVersion);

            return new CommonResponse<object>(true,"current mou fetched successfully",200,mou);
        }

      
    }
}
