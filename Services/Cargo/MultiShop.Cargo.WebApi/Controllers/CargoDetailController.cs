using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoDetailController(ICargoDetailService cargoDetailService, IMapper mapper)
        {
            _cargoOperationService = cargoDetailService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            var values = _mapper.Map<CargoDetail>(createCargoDetailDto);
            _cargoOperationService.TInsert(values);
            return Ok("Kargo detayı başarıyla oluşturuldu");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo detayı başarıyla silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            var values = _mapper.Map<CargoDetail>(updateCargoDetailDto);
            _cargoOperationService.TUpdate(values);
            return Ok("Kargo detayı başarıyla güncellendi");
        }
    }
}
