using AutoMapper;
using Models.DB;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace note_management_api.MappingProfiles
{
    public class NotesProfile : Profile
    {
        public NotesProfile()
        {
            CreateMap<NOTES, NoteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(source => source.Text))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(source => source.InsertDate))
                ;

            CreateMap<NoteDTO, NOTES>()
                  .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
                  .ForMember(dest => dest.Text, opt => opt.MapFrom(source => source.Text))
                  .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
                  .ForMember(dest => dest.InsertDate, opt => opt.MapFrom(source => source.InsertDate))
                  .ForMember(dest => dest.LastUpdate, opt => opt.MapFrom(source => source.LastUpdate))
                  ;

            //CreateMap<CreateOrUpdateNoteDTO, NOTES > ()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(source => source.Id))
            //    .ForMember(dest => dest.Text, opt => opt.MapFrom(source => source.Text))
            //    .ForMember(dest => dest.Title, opt => opt.MapFrom(source => source.Title))
            //    ;
        }
    }
}
