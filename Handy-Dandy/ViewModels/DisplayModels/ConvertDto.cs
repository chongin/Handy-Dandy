﻿using System;
using System.Linq;
using Handy_Dandy.Models;

namespace Handy_Dandy.ViewModels.DisplayModels
{
	public class ConvertDto
	{
        public static List<WorkerDto> ConvertToWorkerDtoList(List<WorkerModel> models)
        {
            return models.Select(model => new WorkerDto(model)).ToList();
        }

        public static List<ServiceDto> ConvertToServiceDtoList(List<ServiceModel> models)
        {
            return models.Select(model => new ServiceDto(model)).ToList();
        }
    }
}

