﻿using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository _productRepository;
        
        // northwind e göre eklendi
        private readonly IMapper _mapper;

        public ProductAppService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            var productList = await _productRepository.GetProductListAsync();
            var mapped = _mapper.Map<IEnumerable<ProductDto>>(productList);
            // var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProductByCategory(int categoryId)
        {
            var productList = await _productRepository.GetProductByCategoryAsync(categoryId);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;            
        }

        public async Task<IEnumerable<ProductDto>> GetProductByName(string productName)
        {
            var productList = await _productRepository.GetProductByNameAsync(productName);
            var mapped = ObjectMapper.Mapper.Map<IEnumerable<ProductDto>>(productList);
            return mapped;
        }
    }
}
