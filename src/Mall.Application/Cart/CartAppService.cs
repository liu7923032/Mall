using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;

using Mall.Domain.Entities;

namespace Mall.Cart
{

    #region 1.0 抽象接口 ICartAppService
    /// <summary>
    /// 购物车信息
    /// </summary>
    public interface ICartAppService
    {
        /// <summary>
        /// 1:向购物车中添加商品
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        Task<bool> AddProduct(CartItemInput itemDto);
        /// <summary>
        /// 2:删除购物车中的东西
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task DelProduct(int productId);
        /// <summary>
        /// 3:更新商品
        /// </summary>
        /// <param name="itemDto"></param>
        /// <returns></returns>
        Task<bool> UpdateProductNums(CartItemInput itemDto);

        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="cartId"></param>
        /// <returns></returns>
        Task<bool> CheckOut(int cartId);

    }
    #endregion

    #region 2.0 具体实现 CartAppService
    /// <summary>
    /// 购物车
    /// </summary>
    public class CartAppService : MallAppServiceBase, ICartAppService
    {

        private IRepository<Mall_Cart> _cartRepository;
        private IRepository<Mall_CartItem> _cartItemRepository;
        private IRepository<Mall_Product> _productRepository;
        private IRepository<Mall_Order> _orderRepository;

        public CartAppService(IRepository<Mall_Cart> cartRepository,
                            IRepository<Mall_CartItem> cartItemRepository,
                            IRepository<Mall_Product> productRepository,
                            IRepository<Mall_Order> orderRepository)
        {
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;

        }

        private async Task<Mall_Cart> GetCurrentCart()
        {
            return await _cartRepository.FirstOrDefaultAsync(u => u.ItemStatus == CartStatus.Init && u.CreatorUserId.Value.Equals(AbpSession.GetUserId()));
        }

        public async Task<bool> AddProduct(CartItemInput itemDto)
        {
            //1:找到产品
            var product = await _productRepository.FirstOrDefaultAsync(u => u.Id.Equals(itemDto.ProductId));
            //2:找到购物车
            using (var uow = UnitOfWorkManager.Begin(System.Transactions.TransactionScopeOption.Suppress))
            {
                var cart = await GetCurrentCart();
                if (cart == null)
                {
                    cart = new Mall_Cart();
                    await _cartRepository.InsertAndGetIdAsync(cart);
                    await uow.CompleteAsync();
                }


                Mall_CartItem cartItem = new Mall_CartItem()
                {
                    CartId = cart.Id,
                    ItemPrice = product.Price,
                    ItemNum = itemDto.ItemNum,
                    ProductId = itemDto.ProductId
                };

                await _cartItemRepository.InsertAsync(cartItem);
                await uow.CompleteAsync();
            }
            return await Task.FromResult(true);
        }

        public async Task DelProduct(int productId)
        {
            //1：找到购物车
            var cart = await GetCurrentCart();
            //2：找到商品
            var cartItem = await _cartItemRepository.FirstOrDefaultAsync(u => u.CartId.Equals(cart.Id) && u.ProductId.Equals(productId));
            //3：删除商品
            await _cartItemRepository.DeleteAsync(cartItem);
        }

        public async Task<bool> UpdateProductNums(CartItemInput itemDto)
        {
            //1：找到购物车
            var cart = await GetCurrentCart();
            //2：找到商品
            var cartItem = await _cartItemRepository.FirstOrDefaultAsync(u => u.CartId.Equals(cart.Id) && u.ProductId.Equals(itemDto.ProductId));
            cartItem.ItemNum = itemDto.ItemNum;
            //3：更新商品
            return await _cartItemRepository.UpdateAsync(cartItem) != null;
        }

        public async Task<bool> CheckOut(int cartId)
        {
            //1:获取购物车
            var cart = await GetCurrentCart();
            //2：设置状态
            cart.ItemStatus = CartStatus.Pay;
            //3：生成订单
            Mall_Order order = new Mall_Order();
            order.CartId = cart.Id;
            order.OrderStatus = OrderStatus.Init;
            //订单编号,自动生成
            order.OrderNo = GenerateOrderNo();
            //计算该订单的总金额
            order.AllPrice = _cartItemRepository.GetAllIncluding(u => u.CartId.Equals(cartId)).Select(u => u.ItemNum * u.ItemPrice).Sum();
            //4：没有订单
            await _orderRepository.InsertAsync(order);
            //5：更新采购
            await _cartRepository.UpdateAsync(cart);
            return await Task.FromResult(true);
        }

        /// <summary>
        /// 自动生成订单编号
        /// </summary>
        /// <returns></returns>
        private string GenerateOrderNo()
        {
            //1：通过日期来
            return $"MO{DateTime.Now.ToString("yyyyMMdd")}";
        }
    }
    #endregion
}
