﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerceTessa.Service.Interface.Province;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace WebApiECommerceTessa.Controllers
{
    //[]
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceController(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getbyid")]
        public async Task<IActionResult> GetProvincesById(long id)
        {
            try
            {
                var provinceId = await _provinceRepository.GetById(id);
                return Ok(provinceId);
            }
            catch (Exception e)
            {
                return NotFound("The Province was not found");
            }
        }

        [HttpGet]
        [EnableCors("_myPoliticy")]
        [Route("getall")]
        public async Task<IActionResult> GetAllProvinces()
        {
            try
            {
                var allProvinces = await _provinceRepository.GetAll();
                return Ok(allProvinces);
            }
            catch (System.ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
