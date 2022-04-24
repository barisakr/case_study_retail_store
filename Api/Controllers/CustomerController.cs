using Api.DTOs;
using Api.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Domain.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{

    public class CustomerController : BaseApiController
    {
        private readonly IGenericRepository<Customer> _repository;
        private readonly IMapper _mapper;
        public CustomerController(
            IGenericRepository<Customer> repository,
            IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CustomerOutputDTO>>> GetCustomers()
        {
            var spec = new CustomerWithTypeSpecification();
            var customers = await _repository.ListAllAsync(spec);
            if (!customers.Any())
                return NotFound(new ApiResponse(204));

            return Ok(_mapper.Map<IReadOnlyList<Customer>, IReadOnlyList<CustomerOutputDTO>>(customers));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerOutputDTO>> GetCustomer(int id)
        {
            var spec = new CustomerWithTypeSpecification(id);
            var customer = await _repository.GetEntityWithSpecification(spec);
            if (customer == null)
                return NotFound(new ApiResponse(204));
            return _mapper.Map<Customer, CustomerOutputDTO>(customer);

        }
    }
}