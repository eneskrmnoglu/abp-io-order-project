using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace OrderProject.Customers
{
    public interface ICustomerAppService :
        ICrudAppService< //Bu arayüz CRUD (Oluştur, Oku, Güncelle ve Sil) metodlarını tanımlar.
            CustomerDto, //Müşteri bilgilerini göstermek için kullanılır.
            Guid, //Customer entity'sinin birincil anahtarıdır.
            PagedAndSortedResultRequestDto, //Sayfalandırma ve sıralama için kullanılır.
            CreateUpdateCustomerDto> //Bir müşteriyi oluşturmak veya güncellemek için kullanılır.
    {
        
    }
}
