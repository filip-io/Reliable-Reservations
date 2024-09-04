using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;
using Reliable_Reservations.Models.ViewModels;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // Customer mappings

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateDto>().ReverseMap();
        CreateMap<Customer, CustomerViewModel>().ReverseMap();        

            //// Customer FullName mapping

            //CreateMap<Customer, CustomerViewModel>()
            //    .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


        // Reservation mappings

        CreateMap<Reservation, ReservationDto>().ReverseMap();
        CreateMap<ReservationUpdateDto, Reservation>().ReverseMap();
        CreateMap<ReservationUpdateDto, ReservationDetailsViewModel>();

            // Mapping from ReservationDto to Reservation entity
            CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.TimeSlot, opt => opt.Ignore())
                .ForMember(dest => dest.Tables, opt => opt.Ignore());

            // Mapping from ReservationCreateDto to Reservation entity
            CreateMap<ReservationCreateDto, Reservation>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.TimeSlot, opt => opt.Ignore())
                .ForMember(dest => dest.Tables, opt => opt.Ignore());

            // Mapping from Reservation entity to ReservationDetailsViewModel
            CreateMap<Reservation, ReservationDetailsViewModel>()
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer)) // Map Customer to CustomerViewModel
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.TimeSlot.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.TimeSlot.EndTime))
                .ForMember(dest => dest.NumberOfGuests, opt => opt.MapFrom(src => src.NumberOfGuests))
                .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables));

            // Mapping from ReservationDetailsDto to Reservation entity
            CreateMap<ReservationDetailsViewModel, Reservation>()
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.TimeSlot, opt => opt.Ignore())
                .ForMember(dest => dest.Tables, opt => opt.Ignore());




        // Table mappings

        CreateMap<Table, TableDto>().ReverseMap();
        CreateMap<Table, TableCreateDto>();


        // TimeSlot mappings

        CreateMap<TimeSlot, TimeSlotDto>().ReverseMap();
        CreateMap<TimeSlot, TimeSlotCreateDto>().ReverseMap();
        CreateMap<TimeSlotUpdateDto, TimeSlotDto>().ReverseMap();
        CreateMap<TimeSlotUpdateDto, TimeSlot>().ReverseMap();


        // MenuItem mappings

        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
        CreateMap<MenuItem, MenuItemCreateDto>().ReverseMap();

    }
}