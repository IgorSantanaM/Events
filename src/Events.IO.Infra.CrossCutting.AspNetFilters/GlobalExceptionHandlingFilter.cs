﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.IO.Infra.CrossCutting.AspNetFilters
{
    public class GlobalExceptionHandlingFilter : IExceptionFilter
    {
        private readonly ILogger<GlobalExceptionHandlingFilter> _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        public GlobalExceptionHandlingFilter(ILogger<GlobalExceptionHandlingFilter> logger, IHostingEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            if (_hostingEnvironment.IsProduction())
            {
                _logger.LogError(1, context.Exception, context.Exception.Message);
            }

            var result = new ViewResult { ViewName = "Error" };
            var modelData = new EmptyModelMetadataProvider();

            result.ViewData = new ViewDataDictionary(modelData, context.ModelState)
            {
                {"MessageError", context.Exception.Message }
            };

            context.ExceptionHandled = true;
            context.Result =  result;
        }
    }
}
