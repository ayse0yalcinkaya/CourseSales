//using AutoMapper;
//using CourseSales.Repositories.Categories;
//using CourseSales.Repositories;
//using CourseSales.Service.Categories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CourseSales.Repositories.Orders;
//using CourseSales.Service.Categories.Create;
//using CourseSales.Service.Categories.Dto;
//using CourseSales.Service.Categories.Update;
//using System.Net;
//using CourseSales.Service.Orders.Create;
//using CourseSales.Service.Orders.Dto;
//using Microsoft.EntityFrameworkCore;

//namespace CourseSales.Service.Orders
//{
//    internal class OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork, IMapper mapper) : IOrderService
//    {
//        public async Task<ServiceResult<OrderWithCoursesDto>> GetOrderWithCoursesAsync(int OrderId)
//        {
//            var order = await orderRepository.GetOrderWithUsersAsync(orderId);

//            if (order is null)
//            {
//                return ServiceResult<OrderWithCoursesDto>.Fail("Sipariş bulunamadı",
//                    HttpStatusCode.NotFound);
//            }

//            var orderAsDto = mapper.Map<OrderWithCoursesDto>(order);
//            return ServiceResult<OrderWithCoursesDto>.Success(orderAsDto);
//        }

//        public async Task<ServiceResult<List<OrderWithCoursesDto>>> GetOrderWithCoursesAsync()
//        {
//            var order = await orderRepository.GetOrderWithUsers().ToListAsync();

//            var orderAsDto = mapper.Map<List<CategoryWithCoursesDto>>(order);
//            return ServiceResult<List<OrderWithCoursesDto>>.Success(orderAsDto);
//        }

//        public async Task<ServiceResult<List<OrderDto>>> GetAllListAsync()
//        {
//            var categories = await orderRepository.GetAll().ToListAsync();
//            var orderAsDto = mapper.Map<List<OrderDto>>(categories);
//            return ServiceResult<List<OrderDto>>.Success(orderAsDto);
//        }

//        public async Task<ServiceResult<OrderDto>> GetByIdAsync(int id)
//        {
//            var category = await orderRepository.GetByIdAsync(id);

//            if (order is null)
//            {
//                return ServiceResult<OrderDto>.Fail("Sipariş bulunamadı", HttpStatusCode.NotFound);
//            }

//            var orderAsDto = mapper.Map<OrderDto>(order);
//            return ServiceResult<OrderDto>.Success(orderAsDto);
//        }

//        public async Task<ServiceResult<int>> CreateAsync(CreateCategoryRequest request)
//        {
//            var newOrder = mapper.Map<Order>(request);

//            await orderRepository.AddAsync(newOrder);
//            await unitOfWork.SaveChangeAsync();
//            return ServiceResult<int>.SuccessAsCreated(newOrder.Id, $"api/categories/{newOrder.Id}");
//        }


//        public async Task<ServiceResult> DeleteAsync(int id)
//        {
//            var category = await orderRepository.GetByIdAsync(id);
//            //if (category == null)
//            //{
//            //    return ServiceResult.Fail("Kategori bulunamadı.", HttpStatusCode.NotFound);
//            //}
//           orderRepository.Delete(category!);
//            await unitOfWork.SaveChangeAsync();

//            return ServiceResult.Success(HttpStatusCode.NoContent);
//        }

//    }
//}
