using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Api.DTOs.Invoice;
using Api.Errors;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.RepositoryInterfaces;
using Domain.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{

    public class InvoiceController : BaseApiController
    {
        private readonly IGenericRepository<Invoice> _invoiceRepository;
        private readonly IGenericRepository<InvoiceDetail> _invoiceDetailRepository;
        private readonly IGenericRepository<Customer> _customerRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<DiscountDefinition> _discountRepository;
        private readonly IMapper _mapper;


        public InvoiceController(
            IGenericRepository<Invoice> invoiceRepository,
            IGenericRepository<InvoiceDetail> invoiceDetailRepository,
            IGenericRepository<Customer> customerRepository,
            IGenericRepository<Product> productRepository,
            IGenericRepository<DiscountDefinition> discountDefinition,
            IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _discountRepository = discountDefinition;
            _mapper = mapper;
        }

        [HttpGet("Invoices")]
        public async Task<ActionResult<IReadOnlyList<InvoiceOutputDTO>>> GetInvoices()
        {
            var spec = new InvoiceSpecification();
            var invoices = await _invoiceRepository.ListAllAsync(spec);

            if (invoices == null)
                return NotFound(new ApiResponse(204, "Invoice not found"));

            return Ok(_mapper.Map<IReadOnlyList<Invoice>, IReadOnlyList<InvoiceOutputDTO>>(invoices));

        }

        [HttpPost("CreateAnInvoiceForACustomer")]
        public async Task<ActionResult> CreateInvoice(int customerId, [FromBody] InvoiceInputDTO invoiceInputDTO)
        {
            var spec = new CustomerWithTypeSpecification(customerId);
            var customer = await _customerRepository.GetEntityWithSpecification(spec);
            if (customer == null)
                return NotFound(new ApiResponse(204, "Customer is not found"));
            var invoiceDetailList = new List<InvoiceDetail>();
            var invoice = new Invoice();
            if (invoiceInputDTO.InvoiceDetails != null)
            {
                invoice = new Invoice() { CustomerId = customer.Id, InvoiceNumber = invoiceInputDTO.InvoiceNumber };
                foreach (var item in invoiceInputDTO.InvoiceDetails)
                {
                    var productSpec = new ProductWithTypeSpecification(item.Product.Id);
                    var product = await _productRepository.GetEntityWithSpecification(productSpec);
                    if (product == null)
                        return NotFound(new ApiResponse(204, $"Product Id {item.Product.Id} is not found"));

                    var invoiceDetail = new InvoiceDetail() { Quantity = item.Quantity, ProductId = item.Product.Id };
                    var discountDefinition = await _discountRepository.GetByIdAsync(customer.CustomerType.DiscountDefinitionId);
                    if (discountDefinition != null)
                    {
                        invoiceDetail.Amount = product.Price * item.Quantity;
                        if (discountDefinition.IsRatio && product.ProductType.Type != (int)ProductTypeEnum.Grocery)
                            invoiceDetail.DiscountAmount = (product.Price * discountDefinition.Ratio / 100) * item.Quantity;
                        else
                            invoiceDetail.DiscountAmount = 0;

                        invoiceDetail.NetAmount = invoiceDetail.Amount - invoiceDetail.DiscountAmount;
                    }
                    invoiceDetailList.Add(invoiceDetail);
                    invoice.TotalQuantity++;
                    invoice.TotalAmount += invoiceDetail.Amount;
                    if (!discountDefinition.IsRatio)
                    {
                        invoice.TotalDiscountAmount += Math.Floor(invoiceDetail.Amount / 100) * 5;
                        invoice.TotalNetAmount = invoice.TotalAmount - invoice.TotalDiscountAmount;
                    }
                    else
                    {
                        invoice.TotalDiscountAmount += invoiceDetail.DiscountAmount;
                        invoice.TotalNetAmount += invoiceDetail.NetAmount;
                    }


                }
                var insertedInvoice = await _invoiceRepository.AddAsync(invoice);
                invoiceDetailList.ForEach(x => { x.InvoiceId = insertedInvoice.Id; });
                await _invoiceDetailRepository.AddRangeAsync(invoiceDetailList);
                return Ok(new ApiResponse(200, $"{invoice.InvoiceNumber} is created successfully"));
            }
            return NotFound(new ApiResponse(204, "Invoice Details not found"));

        }
    }
}