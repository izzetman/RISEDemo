using Microsoft.AspNetCore.Mvc;
using RISEDemo.Core.Models;
using RISEDemo.Services.Interfaces;

namespace RISEDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrunlerController : ControllerBase
    {
        public readonly IUrunService _urunService;
        public UrunlerController(IUrunService UrunService)
        {
            _urunService = UrunService;
        }

        /// <summary>
        /// Get the list of product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Liste()
        {
            var productDetailsList = await _urunService.TumUrunleriListele();
            if (productDetailsList == null)
            {
                return NotFound();
            }
            return Ok(productDetailsList);
        }

        /// <summary>
        /// Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet("{productId}")]
        public async Task<IActionResult> UrunById(int productId)
        {
            var productDetails = await _urunService.UrunById(productId);

            if (productDetails != null)
            {
                return Ok(productDetails);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <param name="urunDetay"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UrunOlustur(UrunDetay urunDetay)
        {
            var isProductCreated = await _urunService.UrunOlustur(urunDetay);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Update the product
        /// </summary>
        /// <param name="urunDetay"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UrunGuncelle(UrunDetay urunDetay)
        {
            if (urunDetay != null)
            {
                var isProductCreated = await _urunService.UrunGuncelle(urunDetay);
                if (isProductCreated)
                {
                    return Ok(isProductCreated);
                }
                return BadRequest();
            }
            else
            {
                return BadRequest();
            }
        }

        /// <summary>
        /// Delete product by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{productId}")]
        public async Task<IActionResult> UrunSil(int id)
        {
            var isProductCreated = await _urunService.UrunSil(id);

            if (isProductCreated)
            {
                return Ok(isProductCreated);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
