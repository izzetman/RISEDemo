using RISEDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISEDemo.Services.Interfaces
{
    public interface IUrunService
    {
        Task<bool> UrunOlustur(UrunDetay urunDetay);

        Task<IEnumerable<UrunDetay>> TumUrunleriListele();

        Task<UrunDetay> UrunById(int id);

        Task<bool> UrunGuncelle(UrunDetay urunDetay);

        Task<bool> UrunSil(int id);
    }
}
