using AutoMapper;
using Reliable_Reservations.Models;
using Reliable_Reservations.Models.DTOs;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // Table mappings
        CreateMap<TableCreateDto, Table>();
        CreateMap<Table, TableCreateDto>();
        CreateMap<Table, TableDto>();

        // TimeSlot mappings
        CreateMap<TimeSlotCreateDto, TimeSlot>();
        CreateMap<TimeSlot, TimeSlotCreateDto>();
        CreateMap<TimeSlot, TimeSlotDto>();
    }
}