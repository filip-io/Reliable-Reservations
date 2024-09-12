using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs.Customer;
using Reliable_Reservations.Models.DTOs.MenuItem;
using Reliable_Reservations.Models.DTOs.OpeningHours;
using Reliable_Reservations.Models.DTOs.Reservation;
using Reliable_Reservations.Models.DTOs.Table;
using Reliable_Reservations.Models.DTOs.TimeSlot;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {

        // Customer mappings

        CreateMap<Customer, CustomerDto>().ReverseMap();
        CreateMap<Customer, CustomerCreateDto>().ReverseMap();     



        // Reservation mappings

        CreateMap<Reservation, ReservationDto>().ReverseMap();
        CreateMap<ReservationUpdateDto, Reservation>().ReverseMap();
        CreateMap<ReservationUpdateDto, ReservationDetailsDto>();

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
                .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.Customer))
                .ForMember(dest => dest.NumberOfGuests, opt => opt.MapFrom(src => src.NumberOfGuests))
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
        CreateMap<TimeSlotUpdateDto, TimeSlotDto>().ReverseMap();
        CreateMap<TimeSlotUpdateDto, TimeSlot>().ReverseMap();


        // MenuItem mappings

        CreateMap<MenuItem, MenuItemDto>().ReverseMap();
        CreateMap<MenuItem, MenuItemCreateDto>().ReverseMap();


        // OpeningHours mappings

        CreateMap<OpeningHours, OpeningHoursDto>().ReverseMap();

        CreateMap<OpeningHours, OpeningHoursDto>()
            .ForMember(dest => dest.SpecialOpeningHours, opt => opt.MapFrom(src => src.SpecialOpeningHours));
            //.ForMember(dest => dest.TimeSlots, opt => opt.MapFrom(src => src.TimeSlots));


        // SpecialOpeningHours mappings

        CreateMap<SpecialOpeningHours, SpecialOpeningHoursDto>();

    }
}