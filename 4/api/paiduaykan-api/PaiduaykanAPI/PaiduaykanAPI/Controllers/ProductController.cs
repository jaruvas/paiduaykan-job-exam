using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using PaiduaykanAPI.Context;
using PaiduaykanAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaiduaykanAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetList()
        {
            return Ok(new
            {
            });
        }

        [HttpGet]
        public ActionResult GetById(int id)
        {
            List<Products> dataList = new ProductsContext().GetByStoreId(id);
            List<ProductType> dataType = new ProductTypeContext().GetList();
            List<Units> dataUnit = new UnitsContext().GetList();
            return Ok(new
            {
                dataList,
                dataType,
                dataUnit,
            });
        }

        [HttpPost]
        public ActionResult Save(JObject data)
        {
            Products dataSave = data.ToObject<Products>();
            var save = new ProductsContext().Save(dataSave);
            return Ok(new
            {
                isResult = save == null ? false : true,
                dataSave,
            });
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var save = new ProductsContext().Delete(id);
            return Ok(new
            {
                isResult = save,
            });
        }
    }
}
