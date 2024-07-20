using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomerController(ICargoCustomerService cargoCustomerService, IMapper mapper)
        {
            _cargoCustomerService = cargoCustomerService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values  = _cargoCustomerService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            var values = _mapper.Map<CargoCustomer>(createCargoCustomerDto);
            _cargoCustomerService.TInsert(values);
            return Ok("Kargo müşterisi başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            var values = _mapper.Map<CargoCustomer>(updateCargoCustomerDto);
            _cargoCustomerService.TUpdate(values);
            return Ok("Kargo müşterisi başarıyla güncellendi");
        }
    }
}
