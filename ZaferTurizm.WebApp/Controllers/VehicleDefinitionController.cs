using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Dtos;

namespace ZaferTurizm.WebApp.Controllers
{
    public class VehicleDefinitionController : Controller
    {
        private readonly IVehicleDefinitionService _vehicleDefinitionService;
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleDefinitionController(
            IVehicleDefinitionService vehicleDefinitionService,
            IVehicleMakeService vehicleMakeService,
            IVehicleModelService vehicleModelService)
        {
            _vehicleDefinitionService = vehicleDefinitionService;
            _vehicleMakeService = vehicleMakeService;
            _vehicleModelService = vehicleModelService;
        }

        public IActionResult Index()
        {
            var summaries = _vehicleDefinitionService.GetSummaries();

            return View(summaries);
        }

        public IActionResult Create()
        {
            var vehicleMakes = _vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList = new SelectList(vehicleMakes, "Id", "Name");

            var vehicleDef = _vehicleDefinitionService.GetAll();
            ViewBag.VehicleDesSelectList = new SelectList(vehicleDef, "Id", "HasWifi");
            return View();
        }

        [HttpPost]
        public IActionResult Create(VehicleDefinitionDto vehicleDefinitionDto)
        {


            var a = _vehicleDefinitionService.Create(vehicleDefinitionDto);

            if (a.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vehicleDefinitionDto);
            }
            
        }

        public IActionResult Update(int id)
        {
          var vehicleDefinition =  _vehicleDefinitionService.GetById(id);

            if (vehicleDefinition == null)
            {
                return NotFound();
            }

            var allVehicleMakes =_vehicleMakeService.GetAll();
            ViewBag.VehicleMakeSelectList = new SelectList(allVehicleMakes, "Id", "Name", vehicleDefinition.VehicleMakeId);

            var vehicleModelsOfMake = _vehicleModelService.GetByMakeId(vehicleDefinition.VehicleMakeId);
            ViewBag.VehicleModelSelectList = new SelectList(vehicleModelsOfMake, "Id", "Name");
            return View(vehicleDefinition);
        }

        [HttpPost]
        public IActionResult Update(VehicleDefinitionDto vehicleDefinitionDto)
        {

            var result = _vehicleDefinitionService.Update(vehicleDefinitionDto);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(vehicleDefinitionDto);
            }
        }

        public IActionResult Delete(int id)
        {
            var result = _vehicleDefinitionService.Delete(id);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
