using AutoMapper;
using mefit_backend.models.domain;
using mefit_backend.Models.dto.FitnessProgramDtos;
using mefit_backend.Models.DTO.Goal;

namespace mefit_backend.profiles
{
    public class FitnessProgramProfile : AutoMapper.Profile
    {
        public FitnessProgramProfile()
        {
            CreateMap<PutFitnessProgramDTO, FitnessProgram>();
            CreateMap<PostFitnessProgramDTO, FitnessProgram>();
            CreateMap<FitnessProgram, GetFitnessProgramDTO>()
                .ForMember(dto => dto.Workouts, options =>
                options.MapFrom(workoutDomain => workoutDomain.Workouts.Select(workout => $"api/v1/workout/{workout.Id}").ToList()))
                .ForMember(dto => dto.FitnessProgramGoals, options =>
                options.MapFrom(goalDomain => goalDomain.FitnessProgramGoals.Select(fitnessProgramGoal => $"api/v1/fitnessprogramgoal/{fitnessProgramGoal.Id}").ToList()));
        }
    }
}
