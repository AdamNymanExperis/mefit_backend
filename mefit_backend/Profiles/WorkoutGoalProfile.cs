using mefit_backend.models.domain;
using mefit_backend.models.DTO.ExerciseDtos;
using mefit_backend.models.DTO.WorkoutGoalDtos;
using mefit_backend.Models.dto.WorkoutExerciseDtos;
using Microsoft.Extensions.Options;

namespace mefit_backend.profiles
{
    public class WorkoutGoalProfile : AutoMapper.Profile
    {
        public WorkoutGoalProfile()
        {
            CreateMap<PostWorkoutGoalDTO, WorkoutGoal>();
            CreateMap<PutWorkoutGoalDTO, WorkoutGoal>();
            CreateMap<WorkoutGoal, GetWorkoutGoalDTO>()
                .ForMember(dto => dto.Goal, options =>
                options.MapFrom(goalDomain => $"api/v1/goal/{goalDomain.GoalId}"))
                .ForMember(dto => dto.Workout, options =>
                options.MapFrom(workoutDomain => $"api/v1/workout/{workoutDomain.WorkoutId}"));

        }

    }
}
