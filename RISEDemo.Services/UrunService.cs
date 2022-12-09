using RISEDemo.Core.Interfaces;
using RISEDemo.Core.Models;
using RISEDemo.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISEDemo.Services
{
    public class UrunService : IUrunService
    {
        public IUnitOfWork _unitOfWork;

        public UrunService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> UrunOlustur(UrunDetay productDetails)
        {
            if (productDetails != null)
            {
                await _unitOfWork.Urunler.Add(productDetails);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> UrunSil(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Urunler.GetById(productId);
                if (productDetails != null)
                {
                    _unitOfWork.Urunler.Delete(productDetails);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<UrunDetay>> TumUrunleriListele()
        {
            var productDetailsList = await _unitOfWork.Urunler.GetAll();
            return productDetailsList;
        }

        public async Task<UrunDetay> UrunById(int productId)
        {
            if (productId > 0)
            {
                var productDetails = await _unitOfWork.Urunler.GetById(productId);
                if (productDetails != null)
                {
                    return productDetails;
                }
            }
            return null;
        }

        public async Task<bool> UrunGuncelle(UrunDetay productDetails)
        {
            if (productDetails != null)
            {
                var product = await _unitOfWork.Urunler.GetById(productDetails.Id);
                if (product != null)
                {
                    product.Ad = productDetails.Ad;
                    product.Aciklama = productDetails.Aciklama;
                    product.BirimFiyat = productDetails.BirimFiyat;
                    product.StokMiktari = productDetails.StokMiktari;

                    _unitOfWork.Urunler.Update(product);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
