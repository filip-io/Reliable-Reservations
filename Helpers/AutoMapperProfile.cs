using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // Customer mappings

        CreateMap<Customer, CustomerDto>();


        // Reservation mappings

        CreateMap<Reservation, ReservationDto>();

        // Mapping from Reservation entity to ReservationDto
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
            .ForMember(dest => dest.TimeSlot, opt => opt.MapFrom(src => src.TimeSlot))
            .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables));

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

        // Mapping from Reservation entity to ReservationDetailsDto
        CreateMap<Reservation, ReservationDetailsDto>()
            .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => $"{src.Customer.FirstName} {src.Customer.LastName}"))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.TimeSlot.StartTime))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.TimeSlot.EndTime))
            .ForMember(dest => dest.PartySize, opt => opt.MapFrom(src => src.NumberOfGuests))
            .ForMember(dest => dest.Tables, opt => opt.MapFrom(src => src.Tables));

        // Mapping from ReservationDetailsDto to Reservation entity
        CreateMap<ReservationDetailsDto, Reservation>()
            .ForMember(dest => dest.Customer, opt => opt.Ignore())
            .ForMember(dest => dest.TimeSlot, opt => opt.Ignore())
            .ForMember(dest => dest.Tables, opt => opt.Ignore());


        // Table mappings

        CreateMap<Table, TableDto>().ReverseMap();
        CreateMap<Table, TableCreateDto>();


        // TimeSlot mappings

        CreateMap<TimeSlot, TimeSlotDto>().ReverseMap();
        CreateMap<TimeSlot, TimeSlotCreateDto>().ReverseMap();


        // MenuItem mappings

        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
        CreateMap<MenuItem, MenuItemCreateDto>().ReverseMap();

    }
}