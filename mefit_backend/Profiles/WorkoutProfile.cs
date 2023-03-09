using mefit_backend.models.domain;
using mefit_backend.Models.DTO.WorkoutDtos;
using Microsoft.Extensions.Options;
using AutoMapper;

namespace mefit_backend.Profiles
{
    public class WorkoutProfile: AutoMapper.Profile
    {
        public WorkoutProfile()
        {
            CreateMap<AddWorkoutDTO, Workout>();
            CreateMap<PutWorkoutDTO, Workout>();
            CreateMap<Workout, GetWorkoutDTO>()
                .ForMember(dto => dto.WorkoutGoals, options =>
                options.MapFrom(workoutDomain => workoutDomain.WorkoutGoals.Select(goal => $"api/v1/Goal/{goal.Id}").ToList()))
                .ForMember(dto => dto.WorkoutExercises, options =>
                options.MapFrom(workoutDomain => workoutDomain.WorkoutExercises.Select(workout => $"api/v1/Workout/{workout.Id}").ToList()))
                .ForMember(dto => dto.FitnessPrograms, options =>
                options.MapFrom(workoutDomain => workoutDomain.FitnessPrograms.Select(fitnessprogram => $"api/v1/FitnessProgram/{fitnessprogram.Id}").ToList()));
        }
    }
}
