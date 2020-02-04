using VehicleInventory.Services.Contracts;
using VehicleInventory.Services.DTOs;
using System.Web.Http.Description;
using System.Collections.Generic;
using CodingExercise.API.Models;
using System.Web.Http;
using AutoMapper;
using System;

namespace CodingExercise.API.Controllers
{
    [Authorize]
    public class VehicleInventoryController : ApiController
    {
        private readonly IVehicleInventoryService _vehicleInventoryService;
        private readonly IMapper _mapper;

        public VehicleInventoryController(IVehicleInventoryService service, IMapper mapper)
        {
            _mapper = mapper;
            _vehicleInventoryService = service;
        }

        [ResponseType(typeof(List<VehicleInStockDTO>))]
        public IHttpActionResult GetAllVehiclesInStock()
        {
            try
            {
                var result = _vehicleInventoryService.GetAllVehiclesInStockFlat();

                return Ok(result);

            }
            catch
            {
                return InternalServerError();
            }

        }

        [ResponseType(typeof(List<VehicleInStockDTO>))]
        public IHttpActionResult GetVehicleInStockById(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            try
            {
                var result = _vehicleInventoryService.GetVehicleInStockByIdFlat(id);

                return Ok(result);

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }

        }

        [HttpPost]
        public IHttpActionResult AddVehicleInStock(AddVehicleInStockModel model)
        {
            if (ModelState.IsValid)
            {
                var mapped = _mapper.Map<AddVehicleInStockDTO>(model);

                try
                {
                    _vehicleInventoryService.AddVehicleInStock(mapped);
                }
                catch
                {
                    return InternalServerError();
                }
            }
            else
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteVehicleInStock(int id)
        {
            try
            {
                _vehicleInventoryService.RemoveVehicleInStock(id);
            }
            catch
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
