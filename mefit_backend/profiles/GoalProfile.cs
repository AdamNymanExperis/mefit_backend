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
                .ForMember(dto => dto.FitnessProgramGoals, options =>
                options.MapFrom(fitnessProgramDomain => fitnessProgramDomain.FitnessProgramGoals.Select(fitnessProgram => $"api/v1/fitnessProgramGoal/{fitnessProgram.Id}").ToList()))
                .ForMember(dto => dto.WorkoutGoals, options =>
                options.MapFrom(workoutDomain => workoutDomain.WorkoutGoals.Select(workout => $"api/v1/workoutGoal/{workout.Id}").ToList()));
        }
    }
}
