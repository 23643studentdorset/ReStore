using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace API.Controllers
{
    public class BasketController: BaseApiController
    {
        private readonly StoreContext _context;

        public BasketController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "GetBasket")]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            Basket basket = await RetrieveBasket();
            if (basket == null) return BadRequest(new ProblemDetails{Title = "Product Not Found"});

            return MapBasketToDto(basket);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket (int productId, int quantity){
            
            // get basket
            var basket = await RetrieveBasket();
            if (basket == null) basket = CreateBasket();
            
            // get product
            var product = await _context.Products.FindAsync(productId);
            if (product == null) return NotFound();
            
            // add item
            basket.AddItem(product, quantity);
            
            // save changes
            var result = await _context.SaveChangesAsync() > 0;
            
            if (result) return CreatedAtRoute("GetBasket", MapBasketToDto(basket));

            return BadRequest (new ProblemDetails{Title = "Problem saving item to basket"});
           
        }

        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity){
            
            // get basket
            var basket = await RetrieveBasket();
            if (basket == null) basket = CreateBasket();
            
            // remove item or reduce quantity
            basket.removeItem(productId, quantity);

            // save changes
            var result = await _context.SaveChangesAsync() > 0;
            
            if (result) return Ok();

            return BadRequest (new ProblemDetails{Title = "Problem removing item from the basket"});
        }
        private async Task<Basket> RetrieveBasket()
        {
            return await _context.Baskets
            .Include(i => i.Items)
            .ThenInclude(p => p.Product)
            .FirstOrDefaultAsync(x => x.BuyerId == Request.Cookies["buyerId"]);
        }

         private Basket CreateBasket()
        {
            var buyerId = Guid.NewGuid().ToString();
            var cookiOptions = new CookieOptions{IsEssential = true, Expires = DateTime.Now.AddDays(30)};
            Response.Cookies.Append("buyerId", buyerId, cookiOptions);
            var basket = new Basket {BuyerId = buyerId};
            _context.Baskets.Add(basket);
            return basket;
        }

        private BasketDto MapBasketToDto(Basket basket)
        {
            return new BasketDto
            {
                Id = basket.Id,
                BuyerId = basket.BuyerId,
                Items = basket.Items.Select(item => new BasketItemDto
                {
                    ProductId = item.ProductId,
                    Name = item.Product.name,
                    Price = item.Product.price,
                    PictureUrl = item.Product.pictureUrl,
                    Type = item.Product.type,
                    Brand = item.Product.brand,
                    Quantity = item.Quantity
                }).ToList()
            };
        }

    }
}