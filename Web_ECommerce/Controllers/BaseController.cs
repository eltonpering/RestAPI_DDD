using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationApp.Interfaces;
using Entities.Entities;
using Entities.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Web_ECommerce.Controllers
{
    public class BaseController : Controller
    {
        public readonly ILogger<BaseController> logger;        

        public BaseController(ILogger<BaseController> logger)
        {
            this.logger = logger;            
        }

    }
}
