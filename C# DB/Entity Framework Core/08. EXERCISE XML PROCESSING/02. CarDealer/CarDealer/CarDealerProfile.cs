using AutoMapper;
using System.Linq;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
       
        public CarDealerProfile()
        {

            this.CreateMap<ImportSupplierDto, Supplier>();
            this.CreateMap<ImportPartDto, Part>();

            this.CreateMap<ImportCustomerDto, Customer>();

            this.CreateMap<ImportSalesDto, Sale>();

            this.CreateMap<Car, ExportCarWithDistanceDto>();

            this.CreateMap<Car, ExportBMWCars>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>();

            this.CreateMap<Part, ExportCarPartDto>();
            this.CreateMap<Car, ExportCarDto>()
                .ForMember(x=>x.Parts, y=>y.MapFrom(x=>x.PartCars.Select(pc=>pc.Part)));

            this.CreateMap<Customer, ExportCustomerWithTotalSalesDto>()
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.Name));
                
            

        }
    }
}
