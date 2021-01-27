using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using PaiduaykanAPI.Models;
using PaiduaykanAPI.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace PaiduaykanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StoreController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetList()
        {
            List<Stores> dataList = new StoresContext().GetList();
            return Ok(new
            {
                dataList,
            });
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            return Ok(new
            {
            });
        }

        [HttpPost]
        public ActionResult Save(JObject data)
        {
            Stores dataSave = data.ToObject<Stores>();
            var save = new StoresContext().Save(dataSave);
            return Ok(new
            { 
                isResult = save == null ? false : true,
                dataSave,
            });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var save = new StoresContext().Delete(id);
            return Ok(new
            {
                isResult = save,
            });
        }
    }
}
