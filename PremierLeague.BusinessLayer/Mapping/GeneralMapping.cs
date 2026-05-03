using AutoMapper;
using PremierLeague.DtoLayer.FootballMatchDtos;
using PremierLeague.DtoLayer.MatchEventDtos;
using PremierLeague.DtoLayer.MatchStatisticDtos;
using PremierLeague.DtoLayer.SeasonDtos;
using PremierLeague.DtoLayer.TeamDtos;
using PremierLeague.DtoLayer.WeekDtos;
using PremierLeague.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremierLeague.BusinessLayer.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<FootballMatch, ResultFootballMatchDto>().ReverseMap();
            CreateMap<FootballMatch, CreateFootballMatchDto>().ReverseMap();
            CreateMap<FootballMatch, UpdateFootballMatchDto>().ReverseMap();
            CreateMap<FootballMatch, GetFootballMatchByIdDto>().ReverseMap();

            CreateMap<MatchEvent, GetMatchEventByIdDto>().ReverseMap();
            CreateMap<MatchEvent, CreateMatchEventDto>().ReverseMap();
            CreateMap<MatchEvent, UpdateMatchEventDto>().ReverseMap();
            CreateMap<MatchEvent, ResultMatchEventDto>().ReverseMap();
            CreateMap<MatchEvent, ResultMatchEventDto>().ForMember(dest => dest.FootballMatchHomeTeamName, opt => opt.MapFrom(src => src.FootballMatch.HomeTeam.Name)).ForMember(dest => dest.FootballMatchAwayTeamName, opt => opt.MapFrom(src => src.FootballMatch.AwayTeam.Name));

            CreateMap<MatchStatistic, ResultMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, GetMatchStatisticByIdDto>().ReverseMap();
            CreateMap<MatchStatistic, UpdateMatchStatisticDto>().ReverseMap();
            CreateMap<MatchStatistic, CreateMatchStatisticDto>().ReverseMap();

            CreateMap<Season, CreateSeasonDto>().ReverseMap();
            CreateMap<Season, UpdateSeasonDto>().ReverseMap();
            CreateMap<Season, GetSeasonByIdDto>().ReverseMap();
            CreateMap<Season, ResultSeasonDto>().ReverseMap();

            CreateMap<Team, ResultTeamDto>().ReverseMap();
            CreateMap<Team, GetTeamByIdDto>().ReverseMap();
            CreateMap<Team, CreateTeamDto>().ReverseMap();
            CreateMap<Team, UpdateTeamDto>().ReverseMap();

            CreateMap<Week, UpdateWeekDto>().ReverseMap();
            CreateMap<Week, CreateWeekDto>().ReverseMap();
            CreateMap<Week, GetWeekByIdDto>().ReverseMap();
            CreateMap<Week, ResultWeekDto>().ReverseMap();
         
        }
    }
}
