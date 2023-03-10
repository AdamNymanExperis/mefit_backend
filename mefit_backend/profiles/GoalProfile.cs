using AutoMapper;
using mefit_backend.models.domain;
using mefit_backend.Models.DTO.Goal;

namespace mefit_backend.profiles
{
    public class GoalProfile : AutoMapper.Profile
    {
        public GoalProfile() 
        {
            CreateMap<PutGoalDTO, Goal>();
            CreateMap<CreateGoalDTO, Goal>();
            CreateMap<Goal , GetGoalDTO>()
                .ForMember(dto => dto.FitnessPrograms, options =>
                options.MapFrom(fitnessProgramDomain => fitnessProgramDomain.FitnessPrograms.Select(fitnessProgram => $"api/v1/goal/{fitnessProgram.Id}").ToList()))
                .ForMember(dto => dto.Workouts, options =>
                options.MapFrom(workoutDomain => workoutDomain.Workouts.Select(workout => $"api/v1/impairment/{workout.Id}").ToList()));
        }
    }
}
